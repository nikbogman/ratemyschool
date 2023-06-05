namespace WinFormsApp.Forms.SchoolForms
{
    partial class STEMSchoolForm
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
            studyLbl = new Label();
            entryAsmntLbl = new Label();
            scoreLbl = new Label();
            nameTextBox = new TextBox();
            cityTextBox = new TextBox();
            numericUpDown = new NumericUpDown();
            studyTextBox = new TextBox();
            scoreUpDown = new NumericUpDown();
            entryAsmntCheckBox = new CheckBox();
            viewStatsBtn = new Button();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)scoreUpDown).BeginInit();
            SuspendLayout();
            // 
            // execBtn
            // 
            execBtn.Location = new Point(12, 280);
            execBtn.Name = "execBtn";
            execBtn.Size = new Size(240, 30);
            execBtn.TabIndex = 5;
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
            tableLayoutPanel1.Controls.Add(studyLbl, 0, 3);
            tableLayoutPanel1.Controls.Add(entryAsmntLbl, 0, 4);
            tableLayoutPanel1.Controls.Add(scoreLbl, 0, 5);
            tableLayoutPanel1.Controls.Add(nameTextBox, 1, 0);
            tableLayoutPanel1.Controls.Add(cityTextBox, 1, 1);
            tableLayoutPanel1.Controls.Add(numericUpDown, 1, 2);
            tableLayoutPanel1.Controls.Add(studyTextBox, 1, 3);
            tableLayoutPanel1.Controls.Add(scoreUpDown, 1, 5);
            tableLayoutPanel1.Controls.Add(entryAsmntCheckBox, 1, 4);
            tableLayoutPanel1.Location = new Point(12, 12);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 6;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            tableLayoutPanel1.Size = new Size(241, 224);
            tableLayoutPanel1.TabIndex = 4;
            // 
            // nameLbl
            // 
            nameLbl.AutoSize = true;
            nameLbl.Dock = DockStyle.Fill;
            nameLbl.Location = new Point(3, 0);
            nameLbl.Name = "nameLbl";
            nameLbl.Size = new Size(90, 38);
            nameLbl.TabIndex = 0;
            nameLbl.Text = "Name:";
            nameLbl.TextAlign = ContentAlignment.MiddleRight;
            // 
            // cityLbl
            // 
            cityLbl.AutoSize = true;
            cityLbl.Dock = DockStyle.Fill;
            cityLbl.Location = new Point(3, 38);
            cityLbl.Name = "cityLbl";
            cityLbl.Size = new Size(90, 38);
            cityLbl.TabIndex = 1;
            cityLbl.Text = "City:";
            cityLbl.TextAlign = ContentAlignment.MiddleRight;
            // 
            // numberLbl
            // 
            numberLbl.AutoSize = true;
            numberLbl.Dock = DockStyle.Fill;
            numberLbl.Location = new Point(3, 76);
            numberLbl.Name = "numberLbl";
            numberLbl.Size = new Size(90, 38);
            numberLbl.TabIndex = 2;
            numberLbl.Text = "Number:";
            numberLbl.TextAlign = ContentAlignment.MiddleRight;
            // 
            // studyLbl
            // 
            studyLbl.AutoSize = true;
            studyLbl.Dock = DockStyle.Fill;
            studyLbl.Location = new Point(3, 114);
            studyLbl.Name = "studyLbl";
            studyLbl.Size = new Size(90, 38);
            studyLbl.TabIndex = 3;
            studyLbl.Text = "Study:";
            studyLbl.TextAlign = ContentAlignment.MiddleRight;
            // 
            // entryAsmntLbl
            // 
            entryAsmntLbl.AutoSize = true;
            entryAsmntLbl.Dock = DockStyle.Fill;
            entryAsmntLbl.Location = new Point(3, 152);
            entryAsmntLbl.Name = "entryAsmntLbl";
            entryAsmntLbl.Size = new Size(90, 38);
            entryAsmntLbl.TabIndex = 4;
            entryAsmntLbl.Text = "Entry assessment:";
            entryAsmntLbl.TextAlign = ContentAlignment.MiddleRight;
            // 
            // scoreLbl
            // 
            scoreLbl.AutoSize = true;
            scoreLbl.Dock = DockStyle.Fill;
            scoreLbl.Location = new Point(3, 190);
            scoreLbl.Name = "scoreLbl";
            scoreLbl.Size = new Size(90, 38);
            scoreLbl.TabIndex = 5;
            scoreLbl.Text = "Score requirement:";
            scoreLbl.TextAlign = ContentAlignment.MiddleRight;
            // 
            // nameTextBox
            // 
            nameTextBox.Anchor = AnchorStyles.Left;
            nameTextBox.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            nameTextBox.Location = new Point(99, 7);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(126, 23);
            nameTextBox.TabIndex = 6;
            // 
            // cityTextBox
            // 
            cityTextBox.Anchor = AnchorStyles.Left;
            cityTextBox.Location = new Point(99, 45);
            cityTextBox.Name = "cityTextBox";
            cityTextBox.Size = new Size(126, 23);
            cityTextBox.TabIndex = 7;
            // 
            // numericUpDown
            // 
            numericUpDown.Anchor = AnchorStyles.Left;
            numericUpDown.Location = new Point(99, 83);
            numericUpDown.Name = "numericUpDown";
            numericUpDown.Size = new Size(126, 23);
            numericUpDown.TabIndex = 11;
            // 
            // studyTextBox
            // 
            studyTextBox.Anchor = AnchorStyles.Left;
            studyTextBox.Location = new Point(99, 121);
            studyTextBox.Name = "studyTextBox";
            studyTextBox.Size = new Size(126, 23);
            studyTextBox.TabIndex = 9;
            // 
            // scoreUpDown
            // 
            scoreUpDown.Anchor = AnchorStyles.Left;
            scoreUpDown.Location = new Point(99, 197);
            scoreUpDown.Name = "scoreUpDown";
            scoreUpDown.Size = new Size(126, 23);
            scoreUpDown.TabIndex = 12;
            // 
            // entryAsmntCheckBox
            // 
            entryAsmntCheckBox.AutoSize = true;
            entryAsmntCheckBox.Dock = DockStyle.Fill;
            entryAsmntCheckBox.Location = new Point(109, 155);
            entryAsmntCheckBox.Margin = new Padding(13, 3, 3, 3);
            entryAsmntCheckBox.Name = "entryAsmntCheckBox";
            entryAsmntCheckBox.Size = new Size(129, 32);
            entryAsmntCheckBox.TabIndex = 15;
            entryAsmntCheckBox.UseVisualStyleBackColor = true;
            // 
            // viewStatsBtn
            // 
            viewStatsBtn.Location = new Point(12, 244);
            viewStatsBtn.Name = "viewStatsBtn";
            viewStatsBtn.Size = new Size(240, 30);
            viewStatsBtn.TabIndex = 6;
            viewStatsBtn.Text = "View Statistics";
            viewStatsBtn.UseVisualStyleBackColor = true;
            // 
            // STEMSchoolForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(268, 323);
            Controls.Add(viewStatsBtn);
            Controls.Add(execBtn);
            Controls.Add(tableLayoutPanel1);
            Name = "STEMSchoolForm";
            Text = "STEMSchoolForm";
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
        private Label studyLbl;
        private Label entryAsmntLbl;
        private Label scoreLbl;
        private TextBox nameTextBox;
        private TextBox cityTextBox;
        private NumericUpDown numericUpDown;
        private TextBox studyTextBox;
        private NumericUpDown scoreUpDown;
        private CheckBox entryAsmntCheckBox;
        private Button viewStatsBtn;
    }
}