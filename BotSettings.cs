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
    public partial class BotSettings : Form
    {
        public string Difficulty { get; private set; }
        public string Speed { get; private set; }

        public BotSettings()
        {
            InitializeComponent();
            comboDifficulty.SelectedIndex = 1;
            comboSpeed.SelectedIndex = 1;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Difficulty = comboDifficulty.Text;
            this.Speed = comboSpeed.Text;
        }
    }
}
