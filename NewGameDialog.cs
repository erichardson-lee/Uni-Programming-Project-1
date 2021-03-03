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
    public partial class NewGameDialog : Form
    {
        public int ColumnCount
        {
            get
            {
                return decimal.ToInt32(num_width.Value);
            }
        }
        public int RowCount
        {
            get
            {
                return decimal.ToInt32(num_height.Value);
            }
        }

        public NewGameDialog()
        {
            InitializeComponent();
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
