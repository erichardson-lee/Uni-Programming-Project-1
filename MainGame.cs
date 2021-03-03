using Gamegrid;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Speech.Synthesis;
using System.Windows.Forms;
using System.Media;

namespace O_Neillo
{
    /// <summary>
    /// Cell values, used internally instead of hard coded values.
    /// </summary>
    public enum CellValues
    {
        black = 1,
        white = 2,
        blank = 10
    }

    public partial class MainGame : Form
    {
        static int SerialisationVersion = 1;

        #region Public classes

        /// <summary>
        /// Class used to pass savefile data between functions
        /// </summary>
        public class GameData
        {
            public string Player1Name;
            public string Player2Name;
            public int Player1Score;
            public int Player2Score;
            public int CurrentPlayer;
            public int GameRows;
            public int GameColumns;
            public CellValues[,] GameValsData;
        }

        #endregion

        #region Internal classes

        /// <summary>
        /// Contains a deltaX and a deltaY value to 'travel' in that direction.
        /// </summary>
        private class Direction
        {
            public int dx, dy;

            public Direction(int dx, int dy)
            {
                this.dx = dx;
                this.dy = dy;
            }
        }

        /// <summary>
        /// Array containing all possible directions that you can flank
        /// </summary>
        private static Direction[] Directions =
        {
            new Direction(-1,-1),
            new Direction(-1,0),
            new Direction(-1,1),
            new Direction(0,-1),
            new Direction(0,0),
            new Direction(0,1),
            new Direction(1,-1),
            new Direction(1,0),
            new Direction(1,1)
        };

        /// <summary>
        /// Class used to pass around point stacks for tokens to flip
        /// </summary>
        private class FlankInfo
        {
            /// <summary>
            /// Indicates if at least one flank is available, saves O(n) lookup on the flankpoints array.
            /// </summary>
            public bool CanFlank = false;
            public Stack<Point>[] FlankPoints = new Stack<Point>[Directions.Length];
        }


        #endregion

        #region Internal variables
        Image GridBlack = Properties.Resources.GridBlack;
        Image GridWhite = Properties.Resources.GridWhite;

        /// <summary>
        /// Says whether or not the game's currently being played.
        /// </summary>
        bool playing = false;

        /// <summary>
        /// Stores the values of each grid for ease of lookup
        /// </summary>
        CellValues[,] gameVals;

        /// <summary>
        /// Stores which player's currently playing
        /// </summary>
        Playerinfo currentPlayer;

        /// <summary>
        /// Stores if the previous player passed (If both pass, game ends)
        /// </summary>
        bool previousPlayerPassed;

        /// <summary>
        /// Speach Synthesize used for TTS
        /// </summary>
        SpeechSynthesizer synth = new SpeechSynthesizer();

        #endregion

        #region Internal functions (Events)

        /// <summary>
        /// Initialises class.
        /// </summary>
        public MainGame(string SaveFile = "")
        {
            InitializeComponent();
            gameGrid1.InitializeGrid();

            synth.SetOutputToDefaultAudioDevice();
            if (SaveFile != "" && File.Exists(SaveFile))
            {
                LoadGameFromFile(SaveFile);
            }
        }

        /// <summary>
        /// Called whenever you click exit
        /// </summary>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (playing)
            {
                switch (MessageBox.Show("Would you like to save the game before exiting?", "Save game?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                {
                    case (DialogResult.Yes):
                        {
                            SaveGameToFile();
                            break;
                        }
                    case (DialogResult.Cancel):
                        {
                            return;
                        }
                    default:
                        break;
                }
            }
            Application.Exit();
        }

        /// <summary>
        /// Called whenever you click start game
        /// </summary>
        private void newGame_Click(object sender, EventArgs e)
        {
            if (playing)
            {
                switch (MessageBox.Show("Would you like to save the present game before starting a new one?", "Save game?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                {
                    case (DialogResult.Yes):
                        {
                            SaveGameToFile();
                            break;
                        }
                    case (DialogResult.Cancel):
                        {
                            return;
                        }
                    default:
                        break;
                }
            }

            if (playerinfo1.PlayerName == "" || playerinfo2.PlayerName == "")
            {
                Speak("Both Players need a name to start.", false, true);
                return;
            }

            StartGame();
        }

        /// <summary>
        /// Called whenever the grid's pressed
        /// </summary>
        private void gameGrid1_CellPressed(object sender, CellPressedEventArgs e)
        {
            AttemptMove(e.x, e.y);
        }

        /// <summary>
        /// Called whenever the pass button's pressed.
        /// </summary>
        private void passBtn_click(object sender, EventArgs e)
        {
            if (!playing)
            {
                MustBePlayingError();
                return;
            }

            if (AnyLegalMoves())
            {
                Speak("A legal move was found, you can't pass.", false, true);
                return;
            }

            //MessageBox.Show("No legal moves found, passing turn");
            Speak("No Legal moves where found, passing your turn!");
            if (previousPlayerPassed == true)
            {
                EndGame();
            }
            else
            {
                previousPlayerPassed = true;
                SwitchPlayer();
            }

            return;
        }

        /// <summary>
        /// Called whenever the speak checkbox is clicked.
        /// </summary>
        private void chk_speak_Click(object sender, EventArgs e)
        {
            Speak($"Voice Synthesis Turned {(chk_speak.Checked ? "On" : "Off")}");
        }

        /// <summary>
        /// Called whenever the load button is pressed
        /// </summary>
        private void loadBtn_Click(object sender, EventArgs e)
        {
            switch (openFileDialog1.ShowDialog())
            {
                case (DialogResult.OK):
                    {
                        LoadGameFromFile(openFileDialog1.FileName);
                        break;
                    }
                default:
                    break;
            }
        }

        /// <summary>
        /// Called whenever the save button is pressed
        /// </summary>
        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (!playing)
            {
                MustBePlayingError();
                return;
            }
            SaveGameToFile();
        }

        /// <summary>
        /// Called whenever the help button is pressed
        /// </summary>
        private void helpBtn_Click(object sender, EventArgs e)
        {
            new About().Show();
        }

        #endregion

        #region Internal functions (Gameplay)

        /// <summary>
        /// Call this function to switch which player's currently playing.
        /// </summary>
        private void SwitchPlayer()
        {
            currentPlayer.PlayerTurn = false;

            currentPlayer = (currentPlayer == playerinfo1) ? playerinfo2 : playerinfo1;

            currentPlayer.PlayerTurn = true;

            if (currentPlayer.CellValue == CellValues.black)
            {
                this.Icon = Properties.Resources.Icon_GridBlack;
            }
            else if (currentPlayer.CellValue == CellValues.white)
            {
                this.Icon = Properties.Resources.Icon_GridWhite;
            }
            else
            {
                this.Icon = Properties.Resources.Icon_GridBase;
            }

            if (!AnyLegalMoves() && playing)
            {
                Speak($"No Legal moves found, Skipping {currentPlayer.PlayerName}'s turn", false, true);

                if (previousPlayerPassed == true)
                {
                    EndGame();
                }
                else
                {
                    previousPlayerPassed = true;
                    SwitchPlayer();
                }
            }
        }

        /// <summary>
        /// Function called to setup the board and start a new game.
        /// </summary>
        private void StartGame()
        {

            gameGrid1.InitializeGrid();
            gameVals = new CellValues[gameGrid1.Columns, gameGrid1.Rows];

            for (int x = 0; x < gameGrid1.Columns; x++)
            {
                for (int y = 0; y < gameGrid1.Rows; y++)
                {
                    gameVals[x, y] = CellValues.blank;
                }
            }

            int cx = gameGrid1.Columns / 2;
            int cy = gameGrid1.Rows / 2;

            SetCell(cx - 1, cy - 1, CellValues.black);
            SetCell(cx, cy, CellValues.black);
            SetCell(cx, cy - 1, CellValues.white);
            SetCell(cx - 1, cy, CellValues.white);

            playerinfo1.Tokens = 2;
            playerinfo1.PlayerTurn = true;
            playerinfo2.Tokens = 2;
            playerinfo2.PlayerTurn = false;

            Speak($"Starting Game, {playerinfo1.PlayerName} as black versus {playerinfo2.PlayerName} as white.", true);

            currentPlayer = playerinfo1;
            this.Icon = Properties.Resources.Icon_GridBlack;

            playing = true;
        }

        /// <summary>
        /// Function called to declare a winner and end the game
        /// </summary>
        private void EndGame()
        {
            Playerinfo winner = (playerinfo1.Tokens > playerinfo2.Tokens) ? ref playerinfo1 : ref playerinfo2;
            Speak($"Game Ended, {winner.PlayerName} won with {winner.Tokens} tokens!");

            MessageBox.Show(
                $"Game Ended, {winner.PlayerName} won with {winner.Tokens} tokens!",
                "Game Ended",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        /// <summary>
        /// Attempt to place a piece on the specific co-ordinate
        /// </summary>
        /// <param name="x">The X value of the cell to place on</param>
        /// <param name="y">The Y value of the cell to place on</param>
        private void AttemptMove(int x, int y)
        {
            // For purposes of this, n is the average width/height of the grid.

            // Test O(1)
            if (!playing)
            {
                MustBePlayingError();
                return;
            }

            // Move must follow these rules:
            // 0) The square you place in must not have a piece already in it
            // 1) Must be adjacent to an opponents piece
            // 2) Must outflank an opponents piece (and by extension, be able to flip them)
            // 3) If outflanks in multiple directions, all flip
            // 4) If no moves are available you must pass.
            // 5) If moves are availble, you can't pass.
            // 6) If neither player has avalable moves, the game ends.

            // To make sure i'm checking in a decent

            // O(1) lookup on an array
            if (GetCell(x, y) != CellValues.blank)
            {
                // Breaks rule 0, there's somethign already there
                Speak("You can't place a token there, the space is already occupied.");
                return;
            }

            // O(9) checks all 9 squares in a 3x3 for opponents (including it's own square)
            if (!OpponentAdjacent(x, y))
            {
                // Breaks rule 1, return and let them try again
                // MessageBox.Show("R1");
                Speak("You can't place a token there, you must be adjacent to an opponent's token");
                return;
            }

            int dScore = 0;

            // Runs get flanks, checks approiximately 3n cells 
            // (for 8x8 grid, 5this would be approximately 24, can check up to 27, but will probably be less) 
            FlankInfo flanks = GetFlanks(x, y);

            if (!flanks.CanFlank)
            {
                // Breaks rule 2, return and let them try again
                // MessageBox.Show("R2");
                Speak("You can't place a token there, you must be outflanking at least one enemy piece.");
                return;
            }
            else
            {
                // Stop any existing messages
                StopSpeak();

                // Complies with rule 1 and 2, flip flanks in all directions
                // MessageBox.Show("R2");
                for (int i = 0; i < flanks.FlankPoints.Length; i++)
                {
                    ref Stack<Point> points = ref flanks.FlankPoints[i];

                    while (points.Count != 0)
                    {
                        Point p = points.Pop();

                        SetCell(p.X, p.Y, currentPlayer.CellValue);

                        dScore++;
                    }
                }

            }

            SetCell(x, y, currentPlayer.CellValue);
            Speak($"{currentPlayer.PlayerName} placed a token at grid{x + 1}, {y + 1} and flipped {dScore} {(dScore > 1 ? "tokens" : "token")}.", true);
            previousPlayerPassed = false;
            currentPlayer.Tokens += dScore + 1;

            SwitchPlayer();

            currentPlayer.Tokens -= dScore;
        }

        /// <summary>
        /// Sets the value for a cell
        /// </summary>
        /// <param name="x">The X value of the cell to set</param>
        /// <param name="y">The Y value of the cell to set</param>
        /// <param name="val">The Value to set the cell to</param>
        private void SetCell(int x, int y, CellValues val)
        {
            gameVals[x, y] = val;

            if (val == CellValues.black)
            {
                gameGrid1.SetCell(x, y, GridBlack);
            }
            else if (val == CellValues.white)
            {
                gameGrid1.SetCell(x, y, GridWhite);
            }
        }

        /// <summary>
        /// Get the value of a cell
        /// </summary>
        /// <param name="x">The X value of the cell to check</param>
        /// <param name="y">The Y value of the cell to check</param>
        /// <returns>The cells value</returns>
        private CellValues GetCell(int x, int y)
        {
            return gameVals[x, y];
        }

        /// <summary>
        /// Used to display an error that you must be playing the game in order to perform a certain action.
        /// </summary>
        private void MustBePlayingError()
        {
            Speak("You need to start a game first!(Game->Start Game)", false, true);
            //MessageBox.Show("You need to start a game first! (Game -> Start Game)");
            return;
        }

        /// <summary>
        /// Checks if placing a token on a spot is a legal move.
        /// </summary>
        /// <param name="x">The X value of the spot to check</param>
        /// <param name="y">The Y value of the spot to check</param>
        /// <returns>True if a piece can be legally placed there</returns>
        private bool LegalMove(int x, int y)
        {
            if ((GetCell(x, y) == CellValues.blank) && OpponentAdjacent(x, y) && AnyFlanks(x, y).CanFlank)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Checks if there is an opponent peice in any adjacent square
        /// </summary>
        /// <param name="centerX">The X value to center the search on</param>
        /// <param name="centerY">The Y value to center the search on</param>
        /// <returns>True if there is an opponent adjacent</returns>
        private bool OpponentAdjacent(int centerX, int centerY)
        {
            CellValues enemyCell;

            if (currentPlayer == playerinfo1)
            {
                enemyCell = CellValues.white;
            }
            else
            {
                enemyCell = CellValues.black;
            }

            for (int x = centerX - 1; x <= centerX + 1; x++)
            {
                for (int y = centerY - 1; y <= centerY + 1; y++)
                {
                    if ((x >= 0 && x < gameGrid1.Columns) && (y >= 0 && y < gameGrid1.Rows))
                    {
                        if (gameVals[x, y] == enemyCell)
                        {
                            return true;
                        }
                    }
                    else
                    {
                        // Out of bounds error, go to next value in loop
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// This function takes a point and checks for flanks in every direction.
        /// </summary>
        /// <param name="centerX">The X value to center the search on</param>
        /// <param name="centerY">The Y value to center the search on</param>
        /// <returns>Flankinfo class</returns>
        private FlankInfo GetFlanks(int centerX, int centerY)
        {
            FlankInfo flankInfo = new FlankInfo();

            // Loops through each direction
            for (int i = 0; i < Directions.Length; i++)
            {
                ref Direction dir = ref Directions[i];
                // Stack size is slightly overkill, but it's to avoid any potential stack overflows
                Stack<Point> Flanks = new Stack<Point>(128);

                // If I find a flank in a specific direction, add its stack to the array,
                // if not, add a blank stack.
                if (FindFlank(centerX + dir.dx, centerY + dir.dy, dir, Flanks, true))
                {
                    // MessageBox.Show($"FlankDir: {dir.dx},{dir.dy} successfull");
                    flankInfo.FlankPoints[i] = Flanks;

                    // indicates that at least one flank is available (saves any looping later)
                    flankInfo.CanFlank = true;
                }
                else
                {
                    flankInfo.FlankPoints[i] = new Stack<Point>(0);
                }

            }

            return flankInfo;
        }

        /// <summary>
        /// Similar to GetFlanks, but exists when it finds the first one. Mainly for checking if a play is legal.
        /// </summary>
        /// <param name="centerX">The X value to center the search on</param>
        /// <param name="centerY">The Y value to center the search on</param>
        /// <returns>Flankinfo class (WILL NOT HAVE ALL POSSIBLE FLANKS)</returns>
        /// <remarks>This functuion is purely for checking that at least one flank exists on the piece.
        /// There is no guarantee that it will find all the flanks because it stops at the first one.
        /// If you want to get all the flanks, use <see cref="GetFlanks(int, int)"/> instead.</remarks>
        private FlankInfo AnyFlanks(int centerX, int centerY)
        {
            FlankInfo flankInfo = new FlankInfo();

            // Loops through each direction
            for (int i = 0; i < Directions.Length; i++)
            {
                ref Direction dir = ref Directions[i];
                // Stack size is slightly overkill, but it's to avoid any potential stack overflows
                Stack<Point> Flanks = new Stack<Point>(128);

                // If I find a flank in a specific direction, add its stack to the array,
                // if not, add a blank stack.
                if (FindFlank(centerX + dir.dx, centerY + dir.dy, dir, Flanks, true))
                {
                    // MessageBox.Show($"FlankDir: {dir.dx},{dir.dy} successfull");
                    flankInfo.FlankPoints[i] = Flanks;

                    // indicates that at least one flank is available (saves any looping later)
                    flankInfo.CanFlank = true;
                    return flankInfo;
                }
                else
                {
                    flankInfo.FlankPoints[i] = new Stack<Point>(0);
                }

            }

            return flankInfo;
        }

        /// <summary>
        /// Recursive function that goes in a specified direction and finds all the objects that can be flanked
        /// </summary>
        /// <param name="x">Current point X</param>
        /// <param name="y">Current point Y</param>
        /// <param name="dir">Direction to go (if recursing)</param>
        /// <param name="Flanks">A stack that all flank info will be pushed to</param>
        /// <param name="first">Is this the first iteration?</param>
        /// <returns>Returns true if a flank is found</returns>
        private bool FindFlank(int x, int y, Direction dir, Stack<Point> Flanks, bool first = false)
        {
            // Only runs the checks if x and y are on the grid.
            if ((x >= 0 && x < gameGrid1.Columns) && (y >= 0 && y < gameGrid1.Rows))
            {
                CellValues opponentCell = (currentPlayer == playerinfo1) ? playerinfo2.CellValue : playerinfo1.CellValue;
                CellValues cell = GetCell(x, y);
                // This should only occur if it's all the wrong color, then blank.
                // (So no flank found)
                if (cell == CellValues.blank)
                {
                    return false;
                }

                // If it encounters an enemy cell, add to the flanks stack, and continue moving in that direction
                if (cell == opponentCell)
                {
                    // fixes weird edge case that occasionally happens
                    if (Flanks == null)
                    {
                        return false;
                    }

                    // Add to flanks
                    Flanks.Push(new Point(x, y));
                    return FindFlank(x + dir.dx, y + dir.dy, dir, Flanks);
                }

                // If it encounters a friendly cell, return true and end the search.
                if (cell == currentPlayer.CellValue)
                {
                    // if this is the first cell it's going to and it's friendly, it's not a flank
                    // Otherwise, it is a flank (and will return true)
                    return !first;
                }
            }
            // In the event none of the above trigger, return false
            return false;
        }

        /// <summary>
        /// Displays text on top right as well as synthesises it
        /// </summary>
        /// <param name="text">Text to display / speak</param>
        private void Speak(string text, bool silent = false, bool messagebox = false)
        {
            txt_speech.Text = text;
            if (chk_speak.Checked)
            {
                synth.SpeakAsyncCancelAll();
                synth.SpeakAsync(text);
            }
            else if (!silent)
            {
                SystemSounds.Beep.Play();
            }

            if (messagebox)
            {
                MessageBox.Show(text);
            }
        }

        /// <summary>
        /// Stops all currently running voice lines, and clears the output box
        /// </summary>
        private void StopSpeak()
        {
            Speak("", true);
        }

        /// <summary>
        /// Checks the whole board for any legal moves
        /// </summary>
        /// <returns>True if any legal moves are found, false if none are found</returns>
        private bool AnyLegalMoves()
        {
            for (int x = 0; x < gameGrid1.Columns; x++)
            {
                for (int y = 0; y < gameGrid1.Rows; y++)
                {
                    if (LegalMove(x, y))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Sets the values of the different squares to the new values.
        /// </summary>
        private void SetGameVals(CellValues[,] newVals)
        {
            gameVals = newVals;
            gameGrid1.Columns = gameVals.GetLength(0);
            gameGrid1.Rows = gameVals.GetLength(1);
            gameGrid1.InitializeGrid();

            for (int x = 0; x < newVals.GetLength(0); x++)
            {
                for (int y = 0; y < newVals.GetLength(1); y++)
                {
                    SetCell(x, y, gameVals[x, y]);
                }
            }
        }

        /// <summary>
        /// Prompts the user to select a file location, then saves the current game to it
        /// </summary>
        private void SaveGameToFile()
        {
            saveFileDialog1.FileName = "O'NeilloSave.ej";
            switch (saveFileDialog1.ShowDialog())
            {
                case (DialogResult.OK):
                    {
                        GameData gd = new GameData()
                        {
                            CurrentPlayer = (int)currentPlayer.CellValue,
                            Player1Name = playerinfo1.PlayerName,
                            Player2Name = playerinfo2.PlayerName,
                            Player1Score = playerinfo1.Tokens,
                            Player2Score = playerinfo2.Tokens,
                            GameColumns = gameGrid1.Columns,
                            GameRows = gameGrid1.Rows,
                            GameValsData = gameVals
                        };

                        File.WriteAllText(saveFileDialog1.FileName, SerializeGame(gd));

                        break;
                    }
                default:
                    break;
            }

        }

        /// <summary>
        /// Prompts the user to select a file, then loads it
        /// </summary>
        private void LoadGameFromFile(string fileName)
        {
            try
            {
                if (!File.Exists(fileName)) throw new Exception("File not found");

                GameData gd = DeSerializeGame(File.ReadAllLines(fileName));
                LoadGame(gd);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Loads the data from the gd paramter into the current game
        /// </summary>
        /// <param name="gd">Game Data to load</param>
        private void LoadGame(GameData gd)
        {
            currentPlayer = (playerinfo1.CellValue == (CellValues)gd.CurrentPlayer) ? playerinfo1 : playerinfo2;
            playerinfo1.PlayerName = gd.Player1Name;
            playerinfo1.Tokens = gd.Player1Score;

            playerinfo2.PlayerName = gd.Player2Name;
            playerinfo2.Tokens = gd.Player2Score;

            gameGrid1.Columns = gd.GameColumns;
            gameGrid1.Rows = gd.GameRows;
            gameGrid1.InitializeGrid();
            SetGameVals(gd.GameValsData);

            playing = true;
            playerinfo1.PlayerTurn = false;
            playerinfo2.PlayerTurn = false;
            currentPlayer.PlayerTurn = true;
        }


        /// <summary>
        /// Converts the supplied gamedata to a string (Mainly for saving to a file)
        /// </summary>
        /// <param name="data">GameData to save</param>
        /// <returns></returns>
        private string SerializeGame(GameData data)
        {
            string OutputString = @" 
# Serialization format: (lines starting with # are comments) 
# All new values should be prefaced with two letters, then a colon
# ve:xx 
#   - Serialization version
# p1:xxx
#   - Player1 Name
# p2:xxx 
#   - Player2 Name
# s1:xxx
#   - Player1 Score
# s2:xxx 
#   - Player2 Score
# pc:xxx
#   - Current Player (0|1)
# gr:xxx 
#   - Game Rows
# gc:xxx
#   - Game Columns
# gd:x,x,x 
#   - gamevals Data, in CSV format, all one line in following order:
#     ╔═══╦═══╦═══╗
#     ║ 2 ║ 5 ║ 8 ║
#     ║ 1 ║ 4 ║ 7 ║
#     ║ 0 ║ 3 ║ 6 ║
#     ╚═══╩═══╩═══╝
            ";
            OutputString += Environment.NewLine;
            OutputString += $"ve:{SerialisationVersion}";

            OutputString += Environment.NewLine;
            OutputString += $"p1:{data.Player1Name}";

            OutputString += Environment.NewLine;
            OutputString += $"p2:{data.Player2Name}";

            OutputString += Environment.NewLine;
            OutputString += $"s1:{data.Player1Score}";

            OutputString += Environment.NewLine;
            OutputString += $"s2:{data.Player2Score}";

            OutputString += Environment.NewLine;
            OutputString += $"pc:{data.CurrentPlayer}";

            OutputString += Environment.NewLine;
            OutputString += $"gr:{data.GameRows}";

            OutputString += Environment.NewLine;
            OutputString += $"gc:{data.GameColumns}";

            int[] flatVars = new int[gameVals.GetLength(0) * gameVals.GetLength(1)];

            for (int x = 0; x < data.GameColumns; x++)
            {
                for (int y = 0; y < data.GameRows; y++)
                {
                    flatVars[y + (x * data.GameColumns)] = (int)gameVals[x, y];
                }
            }

            OutputString += Environment.NewLine;
            OutputString += $"gd:{string.Join(",", flatVars)}";

            return OutputString;

        }

        /// <summary>
        /// Converts an array of lines to gamedata.
        /// </summary>
        /// <seealso cref="File.ReadAllLines"/>
        /// <param name="data">String array of lines to interpret</param>
        /// <returns>Gamedata ready to be loaded</returns>
        private GameData DeSerializeGame(string[] data)
        {
            GameData gameData = new GameData();

            foreach (string line in data)
            {
                // skip if lines < 2 chars, it's not long enough to have a key
                if (line.Length < 2) { continue; }

                // skip line if first char is #
                if (line[0] == '#') { continue; }
                string key = line.Substring(0, 2).ToLower();
                string val = line.Substring(3);

                switch (key)
                {
                    case ("ve"):
                        {
                            int ver = int.Parse(val);
                            if (ver != SerialisationVersion)
                            {
                                throw new Exception("Invalid Savegame Version");
                            }
                            break;
                        }
                    case ("p1"):
                        {
                            gameData.Player1Name = val;
                            break;
                        }
                    case ("p2"):
                        {
                            gameData.Player2Name = val;
                            break;
                        }
                    case ("s1"):
                        {
                            gameData.Player1Score = int.Parse(val);
                            break;
                        }
                    case ("s2"):
                        {
                            gameData.Player2Score = int.Parse(val);
                            break;
                        }
                    case ("pc"):
                        {
                            gameData.CurrentPlayer = int.Parse(val);
                            break;
                        }
                    case ("gr"):
                        {
                            gameData.GameRows = int.Parse(val);
                            break;
                        }
                    case ("gc"):
                        {
                            gameData.GameColumns = int.Parse(val);
                            break;
                        }
                    case ("gd"):
                        {
                            if ((gameData.GameColumns == 0) || (gameData.GameRows == 0))
                            {
                                throw new Exception("Must have Rows and columns set befor game data in savefile");
                            }
                            CellValues[] flatArray = Array.ConvertAll(
                                 val.Split(','),
                                 s => (CellValues)int.Parse(s)
                                 );

                            if (flatArray.Length != gameData.GameColumns * gameData.GameRows)
                            {
                                throw new Exception("Invalid amount of data points for the specified rows and columns");
                            }

                            ref CellValues[,] gvd = ref gameData.GameValsData;
                            gvd = new CellValues[gameData.GameColumns, gameData.GameRows];

                            for (int x = 0; x < gameData.GameColumns; x++)
                            {

                                for (int y = 0; y < gameData.GameRows; y++)
                                {
                                    /*  Reads in following order (on 3x3)
                                    |*  ╔═══╦═══╦═══╗ *|
                                    |*  ║ 2 ║ 5 ║ 8 ║ *|
                                    |*  ║ 1 ║ 4 ║ 7 ║ *|
                                    |*  ║ 0 ║ 3 ║ 6 ║ *|
                                    |*  ╚═══╩═══╩═══╝ *|
                                    |*________________*/

                                    gvd[x, y] = flatArray[y + (x * gameData.GameColumns)];
                                }
                            }

                            break;
                        }
                    default:
                        break;
                }
            }

            return gameData;
        }

        #endregion

    }
}
