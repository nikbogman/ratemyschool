namespace WinFormsApp.Forms
{
    partial class UserForm
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
            bannLbl = new Label();
            label2 = new Label();
            emailLbl = new Label();
            passwordLbl = new Label();
            birthyearLbl = new Label();
            emailTextBox = new TextBox();
            passwordTextBox = new TextBox();
            birthyearTextBox = new TextBox();
            dateTimePicker = new DateTimePicker();
            roleComboBox = new ComboBox();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // execBtn
            // 
            execBtn.Location = new Point(10, 208);
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
            tableLayoutPanel1.Controls.Add(bannLbl, 0, 4);
            tableLayoutPanel1.Controls.Add(label2, 0, 3);
            tableLayoutPanel1.Controls.Add(emailLbl, 0, 0);
            tableLayoutPanel1.Controls.Add(passwordLbl, 0, 1);
            tableLayoutPanel1.Controls.Add(birthyearLbl, 0, 2);
            tableLayoutPanel1.Controls.Add(emailTextBox, 1, 0);
            tableLayoutPanel1.Controls.Add(passwordTextBox, 1, 1);
            tableLayoutPanel1.Controls.Add(birthyearTextBox, 1, 2);
            tableLayoutPanel1.Controls.Add(dateTimePicker, 1, 4);
            tableLayoutPanel1.Controls.Add(roleComboBox, 1, 3);
            tableLayoutPanel1.Location = new Point(12, 12);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 5;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            tableLayoutPanel1.Size = new Size(241, 190);
            tableLayoutPanel1.TabIndex = 4;
            // 
            // bannLbl
            // 
            bannLbl.AutoSize = true;
            bannLbl.Dock = DockStyle.Fill;
            bannLbl.Location = new Point(3, 152);
            bannLbl.Name = "bannLbl";
            bannLbl.Size = new Size(90, 38);
            bannLbl.TabIndex = 14;
            bannLbl.Text = "Banned until:";
            bannLbl.TextAlign = ContentAlignment.MiddleRight;
            bannLbl.Visible = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Location = new Point(3, 114);
            label2.Name = "label2";
            label2.Size = new Size(90, 38);
            label2.TabIndex = 13;
            label2.Text = "Role:";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // emailLbl
            // 
            emailLbl.AutoSize = true;
            emailLbl.Dock = DockStyle.Fill;
            emailLbl.Location = new Point(3, 0);
            emailLbl.Name = "emailLbl";
            emailLbl.Size = new Size(90, 38);
            emailLbl.TabIndex = 1;
            emailLbl.Text = "Email:";
            emailLbl.TextAlign = ContentAlignment.MiddleRight;
            // 
            // passwordLbl
            // 
            passwordLbl.AutoSize = true;
            passwordLbl.Dock = DockStyle.Fill;
            passwordLbl.Location = new Point(3, 38);
            passwordLbl.Name = "passwordLbl";
            passwordLbl.Size = new Size(90, 38);
            passwordLbl.TabIndex = 3;
            passwordLbl.Text = "Password:";
            passwordLbl.TextAlign = ContentAlignment.MiddleRight;
            // 
            // birthyearLbl
            // 
            birthyearLbl.AutoSize = true;
            birthyearLbl.Dock = DockStyle.Fill;
            birthyearLbl.Location = new Point(3, 76);
            birthyearLbl.Name = "birthyearLbl";
            birthyearLbl.Size = new Size(90, 38);
            birthyearLbl.TabIndex = 4;
            birthyearLbl.Text = "Birth year:";
            birthyearLbl.TextAlign = ContentAlignment.MiddleRight;
            // 
            // emailTextBox
            // 
            emailTextBox.Anchor = AnchorStyles.Left;
            emailTextBox.Location = new Point(99, 7);
            emailTextBox.Name = "emailTextBox";
            emailTextBox.Size = new Size(126, 23);
            emailTextBox.TabIndex = 7;
            // 
            // passwordTextBox
            // 
            passwordTextBox.Anchor = AnchorStyles.Left;
            passwordTextBox.Location = new Point(99, 45);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.Size = new Size(126, 23);
            passwordTextBox.TabIndex = 9;
            // 
            // birthyearTextBox
            // 
            birthyearTextBox.Anchor = AnchorStyles.Left;
            birthyearTextBox.Location = new Point(99, 83);
            birthyearTextBox.Name = "birthyearTextBox";
            birthyearTextBox.Size = new Size(126, 23);
            birthyearTextBox.TabIndex = 10;
            // 
            // dateTimePicker
            // 
            dateTimePicker.Location = new Point(99, 155);
            dateTimePicker.MinDate = new DateTime(2023, 5, 25, 23, 59, 59, 0);
            dateTimePicker.Name = "dateTimePicker";
            dateTimePicker.Size = new Size(139, 23);
            dateTimePicker.TabIndex = 15;
            dateTimePicker.Visible = false;
            // 
            // roleComboBox
            // 
            roleComboBox.Dock = DockStyle.Fill;
            roleComboBox.FormattingEnabled = true;
            roleComboBox.Location = new Point(99, 117);
            roleComboBox.Name = "roleComboBox";
            roleComboBox.Size = new Size(139, 23);
            roleComboBox.TabIndex = 16;
            // 
            // UserForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(266, 248);
            Controls.Add(execBtn);
            Controls.Add(tableLayoutPanel1);
            Name = "UserForm";
            Text = "UserForm";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button execBtn;
        private TableLayoutPanel tableLayoutPanel1;
        private Label emailLbl;
        private Label passwordLbl;
        private Label birthyearLbl;
        private TextBox emailTextBox;
        private TextBox passwordTextBox;
        private TextBox birthyearTextBox;
        private Label bannLbl;
        private Label label2;
        private DateTimePicker dateTimePicker;
        private ComboBox roleComboBox;
    }
}