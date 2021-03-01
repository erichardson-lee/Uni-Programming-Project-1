
namespace Gamegrid
{
    partial class GameGrid
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbl_gameGrid = new System.Windows.Forms.TableLayoutPanel();
            this.tbl_centerformat = new System.Windows.Forms.TableLayoutPanel();
            this.tbl_centerformat.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbl_gameGrid
            // 
            this.tbl_gameGrid.ColumnCount = 2;
            this.tbl_gameGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tbl_gameGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tbl_gameGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbl_gameGrid.Location = new System.Drawing.Point(246, 17);
            this.tbl_gameGrid.Margin = new System.Windows.Forms.Padding(0);
            this.tbl_gameGrid.Name = "tbl_gameGrid";
            this.tbl_gameGrid.RowCount = 2;
            this.tbl_gameGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tbl_gameGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tbl_gameGrid.Size = new System.Drawing.Size(500, 500);
            this.tbl_gameGrid.TabIndex = 0;
            // 
            // tbl_centerformat
            // 
            this.tbl_centerformat.ColumnCount = 3;
            this.tbl_centerformat.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tbl_centerformat.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tbl_centerformat.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tbl_centerformat.Controls.Add(this.tbl_gameGrid, 1, 1);
            this.tbl_centerformat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbl_centerformat.Location = new System.Drawing.Point(0, 0);
            this.tbl_centerformat.Name = "tbl_centerformat";
            this.tbl_centerformat.RowCount = 3;
            this.tbl_centerformat.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tbl_centerformat.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tbl_centerformat.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tbl_centerformat.Size = new System.Drawing.Size(993, 534);
            this.tbl_centerformat.TabIndex = 1;
            this.tbl_centerformat.Paint += new System.Windows.Forms.PaintEventHandler(this.tbl_centerformat_Paint);
            // 
            // GameGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbl_centerformat);
            this.Name = "GameGrid";
            this.Size = new System.Drawing.Size(993, 534);
            this.tbl_centerformat.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tbl_gameGrid;
        private System.Windows.Forms.TableLayoutPanel tbl_centerformat;
    }
}
