using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gamegrid;

namespace O_Neillo
{
    public partial class MainGame : Form
    {
        Image GridBlack = Properties.Resources.GridBlack;
        Image GridWhite = Properties.Resources.GridWhite;

        int[,] gameVals;

        Playerinfo currentPlayer;

        public MainGame()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void startGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gameGrid1.InitializeGrid();
            StartGame();
        }

        private void StartGame()
        {
            gameVals = new int[gameGrid1.Columns, gameGrid1.Rows];

            SetCell(3, 3, GridBlack);
            SetCell(4, 4, GridBlack);
            SetCell(4, 3, GridWhite);
            SetCell(3, 4, GridWhite);

            playerinfo1.Tokens = 2;
            playerinfo2.Tokens = 2;

            currentPlayer = playerinfo1;
            currentPlayer.PlayerTurn = true;
        }

        private void SetCell(int x, int y, Image img)
        {
            gameGrid1.SetCell(x, y, img);
            if (img == GridWhite)
            {
                gameVals[x, y] = 1;
            }
            else if (img == GridBlack)
            {
                gameVals[x, y] = 0;
            }
            else
            {
                gameVals[x, y] = 10;
            }
        }


        private void AttemptMove(int x, int y)
        {
            // Move must follow these rules:
            // Must be adjacent to an opponents piece
            // 

            return;
        }


        private void gameGrid1_CellPressed(object sender, CellPressedEventArgs e)
        {
            gameGrid1.SetCell(e.x, e.y, GridBlack);
        }
    }
}
