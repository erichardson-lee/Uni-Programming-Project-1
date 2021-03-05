
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
            this.grid_picturebox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.grid_picturebox)).BeginInit();
            this.SuspendLayout();
            // 
            // grid_picturebox
            // 
            this.grid_picturebox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid_picturebox.Image = global::O_Neillo.Properties.Resources.GameBoard;
            this.grid_picturebox.Location = new System.Drawing.Point(0, 0);
            this.grid_picturebox.Name = "grid_picturebox";
            this.grid_picturebox.Size = new System.Drawing.Size(993, 534);
            this.grid_picturebox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.grid_picturebox.TabIndex = 1;
            this.grid_picturebox.TabStop = false;
            this.grid_picturebox.Click += new System.EventHandler(this.grid_picturebox_Click);
            // 
            // GameGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grid_picturebox);
            this.Name = "GameGrid";
            this.Size = new System.Drawing.Size(993, 534);
            ((System.ComponentModel.ISupportInitialize)(this.grid_picturebox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox grid_picturebox;
    }
}
