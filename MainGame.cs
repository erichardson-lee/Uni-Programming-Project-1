using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;
using Gamegrid;

namespace O_Neillo
{
    public enum CellValues
    {
        black = 1,
        white = 2,
        blank = 10
    }

    public partial class MainGame : Form
    {
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

        bool playing = false;
        CellValues[,] gameVals;

        Playerinfo currentPlayer;
        bool previousPlayerPassed;

        SpeechSynthesizer synth = new SpeechSynthesizer();

        #endregion

        #region Internal functions (Events)

        public MainGame()
        {
            InitializeComponent();
            synth.SetOutputToDefaultAudioDevice();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void startGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (playerinfo1.PlayerName == "" || playerinfo2.PlayerName == "")
            {
                Speak("Both Players need a name to start.");
                return;
            }

            gameGrid1.InitializeGrid();
            gameVals = new CellValues[gameGrid1.Columns, gameGrid1.Rows];

            for (int x = 0; x < gameGrid1.Columns; x++)
            {
                for (int y = 0; y < gameGrid1.Rows; y++)
                {
                    gameVals[x, y] = CellValues.blank;
                }
            }


            StartGame();
        }

        private void gameGrid1_CellPressed(object sender, CellPressedEventArgs e)
        {
            AttemptMove(e.x, e.y);
        }

        private void passBtn_click(object sender, EventArgs e)
        {
            if (!playing)
            {
                MustBePlayingError();
                return;
            }

            for (int x = 0; x < gameGrid1.Columns; x++)
            {
                for (int y = 0; y < gameGrid1.Rows; y++)
                {
                    if (LegalMove(x, y))
                    {
                        //MessageBox.Show("Legal move found, you can't pass.");
                        Speak("A legal move was found, you can't pass.");
                        return;
                    }
                }
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

                // Switch Player
                currentPlayer.PlayerTurn = false;
                currentPlayer = (currentPlayer == playerinfo1) ? playerinfo2 : playerinfo1;
                currentPlayer.PlayerTurn = true;
            }

            return;
        }

        private void chk_speak_Click(object sender, EventArgs e)
        {
            Speak($"Voice Synthesis Turned {(chk_speak.Checked ? "On" : "Off")}");
        }


        #endregion

        #region Internal functions (Gameplay)
        private void StartGame()
        {
            SetCell(3, 3, CellValues.black);
            SetCell(4, 4, CellValues.black);
            SetCell(4, 3, CellValues.white);
            SetCell(3, 4, CellValues.white);

            playerinfo1.Tokens = 2;
            playerinfo2.Tokens = 2;

            Speak($"Starting Game, {playerinfo1.PlayerName} as black versus {playerinfo2.PlayerName} as white.");

            currentPlayer = playerinfo1;
            currentPlayer.PlayerTurn = true;
            playing = true;
        }

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

        private CellValues GetCell(int x, int y)
        {
            return gameVals[x, y];
        }

        private void MustBePlayingError()
        {
            MessageBox.Show("You need to start a game first! (Menu -> Start)");
            return;
        }

        private void AttemptMove(int x, int y)
        {
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

            if (GetCell(x, y) != CellValues.blank)
            {
                // Breaks rule 0, there's somethign already there
                Speak("You can't place a token there, the space is already occupied.");
                return;
            }

            if (!OpponentAdjacent(x, y))
            {
                // Breaks rule 1, return and let them try again
                // MessageBox.Show("R1");
                Speak("You can't place a token there, you must be adjacent to an opponent's token");
                return;
            }

            int dScore = 0;
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
            Speak($"{currentPlayer.PlayerName} placed a token at grid{x + 1}, {y + 1} and flipped {dScore} {(dScore > 1 ? "tokens" : "token")}.");
            previousPlayerPassed = false;
            currentPlayer.Tokens += dScore + 1;
            currentPlayer.PlayerTurn = false;

            // Switch Player, remove dScore, then set active
            currentPlayer = (currentPlayer == playerinfo1) ? playerinfo2 : playerinfo1;
            currentPlayer.Tokens -= dScore;
            currentPlayer.PlayerTurn = true;
        }

        private bool LegalMove(int x, int y)
        {

            FlankInfo flanks = GetFlanks(x, y);

            if (OpponentAdjacent(x, y) && flanks.CanFlank && (GetCell(x, y) == CellValues.blank))
            {
                return true;
            }

            return false;
        }

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
        /// Recursive function that goes in a specified direction and finds all the objects that can be flanked
        /// Returns true if a flank is found (finds another piece of the same color)

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

        private void Speak(string text)
        {
            txt_speech.Text = text;
            if (chk_speak.Checked)
            {
                synth.SpeakAsyncCancelAll();
                synth.SpeakAsync(text);
            }
        }

        private void StopSpeak()
        {
            Speak("");
        }

        #endregion
    }
}
