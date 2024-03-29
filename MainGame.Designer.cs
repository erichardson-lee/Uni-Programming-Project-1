﻿using Gamegrid;

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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainGame));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.playerinfo2 = new O_Neillo.Playerinfo();
            this.aiThoughtTimer2 = new System.Windows.Forms.Timer(this.components);
            this.playerinfo1 = new O_Neillo.Playerinfo();
            this.aiThoughtTimer1 = new System.Windows.Forms.Timer(this.components);
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
            this.txt_speech = new System.Windows.Forms.ToolStripTextBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tableLayoutPanel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.playerinfo2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.playerinfo1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.gameGrid1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 27);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(667, 764);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // playerinfo2
            // 
            this.playerinfo2.AItimer = this.aiThoughtTimer2;
            this.playerinfo2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.playerinfo2.CellValue = O_Neillo.CellValues.white;
            this.playerinfo2.Dock = System.Windows.Forms.DockStyle.Right;
            this.playerinfo2.isAI = false;
            this.playerinfo2.Location = new System.Drawing.Point(336, 673);
            this.playerinfo2.Name = "playerinfo2";
            this.playerinfo2.PlayerIcon = global::O_Neillo.Properties.Resources.GridWhite;
            this.playerinfo2.PlayerName = "";
            this.playerinfo2.PlayerTurn = false;
            this.playerinfo2.Size = new System.Drawing.Size(328, 88);
            this.playerinfo2.TabIndex = 5;
            this.playerinfo2.Tokens = 0;
            // 
            // aiThoughtTimer2
            // 
            this.aiThoughtTimer2.Tick += new System.EventHandler(this.aithoughtTimer2_Tick);
            // 
            // playerinfo1
            // 
            this.playerinfo1.AItimer = this.aiThoughtTimer1;
            this.playerinfo1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.playerinfo1.CellValue = O_Neillo.CellValues.black;
            this.playerinfo1.Dock = System.Windows.Forms.DockStyle.Left;
            this.playerinfo1.isAI = false;
            this.playerinfo1.Location = new System.Drawing.Point(3, 673);
            this.playerinfo1.Name = "playerinfo1";
            this.playerinfo1.PlayerIcon = global::O_Neillo.Properties.Resources.GridBlack;
            this.playerinfo1.PlayerName = "";
            this.playerinfo1.PlayerTurn = false;
            this.playerinfo1.Size = new System.Drawing.Size(327, 88);
            this.playerinfo1.TabIndex = 6;
            this.playerinfo1.Tokens = 0;
            // 
            // aiThoughtTimer1
            // 
            this.aiThoughtTimer1.Interval = 20;
            this.aiThoughtTimer1.Tick += new System.EventHandler(this.aiThoughtTimer1_Tick);
            // 
            // gameGrid1
            // 
            this.gameGrid1.Columns = 8;
            this.tableLayoutPanel1.SetColumnSpan(this.gameGrid1, 2);
            this.gameGrid1.DefaultImage = global::O_Neillo.Properties.Resources.GridBase;
            this.gameGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gameGrid1.Location = new System.Drawing.Point(3, 3);
            this.gameGrid1.Name = "gameGrid1";
            this.gameGrid1.Rows = 8;
            this.gameGrid1.Size = new System.Drawing.Size(661, 664);
            this.gameGrid1.TabIndex = 7;
            this.gameGrid1.CellPressed += new Gamegrid.CellPressedEventHandler(this.gameGrid1_CellPressed);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.helpToolStripMenuItem,
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
            this.startGameToolStripMenuItem.Click += new System.EventHandler(this.newGame_Click);
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
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadBtn_Click);
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
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitBtn_click);
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
            this.chk_speak.CheckOnClick = true;
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
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpBtn_Click);
            // 
            // txt_speech
            // 
            this.txt_speech.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.txt_speech.Enabled = false;
            this.txt_speech.Name = "txt_speech";
            this.txt_speech.Size = new System.Drawing.Size(400, 23);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "ej";
            this.saveFileDialog1.FileName = "O\'NeilloSave.ej";
            this.saveFileDialog1.Filter = "\"O\'neillo Saves\"|*.ej|\"All Files\"|*.*";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "*.ej";
            this.openFileDialog1.Filter = "\"O\'neillo Saves\"|*.ej|\"All Files\"|*.*";
            // 
            // MainGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(667, 791);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(683, 830);
            this.Name = "MainGame";
            this.Text = "O\'Neillo";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
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
        private System.Windows.Forms.ToolStripTextBox txt_speech;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private GameGrid gameGrid1;
        private System.Windows.Forms.Timer aiThoughtTimer1;
        private System.Windows.Forms.Timer aiThoughtTimer2;
        private Playerinfo playerinfo2;
        private Playerinfo playerinfo1;
    }
}

