using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace O_Neillo
{
    public partial class Playerinfo : UserControl
    {


        private int _tokens;
        /// <summary>
        /// The current amount of cells held by the player
        /// </summary>
        [Description("Current number of tokens held by the player"), Category("O'Neillo")]
        public int Tokens
        {
            get
            {
                return _tokens;
            }
            set
            {
                _tokens = value;
                presentTokens.Text = $"{_tokens}x";
            }
        }

        /// <summary>
        /// The Cellvalue to set squares to when this player plays
        /// </summary>
        [Description("Integer value used to represent the player"), Category("O'Neillo")]
        public CellValues CellValue { get; set; }

        private Image _playerIcon;
        /// <summary>
        /// Which image to set this players cells to
        /// </summary>
        [Description("Icon for this player"), Category("O'Neillo")]
        public Image PlayerIcon
        {
            get
            {
                return _playerIcon;
            }
            set
            {
                _playerIcon = value;
                img_playerIcon.Image = value;
            }
        }

        /// <summary>
        /// The name to call the player
        /// </summary>
        public string PlayerName
        {
            get
            {
                return playername.Text;
            }
            set
            {
                playername.Text = value;
            }
        }

        private bool _playerTurn;
        /// <summary>
        /// Whether or not to show the player's turn icon
        /// </summary>
        [Description("Is it this player's turn?"), Category("O'Neillo")]
        public bool PlayerTurn
        {
            get
            {
                return _playerTurn;
            }
            set
            {
                _playerTurn = value;
                CurrentPlayer.Visible = value;
            }
        }

        /// <summary>
        /// Initialise the class
        /// </summary>
        public Playerinfo()
        {
            InitializeComponent();
        }
    }
}
