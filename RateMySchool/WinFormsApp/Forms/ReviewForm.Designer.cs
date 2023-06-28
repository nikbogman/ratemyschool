namespace WinFormsApp.Forms
{
    partial class ReviewForm
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
            reviewIdValueLbl = new Label();
            reviewLbl = new Label();
            button1 = new Button();
            tableLayoutPanel2 = new TableLayoutPanel();
            nameLbl = new Label();
            cityLbl = new Label();
            button3 = new Button();
            tableLayoutPanel4 = new TableLayoutPanel();
            ratingLbl = new Label();
            userIdLbl = new Label();
            schoolIdLbl = new Label();
            createdAtLbl = new Label();
            label1 = new Label();
            label2 = new Label();
            numberLbl = new Label();
            specLbl = new Label();
            asmntLbl = new Label();
            label7 = new Label();
            contentLbl = new Label();
            checkBox = new CheckBox();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            SuspendLayout();
            // 
            // execBtn
            // 
            execBtn.Location = new Point(280, 270);
            execBtn.Name = "execBtn";
            execBtn.Size = new Size(240, 30);
            execBtn.TabIndex = 7;
            execBtn.Text = "Save or Close";
            execBtn.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            tableLayoutPanel1.Controls.Add(reviewIdValueLbl, 1, 2);
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(200, 100);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // reviewIdValueLbl
            // 
            reviewIdValueLbl.AutoSize = true;
            reviewIdValueLbl.Dock = DockStyle.Fill;
            reviewIdValueLbl.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            reviewIdValueLbl.Location = new Point(83, 40);
            reviewIdValueLbl.Name = "reviewIdValueLbl";
            reviewIdValueLbl.Size = new Size(114, 60);
            reviewIdValueLbl.TabIndex = 5;
            reviewIdValueLbl.Text = "label5";
            reviewIdValueLbl.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // reviewLbl
            // 
            reviewLbl.AutoSize = true;
            reviewLbl.Dock = DockStyle.Fill;
            reviewLbl.Location = new Point(3, 0);
            reviewLbl.Name = "reviewLbl";
            reviewLbl.Size = new Size(74, 100);
            reviewLbl.TabIndex = 4;
            reviewLbl.Text = "Review Id:";
            reviewLbl.TextAlign = ContentAlignment.MiddleRight;
            // 
            // button1
            // 
            button1.Location = new Point(281, 326);
            button1.Name = "button1";
            button1.Size = new Size(240, 30);
            button1.TabIndex = 7;
            button1.Text = "Save or Close";
            button1.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            tableLayoutPanel2.Controls.Add(nameLbl, 0, 0);
            tableLayoutPanel2.Location = new Point(0, 0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Size = new Size(200, 100);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // nameLbl
            // 
            nameLbl.AutoSize = true;
            nameLbl.Dock = DockStyle.Fill;
            nameLbl.Location = new Point(3, 0);
            nameLbl.Name = "nameLbl";
            nameLbl.Size = new Size(74, 100);
            nameLbl.TabIndex = 0;
            nameLbl.Text = "Name:";
            nameLbl.TextAlign = ContentAlignment.MiddleRight;
            // 
            // cityLbl
            // 
            cityLbl.AutoSize = true;
            cityLbl.Dock = DockStyle.Fill;
            cityLbl.Location = new Point(3, 15);
            cityLbl.Name = "cityLbl";
            cityLbl.Size = new Size(74, 85);
            cityLbl.TabIndex = 1;
            cityLbl.Text = "City:";
            cityLbl.TextAlign = ContentAlignment.MiddleRight;
            // 
            // button3
            // 
            button3.Location = new Point(13, 243);
            button3.Name = "button3";
            button3.Size = new Size(240, 30);
            button3.TabIndex = 11;
            button3.Text = "Close";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 2;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            tableLayoutPanel4.Controls.Add(ratingLbl, 1, 5);
            tableLayoutPanel4.Controls.Add(userIdLbl, 1, 3);
            tableLayoutPanel4.Controls.Add(schoolIdLbl, 1, 2);
            tableLayoutPanel4.Controls.Add(createdAtLbl, 1, 1);
            tableLayoutPanel4.Controls.Add(label1, 0, 0);
            tableLayoutPanel4.Controls.Add(label2, 0, 1);
            tableLayoutPanel4.Controls.Add(numberLbl, 0, 2);
            tableLayoutPanel4.Controls.Add(specLbl, 0, 3);
            tableLayoutPanel4.Controls.Add(asmntLbl, 0, 4);
            tableLayoutPanel4.Controls.Add(label7, 0, 5);
            tableLayoutPanel4.Controls.Add(contentLbl, 1, 0);
            tableLayoutPanel4.Controls.Add(checkBox, 1, 4);
            tableLayoutPanel4.Location = new Point(12, 12);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 7;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.Size = new Size(241, 224);
            tableLayoutPanel4.TabIndex = 10;
            // 
            // ratingLbl
            // 
            ratingLbl.AutoSize = true;
            ratingLbl.Dock = DockStyle.Fill;
            ratingLbl.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            ratingLbl.Location = new Point(99, 190);
            ratingLbl.Name = "ratingLbl";
            ratingLbl.Size = new Size(139, 38);
            ratingLbl.TabIndex = 18;
            ratingLbl.Text = "label3";
            ratingLbl.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // userIdLbl
            // 
            userIdLbl.AutoSize = true;
            userIdLbl.Dock = DockStyle.Fill;
            userIdLbl.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            userIdLbl.Location = new Point(99, 114);
            userIdLbl.Name = "userIdLbl";
            userIdLbl.Size = new Size(139, 38);
            userIdLbl.TabIndex = 17;
            userIdLbl.Text = "label3";
            userIdLbl.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // schoolIdLbl
            // 
            schoolIdLbl.AutoSize = true;
            schoolIdLbl.Dock = DockStyle.Fill;
            schoolIdLbl.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            schoolIdLbl.Location = new Point(99, 76);
            schoolIdLbl.Name = "schoolIdLbl";
            schoolIdLbl.Size = new Size(139, 38);
            schoolIdLbl.TabIndex = 16;
            schoolIdLbl.Text = "label3";
            schoolIdLbl.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // createdAtLbl
            // 
            createdAtLbl.AutoSize = true;
            createdAtLbl.Dock = DockStyle.Fill;
            createdAtLbl.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            createdAtLbl.Location = new Point(99, 38);
            createdAtLbl.Name = "createdAtLbl";
            createdAtLbl.Size = new Size(139, 38);
            createdAtLbl.TabIndex = 15;
            createdAtLbl.Text = "label3";
            createdAtLbl.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(90, 38);
            label1.TabIndex = 0;
            label1.Text = "Content:";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Location = new Point(3, 38);
            label2.Name = "label2";
            label2.Size = new Size(90, 38);
            label2.TabIndex = 1;
            label2.Text = "Created at:";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // numberLbl
            // 
            numberLbl.AutoSize = true;
            numberLbl.Dock = DockStyle.Fill;
            numberLbl.Location = new Point(3, 76);
            numberLbl.Name = "numberLbl";
            numberLbl.Size = new Size(90, 38);
            numberLbl.TabIndex = 2;
            numberLbl.Text = "School ID:";
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
            specLbl.Text = "User ID:";
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
            asmntLbl.Text = "Reported:";
            asmntLbl.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Dock = DockStyle.Fill;
            label7.Location = new Point(3, 190);
            label7.Name = "label7";
            label7.Size = new Size(90, 38);
            label7.TabIndex = 12;
            label7.Text = "Rating:";
            label7.TextAlign = ContentAlignment.MiddleRight;
            // 
            // contentLbl
            // 
            contentLbl.AutoSize = true;
            contentLbl.Dock = DockStyle.Fill;
            contentLbl.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            contentLbl.Location = new Point(99, 0);
            contentLbl.Name = "contentLbl";
            contentLbl.Size = new Size(139, 38);
            contentLbl.TabIndex = 13;
            contentLbl.Text = "label3";
            contentLbl.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // checkBox
            // 
            checkBox.AutoSize = true;
            checkBox.Dock = DockStyle.Fill;
            checkBox.Enabled = false;
            checkBox.Location = new Point(109, 155);
            checkBox.Margin = new Padding(13, 3, 3, 3);
            checkBox.Name = "checkBox";
            checkBox.Size = new Size(129, 32);
            checkBox.TabIndex = 14;
            checkBox.UseVisualStyleBackColor = true;
            // 
            // ReviewForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(271, 288);
            Controls.Add(button3);
            Controls.Add(tableLayoutPanel4);
            Name = "ReviewForm";
            Text = "ReviewForm";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button execBtn;
        private TableLayoutPanel tableLayoutPanel1;
        private Label reviewIdValueLbl;
        private Label reviewLbl;
        private Button button1;
        private TableLayoutPanel tableLayoutPanel2;
        private Label nameLbl;
        private Label cityLbl;
        private Button button3;
        private TableLayoutPanel tableLayoutPanel4;
        private Label label1;
        private Label label2;
        private Label numberLbl;
        private Label specLbl;
        private Label label7;
        private Label asmntLbl;
        private Label contentLbl;
        private CheckBox checkBox;
        private Label ratingLbl;
        private Label userIdLbl;
        private Label schoolIdLbl;
        private Label createdAtLbl;
    }
}