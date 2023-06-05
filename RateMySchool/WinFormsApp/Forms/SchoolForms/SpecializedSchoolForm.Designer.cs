namespace WinFormsApp.Forms.SchoolForms
{
    partial class SpecializedSchoolForm
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
            specLbl = new Label();
            asmntLbl = new Label();
            nameTextBox = new TextBox();
            cityTextBox = new TextBox();
            numericUpDown = new NumericUpDown();
            specTextBox = new TextBox();
            asmntTextBox = new TextBox();
            viewStatsBtn = new Button();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown).BeginInit();
            SuspendLayout();
            // 
            // execBtn
            // 
            execBtn.Location = new Point(13, 243);
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
            tableLayoutPanel1.Controls.Add(specLbl, 0, 3);
            tableLayoutPanel1.Controls.Add(asmntLbl, 0, 4);
            tableLayoutPanel1.Controls.Add(nameTextBox, 1, 0);
            tableLayoutPanel1.Controls.Add(cityTextBox, 1, 1);
            tableLayoutPanel1.Controls.Add(numericUpDown, 1, 2);
            tableLayoutPanel1.Controls.Add(specTextBox, 1, 3);
            tableLayoutPanel1.Controls.Add(asmntTextBox, 1, 4);
            tableLayoutPanel1.Location = new Point(12, 12);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 7;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(241, 186);
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
            // specLbl
            // 
            specLbl.AutoSize = true;
            specLbl.Dock = DockStyle.Fill;
            specLbl.Location = new Point(3, 114);
            specLbl.Name = "specLbl";
            specLbl.Size = new Size(90, 38);
            specLbl.TabIndex = 3;
            specLbl.Text = "Specialization:";
            specLbl.TextAlign = ContentAlignment.MiddleRight;
            // 
            // asmntLbl
            // 
            asmntLbl.AutoSize = true;
            asmntLbl.Dock = DockStyle.Fill;
            asmntLbl.Location = new Point(3, 152);
            asmntLbl.Name = "asmntLbl";
            asmntLbl.Size = new Size(90, 38);
            asmntLbl.TabIndex = 4;
            asmntLbl.Text = "Assesment:";
            asmntLbl.TextAlign = ContentAlignment.MiddleRight;
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
            // specTextBox
            // 
            specTextBox.Anchor = AnchorStyles.Left;
            specTextBox.Location = new Point(99, 121);
            specTextBox.Name = "specTextBox";
            specTextBox.Size = new Size(126, 23);
            specTextBox.TabIndex = 9;
            // 
            // asmntTextBox
            // 
            asmntTextBox.Anchor = AnchorStyles.Left;
            asmntTextBox.Location = new Point(99, 159);
            asmntTextBox.Name = "asmntTextBox";
            asmntTextBox.Size = new Size(126, 23);
            asmntTextBox.TabIndex = 10;
            // 
            // viewStatsBtn
            // 
            viewStatsBtn.Location = new Point(12, 207);
            viewStatsBtn.Name = "viewStatsBtn";
            viewStatsBtn.Size = new Size(240, 30);
            viewStatsBtn.TabIndex = 6;
            viewStatsBtn.Text = "View Statistics";
            viewStatsBtn.UseVisualStyleBackColor = true;
            // 
            // SpecializedSchoolForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(271, 286);
            Controls.Add(viewStatsBtn);
            Controls.Add(execBtn);
            Controls.Add(tableLayoutPanel1);
            Name = "SpecializedSchoolForm";
            Text = "SpecializedSchoolForm";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button execBtn;
        private TableLayoutPanel tableLayoutPanel1;
        private Label nameLbl;
        private Label cityLbl;
        private Label numberLbl;
        private Label specLbl;
        private Label asmntLbl;
        private TextBox nameTextBox;
        private TextBox cityTextBox;
        private NumericUpDown numericUpDown;
        private TextBox specTextBox;
        private TextBox asmntTextBox;
        private Button viewStatsBtn;
    }
}