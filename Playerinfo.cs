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

        [Description("Integer value used to represent the player"), Category("O'Neillo")]
        public CellValues CellValue { get; set; }

        public Image _playerIcon;
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

        public string PlayerName
        {
            get
            {
                return playername.Text;
            }
        }

        private bool _playerTurn;
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

        public Playerinfo()
        {
            InitializeComponent();
        }
    }
}
