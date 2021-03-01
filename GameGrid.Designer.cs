
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
            this.SuspendLayout();
            // 
            // tbl_gameGrid
            // 
            this.tbl_gameGrid.ColumnCount = 2;
            this.tbl_gameGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tbl_gameGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tbl_gameGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbl_gameGrid.Location = new System.Drawing.Point(0, 0);
            this.tbl_gameGrid.Margin = new System.Windows.Forms.Padding(0);
            this.tbl_gameGrid.Name = "tbl_gameGrid";
            this.tbl_gameGrid.RowCount = 2;
            this.tbl_gameGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tbl_gameGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tbl_gameGrid.Size = new System.Drawing.Size(150, 150);
            this.tbl_gameGrid.TabIndex = 0;
            // 
            // GameGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbl_gameGrid);
            this.Name = "GameGrid";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tbl_gameGrid;
    }
}
