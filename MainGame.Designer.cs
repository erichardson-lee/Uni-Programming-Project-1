using Gamegrid;

namespace O_Neillo
{
    partial class MainGame
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.playerinfo2 = new O_Neillo.Playerinfo();
            this.playerinfo1 = new O_Neillo.Playerinfo();
            this.gameGrid1 = new Gamegrid.GameGrid();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chk_speak = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.passToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txt_speech = new System.Windows.Forms.ToolStripTextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.gameGrid1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 27);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(667, 764);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.playerinfo2);
            this.panel1.Controls.Add(this.playerinfo1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 671);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(667, 93);
            this.panel1.TabIndex = 2;
            // 
            // playerinfo2
            // 
            this.playerinfo2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.playerinfo2.CellValue = O_Neillo.CellValues.white;
            this.playerinfo2.Location = new System.Drawing.Point(335, 3);
            this.playerinfo2.Name = "playerinfo2";
            this.playerinfo2.PlayerIcon = global::O_Neillo.Properties.Resources.GridWhite;
            this.playerinfo2.PlayerTurn = false;
            this.playerinfo2.Size = new System.Drawing.Size(329, 87);
            this.playerinfo2.TabIndex = 1;
            this.playerinfo2.Tokens = 0;
            // 
            // playerinfo1
            // 
            this.playerinfo1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.playerinfo1.CellValue = O_Neillo.CellValues.black;
            this.playerinfo1.Location = new System.Drawing.Point(3, 3);
            this.playerinfo1.Name = "playerinfo1";
            this.playerinfo1.PlayerIcon = global::O_Neillo.Properties.Resources.GridBlack;
            this.playerinfo1.PlayerTurn = false;
            this.playerinfo1.Size = new System.Drawing.Size(329, 87);
            this.playerinfo1.TabIndex = 0;
            this.playerinfo1.Tokens = 0;
            // 
            // gameGrid1
            // 
            this.gameGrid1.Columns = 8;
            this.gameGrid1.DefaultImage = global::O_Neillo.Properties.Resources.GridBase;
            this.gameGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gameGrid1.Location = new System.Drawing.Point(0, 0);
            this.gameGrid1.Margin = new System.Windows.Forms.Padding(0);
            this.gameGrid1.Name = "gameGrid1";
            this.gameGrid1.Rows = 8;
            this.gameGrid1.Size = new System.Drawing.Size(667, 671);
            this.gameGrid1.TabIndex = 3;
            this.gameGrid1.CellPressed += new Gamegrid.CellPressedEventHandler(this.gameGrid1_CellPressed);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.passToolStripMenuItem,
            this.txt_speech});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(667, 27);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // gameToolStripMenuItem
            // 
            this.gameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startGameToolStripMenuItem,
            this.toolStripSeparator1,
            this.saveToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            this.gameToolStripMenuItem.Size = new System.Drawing.Size(50, 23);
            this.gameToolStripMenuItem.Text = "Game";
            // 
            // startGameToolStripMenuItem
            // 
            this.startGameToolStripMenuItem.Name = "startGameToolStripMenuItem";
            this.startGameToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.startGameToolStripMenuItem.Text = "Start Game";
            this.startGameToolStripMenuItem.Click += new System.EventHandler(this.startGameToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(129, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.loadToolStripMenuItem.Text = "Load";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(129, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chk_speak});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 23);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // chk_speak
            // 
            this.chk_speak.Checked = true;
            this.chk_speak.CheckOnClick = true;
            this.chk_speak.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_speak.Name = "chk_speak";
            this.chk_speak.Size = new System.Drawing.Size(105, 22);
            this.chk_speak.Text = "Speak";
            this.chk_speak.Click += new System.EventHandler(this.chk_speak_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 23);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // passToolStripMenuItem
            // 
            this.passToolStripMenuItem.Name = "passToolStripMenuItem";
            this.passToolStripMenuItem.Size = new System.Drawing.Size(42, 23);
            this.passToolStripMenuItem.Text = "Pass";
            this.passToolStripMenuItem.Click += new System.EventHandler(this.passBtn_click);
            // 
            // txt_speech
            // 
            this.txt_speech.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.txt_speech.AutoSize = false;
            this.txt_speech.Enabled = false;
            this.txt_speech.Name = "txt_speech";
            this.txt_speech.Size = new System.Drawing.Size(400, 23);
            // 
            // MainGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(667, 791);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.MinimumSize = new System.Drawing.Size(683, 830);
            this.Name = "MainGame";
            this.Text = "O\'Neillo";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem gameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chk_speak;
        private Gamegrid.GameGrid gameGrid1;
        private Playerinfo playerinfo2;
        private Playerinfo playerinfo1;
        private System.Windows.Forms.ToolStripMenuItem passToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox txt_speech;
    }
}

