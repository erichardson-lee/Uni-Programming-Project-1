
namespace O_Neillo
{
    partial class Playerinfo
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
            this.presentTokens = new System.Windows.Forms.Label();
            this.playername = new System.Windows.Forms.TextBox();
            this.img_playerIcon = new System.Windows.Forms.PictureBox();
            this.CurrentPlayer = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.img_playerIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CurrentPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // presentTokens
            // 
            this.presentTokens.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.presentTokens.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.presentTokens.Location = new System.Drawing.Point(3, 3);
            this.presentTokens.Margin = new System.Windows.Forms.Padding(3);
            this.presentTokens.Name = "presentTokens";
            this.presentTokens.Size = new System.Drawing.Size(92, 81);
            this.presentTokens.TabIndex = 0;
            this.presentTokens.Text = "0x";
            this.presentTokens.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // playername
            // 
            this.playername.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.playername.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.playername.Location = new System.Drawing.Point(151, 40);
            this.playername.Name = "playername";
            this.playername.Size = new System.Drawing.Size(175, 44);
            this.playername.TabIndex = 1;
            // 
            // img_playerIcon
            // 
            this.img_playerIcon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.img_playerIcon.Location = new System.Drawing.Point(101, 40);
            this.img_playerIcon.Name = "img_playerIcon";
            this.img_playerIcon.Size = new System.Drawing.Size(44, 44);
            this.img_playerIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.img_playerIcon.TabIndex = 2;
            this.img_playerIcon.TabStop = false;
            // 
            // CurrentPlayer
            // 
            this.CurrentPlayer.Image = global::O_Neillo.Properties.Resources.Current_Player;
            this.CurrentPlayer.Location = new System.Drawing.Point(151, 3);
            this.CurrentPlayer.Name = "CurrentPlayer";
            this.CurrentPlayer.Size = new System.Drawing.Size(175, 31);
            this.CurrentPlayer.TabIndex = 3;
            this.CurrentPlayer.TabStop = false;
            this.CurrentPlayer.Visible = false;
            // 
            // Playerinfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CurrentPlayer);
            this.Controls.Add(this.img_playerIcon);
            this.Controls.Add(this.playername);
            this.Controls.Add(this.presentTokens);
            this.Name = "Playerinfo";
            this.Size = new System.Drawing.Size(329, 87);
            ((System.ComponentModel.ISupportInitialize)(this.img_playerIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CurrentPlayer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label presentTokens;
        private System.Windows.Forms.TextBox playername;
        private System.Windows.Forms.PictureBox img_playerIcon;
        private System.Windows.Forms.PictureBox CurrentPlayer;
    }
}
