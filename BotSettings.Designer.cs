
namespace O_Neillo
{
    partial class BotSettings
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
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboDifficulty = new System.Windows.Forms.ComboBox();
            this.comboSpeed = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.btn_save, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btn_cancel, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.comboDifficulty, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.comboSpeed, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(267, 91);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btn_save
            // 
            this.btn_save.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_save.Location = new System.Drawing.Point(3, 65);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(127, 23);
            this.btn_save.TabIndex = 0;
            this.btn_save.Text = "Save";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_cancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_cancel.Location = new System.Drawing.Point(136, 65);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(128, 23);
            this.btn_cancel.TabIndex = 1;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 31);
            this.label1.TabIndex = 2;
            this.label1.Text = "Bot Difficulty";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 31);
            this.label2.TabIndex = 3;
            this.label2.Text = "Bot Speed";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comboDifficulty
            // 
            this.comboDifficulty.AllowDrop = true;
            this.comboDifficulty.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboDifficulty.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboDifficulty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboDifficulty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDifficulty.FormattingEnabled = true;
            this.comboDifficulty.Items.AddRange(new object[] {
            "Easy",
            "Normal",
            "Hard",
            "Random"});
            this.comboDifficulty.Location = new System.Drawing.Point(136, 3);
            this.comboDifficulty.Name = "comboDifficulty";
            this.comboDifficulty.Size = new System.Drawing.Size(128, 21);
            this.comboDifficulty.TabIndex = 4;
            // 
            // comboSpeed
            // 
            this.comboSpeed.AllowDrop = true;
            this.comboSpeed.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboSpeed.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboSpeed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboSpeed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSpeed.FormattingEnabled = true;
            this.comboSpeed.Items.AddRange(new object[] {
            "Slow",
            "Fast",
            "Super Fast"});
            this.comboSpeed.Location = new System.Drawing.Point(136, 34);
            this.comboSpeed.Name = "comboSpeed";
            this.comboSpeed.Size = new System.Drawing.Size(128, 21);
            this.comboSpeed.TabIndex = 5;
            // 
            // BotSettings
            // 
            this.AcceptButton = this.btn_save;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_cancel;
            this.ClientSize = new System.Drawing.Size(267, 91);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "BotSettings";
            this.Text = "Bot Controls";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboDifficulty;
        private System.Windows.Forms.ComboBox comboSpeed;
    }
}