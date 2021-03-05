
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
            this.img_playerIcon = new System.Windows.Forms.PictureBox();
            this.CurrentPlayer = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.playername = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.chk_ai = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.img_playerIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CurrentPlayer)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // presentTokens
            // 
            this.presentTokens.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.presentTokens.AutoSize = true;
            this.presentTokens.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.presentTokens.Location = new System.Drawing.Point(0, 0);
            this.presentTokens.Margin = new System.Windows.Forms.Padding(0);
            this.presentTokens.MinimumSize = new System.Drawing.Size(63, 0);
            this.presentTokens.Name = "presentTokens";
            this.tableLayoutPanel1.SetRowSpan(this.presentTokens, 2);
            this.presentTokens.Size = new System.Drawing.Size(63, 88);
            this.presentTokens.TabIndex = 0;
            this.presentTokens.Text = "0x";
            this.presentTokens.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // img_playerIcon
            // 
            this.img_playerIcon.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.img_playerIcon.Image = global::O_Neillo.Properties.Resources.GridBase;
            this.img_playerIcon.Location = new System.Drawing.Point(63, 31);
            this.img_playerIcon.Margin = new System.Windows.Forms.Padding(0);
            this.img_playerIcon.Name = "img_playerIcon";
            this.img_playerIcon.Size = new System.Drawing.Size(45, 57);
            this.img_playerIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.img_playerIcon.TabIndex = 2;
            this.img_playerIcon.TabStop = false;
            // 
            // CurrentPlayer
            // 
            this.CurrentPlayer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CurrentPlayer.Image = global::O_Neillo.Properties.Resources.Current_Player;
            this.CurrentPlayer.Location = new System.Drawing.Point(108, 0);
            this.CurrentPlayer.Margin = new System.Windows.Forms.Padding(0);
            this.CurrentPlayer.MinimumSize = new System.Drawing.Size(175, 31);
            this.CurrentPlayer.Name = "CurrentPlayer";
            this.CurrentPlayer.Size = new System.Drawing.Size(204, 31);
            this.CurrentPlayer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.CurrentPlayer.TabIndex = 3;
            this.CurrentPlayer.TabStop = false;
            this.CurrentPlayer.Visible = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.img_playerIcon, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.CurrentPlayer, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.presentTokens, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.playername, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(312, 88);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // playername
            // 
            this.playername.Dock = System.Windows.Forms.DockStyle.Fill;
            this.playername.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playername.Location = new System.Drawing.Point(111, 34);
            this.playername.Name = "playername";
            this.playername.Size = new System.Drawing.Size(198, 26);
            this.playername.TabIndex = 5;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.chk_ai, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.button1, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(63, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(45, 31);
            this.tableLayoutPanel2.TabIndex = 6;
            // 
            // chk_ai
            // 
            this.chk_ai.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chk_ai.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.chk_ai.Location = new System.Drawing.Point(0, 0);
            this.chk_ai.Margin = new System.Windows.Forms.Padding(0);
            this.chk_ai.Name = "chk_ai";
            this.chk_ai.Size = new System.Drawing.Size(24, 31);
            this.chk_ai.TabIndex = 5;
            this.chk_ai.TabStop = false;
            this.chk_ai.Text = "AI";
            this.chk_ai.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.chk_ai.UseVisualStyleBackColor = true;
            this.chk_ai.CheckedChanged += new System.EventHandler(this.chk_ai_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(27, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(15, 23);
            this.button1.TabIndex = 6;
            this.button1.TabStop = false;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Playerinfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Playerinfo";
            this.Size = new System.Drawing.Size(312, 88);
            ((System.ComponentModel.ISupportInitialize)(this.img_playerIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CurrentPlayer)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label presentTokens;
        private System.Windows.Forms.PictureBox img_playerIcon;
        private System.Windows.Forms.PictureBox CurrentPlayer;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox playername;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.CheckBox chk_ai;
        private System.Windows.Forms.Button button1;
    }
}
