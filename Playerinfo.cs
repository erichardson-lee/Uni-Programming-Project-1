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
        private readonly string[] aiNames = new string[] {
            "X Æ A-12",
            "Bot Jamie",
            "Bot Albert",
            "Bot Allen",
            "Bot Bert",
            "Bot Bob",
            "Bot Cecil",
            "Bot Clarence",
            "Bot Elliot",
            "Bot Elmer",
            "Bot Ernie",
            "Bot Eugene",
            "Bot Fergus",
            "Bot Ferris",
            "Bot Frank",
            "Bot Frasier",
            "Bot Fred",
            "Bot George",
            "Bot Graham",
            "Bot Harvey",
            "Bot Irwin",
            "Bot Larry",
            "Bot Lester",
            "Bot Marvin",
            "Bot Neil",
            "Bot Niles",
            "Bot Oliver",
            "Bot Opie",
            "Bot Ryan",
            "Bot Toby",
            "Bot Ulric",
            "Bot Ulysses",
            "Bot Uri",
            "Bot Waldo",
            "Bot Wally",
            "Bot Walt",
            "Bot Wesley",
            "Bot Yanni",
            "Bot Yogi",
            "Bot Yuri"
        };

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

        string _playername, _ainame;
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

        private bool _isAI;
        public bool isAI
        {
            get
            {
                return _isAI;
            }
            set
            {
                _isAI = value;
                if (value)
                {
                    if (_ainame == null)
                    {
                        _ainame = aiNames[new Random().Next(0, aiNames.Length)];
                    }

                    _playername = PlayerName;
                    playername.Text = _ainame;
                    playername.Enabled = false;
                }
                else
                {
                    playername.Text = _playername;
                    playername.Enabled = true;
                }
            }
        }

        public Playerinfo()
        {
            InitializeComponent();
        }

        private void chk_ai_CheckedChanged(object sender, EventArgs e)
        {
            this.isAI = chk_ai.Checked;
        }
    }
}
