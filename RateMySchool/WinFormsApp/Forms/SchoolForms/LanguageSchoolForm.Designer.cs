using Mysqlx.Prepare;

namespace WinFormsApp.Forms.SchoolForms
{
    partial class LanguageSchoolForm
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
            execBtn = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            nameLbl = new Label();
            cityLbl = new Label();
            numberLbl = new Label();
            prLangLbl = new Label();
            secLangLbl = new Label();
            scoreLbl = new Label();
            nameTextBox = new TextBox();
            cityTextBox = new TextBox();
            numericUpDown = new NumericUpDown();
            prLangTextBox = new TextBox();
            secLangTextBox = new TextBox();
            scoreUpDown = new NumericUpDown();
            viewStatsBtn = new Button();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)scoreUpDown).BeginInit();
            SuspendLayout();
            // 
            // execBtn
            // 
            execBtn.Location = new Point(15, 368);
            execBtn.Margin = new Padding(3, 4, 3, 4);
            execBtn.Name = "execBtn";
            execBtn.Size = new Size(274, 40);
            execBtn.TabIndex = 3;
            execBtn.Text = "Save or Close";
            execBtn.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            tableLayoutPanel1.Controls.Add(nameLbl, 0, 0);
            tableLayoutPanel1.Controls.Add(cityLbl, 0, 1);
            tableLayoutPanel1.Controls.Add(numberLbl, 0, 2);
            tableLayoutPanel1.Controls.Add(prLangLbl, 0, 3);
            tableLayoutPanel1.Controls.Add(secLangLbl, 0, 4);
            tableLayoutPanel1.Controls.Add(scoreLbl, 0, 5);
            tableLayoutPanel1.Controls.Add(nameTextBox, 1, 0);
            tableLayoutPanel1.Controls.Add(cityTextBox, 1, 1);
            tableLayoutPanel1.Controls.Add(numericUpDown, 1, 2);
            tableLayoutPanel1.Controls.Add(prLangTextBox, 1, 3);
            tableLayoutPanel1.Controls.Add(secLangTextBox, 1, 4);
            tableLayoutPanel1.Controls.Add(scoreUpDown, 1, 5);
            tableLayoutPanel1.Location = new Point(11, 13);
            tableLayoutPanel1.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 7;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 51F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 51F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 51F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 51F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 51F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 51F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 51F));
            tableLayoutPanel1.Size = new Size(275, 299);
            tableLayoutPanel1.TabIndex = 2;
            // 
            // nameLbl
            // 
            nameLbl.AutoSize = true;
            nameLbl.Dock = DockStyle.Fill;
            nameLbl.Location = new Point(3, 0);
            nameLbl.Name = "nameLbl";
            nameLbl.Size = new Size(104, 51);
            nameLbl.TabIndex = 0;
            nameLbl.Text = "Name:";
            nameLbl.TextAlign = ContentAlignment.MiddleRight;
            // 
            // cityLbl
            // 
            cityLbl.AutoSize = true;
            cityLbl.Dock = DockStyle.Fill;
            cityLbl.Location = new Point(3, 51);
            cityLbl.Name = "cityLbl";
            cityLbl.Size = new Size(104, 51);
            cityLbl.TabIndex = 1;
            cityLbl.Text = "City:";
            cityLbl.TextAlign = ContentAlignment.MiddleRight;
            // 
            // numberLbl
            // 
            numberLbl.AutoSize = true;
            numberLbl.Dock = DockStyle.Fill;
            numberLbl.Location = new Point(3, 102);
            numberLbl.Name = "numberLbl";
            numberLbl.Size = new Size(104, 51);
            numberLbl.TabIndex = 2;
            numberLbl.Text = "Number:";
            numberLbl.TextAlign = ContentAlignment.MiddleRight;
            // 
            // prLangLbl
            // 
            prLangLbl.AutoSize = true;
            prLangLbl.Dock = DockStyle.Fill;
            prLangLbl.Location = new Point(3, 153);
            prLangLbl.Name = "prLangLbl";
            prLangLbl.Size = new Size(104, 51);
            prLangLbl.TabIndex = 3;
            prLangLbl.Text = "Primary language:";
            prLangLbl.TextAlign = ContentAlignment.MiddleRight;
            // 
            // secLangLbl
            // 
            secLangLbl.AutoSize = true;
            secLangLbl.Dock = DockStyle.Fill;
            secLangLbl.Location = new Point(3, 204);
            secLangLbl.Name = "secLangLbl";
            secLangLbl.Size = new Size(104, 51);
            secLangLbl.TabIndex = 4;
            secLangLbl.Text = "Secondary language:";
            secLangLbl.TextAlign = ContentAlignment.MiddleRight;
            // 
            // scoreLbl
            // 
            scoreLbl.AutoSize = true;
            scoreLbl.Dock = DockStyle.Fill;
            scoreLbl.Location = new Point(3, 255);
            scoreLbl.Name = "scoreLbl";
            scoreLbl.Size = new Size(104, 51);
            scoreLbl.TabIndex = 5;
            scoreLbl.Text = "Score requirement:";
            scoreLbl.TextAlign = ContentAlignment.MiddleRight;
            // 
            // nameTextBox
            // 
            nameTextBox.Anchor = AnchorStyles.Left;
            nameTextBox.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            nameTextBox.Location = new Point(113, 12);
            nameTextBox.Margin = new Padding(3, 4, 3, 4);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(143, 27);
            nameTextBox.TabIndex = 6;
            // 
            // cityTextBox
            // 
            cityTextBox.Anchor = AnchorStyles.Left;
            cityTextBox.Location = new Point(113, 63);
            cityTextBox.Margin = new Padding(3, 4, 3, 4);
            cityTextBox.Name = "cityTextBox";
            cityTextBox.Size = new Size(143, 27);
            cityTextBox.TabIndex = 7;
            // 
            // numericUpDown
            // 
            numericUpDown.Anchor = AnchorStyles.Left;
            numericUpDown.Location = new Point(113, 114);
            numericUpDown.Margin = new Padding(3, 4, 3, 4);
            numericUpDown.Name = "numericUpDown";
            numericUpDown.Size = new Size(144, 27);
            numericUpDown.TabIndex = 11;
            // 
            // prLangTextBox
            // 
            prLangTextBox.Anchor = AnchorStyles.Left;
            prLangTextBox.Location = new Point(113, 165);
            prLangTextBox.Margin = new Padding(3, 4, 3, 4);
            prLangTextBox.Name = "prLangTextBox";
            prLangTextBox.Size = new Size(143, 27);
            prLangTextBox.TabIndex = 9;
            // 
            // secLangTextBox
            // 
            secLangTextBox.Anchor = AnchorStyles.Left;
            secLangTextBox.Location = new Point(113, 216);
            secLangTextBox.Margin = new Padding(3, 4, 3, 4);
            secLangTextBox.Name = "secLangTextBox";
            secLangTextBox.Size = new Size(143, 27);
            secLangTextBox.TabIndex = 10;
            // 
            // scoreUpDown
            // 
            scoreUpDown.Anchor = AnchorStyles.Left;
            scoreUpDown.Location = new Point(113, 267);
            scoreUpDown.Margin = new Padding(3, 4, 3, 4);
            scoreUpDown.Name = "scoreUpDown";
            scoreUpDown.Size = new Size(144, 27);
            scoreUpDown.TabIndex = 12;
            // 
            // viewStatsBtn
            // 
            viewStatsBtn.Location = new Point(15, 321);
            viewStatsBtn.Margin = new Padding(3, 4, 3, 4);
            viewStatsBtn.Name = "viewStatsBtn";
            viewStatsBtn.Size = new Size(274, 40);
            viewStatsBtn.TabIndex = 4;
            viewStatsBtn.Text = "View Statistics";
            viewStatsBtn.UseVisualStyleBackColor = true;
            viewStatsBtn.Visible = false;
            // 
            // LanguageSchoolForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(304, 423);
            Controls.Add(viewStatsBtn);
            Controls.Add(execBtn);
            Controls.Add(tableLayoutPanel1);
            Name = "LanguageSchoolForm";
            Text = "LanguageSchoolForm";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)scoreUpDown).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button execBtn;
        private TableLayoutPanel tableLayoutPanel1;
        private Label nameLbl;
        private Label cityLbl;
        private Label numberLbl;
        private Label prLangLbl;
        private Label secLangLbl;
        private Label scoreLbl;
        private TextBox cityTextBox;
        private TextBox prLangTextBox;
        private TextBox secLangTextBox;
        private TextBox nameTextBox;
        private NumericUpDown numericUpDown;
        private NumericUpDown scoreUpDown;
        private Button viewStatsBtn;
    }
}