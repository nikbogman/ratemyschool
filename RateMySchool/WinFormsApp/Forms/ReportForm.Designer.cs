namespace WinFormsApp.Forms
{
    partial class ReportForm
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
            tableLayoutPanel1 = new TableLayoutPanel();
            reviewIdLbl = new Label();
            reportedAtLbl = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            reasonLbl = new Label();
            execBtn = new Button();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            tableLayoutPanel1.Controls.Add(reviewIdLbl, 1, 2);
            tableLayoutPanel1.Controls.Add(reportedAtLbl, 1, 1);
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(label2, 0, 1);
            tableLayoutPanel1.Controls.Add(label3, 0, 2);
            tableLayoutPanel1.Controls.Add(reasonLbl, 1, 0);
            tableLayoutPanel1.Location = new Point(12, 12);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            tableLayoutPanel1.Size = new Size(241, 114);
            tableLayoutPanel1.TabIndex = 6;
            // 
            // reviewIdLbl
            // 
            reviewIdLbl.AutoSize = true;
            reviewIdLbl.Dock = DockStyle.Fill;
            reviewIdLbl.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            reviewIdLbl.Location = new Point(99, 76);
            reviewIdLbl.Name = "reviewIdLbl";
            reviewIdLbl.Size = new Size(139, 38);
            reviewIdLbl.TabIndex = 6;
            reviewIdLbl.Text = "label4";
            reviewIdLbl.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // reportedAtLbl
            // 
            reportedAtLbl.AutoSize = true;
            reportedAtLbl.Dock = DockStyle.Fill;
            reportedAtLbl.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            reportedAtLbl.Location = new Point(99, 38);
            reportedAtLbl.Name = "reportedAtLbl";
            reportedAtLbl.Size = new Size(139, 38);
            reportedAtLbl.TabIndex = 5;
            reportedAtLbl.Text = "label4";
            reportedAtLbl.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(90, 38);
            label1.TabIndex = 0;
            label1.Text = "Reason:";
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
            label2.Text = "Reported at:";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Fill;
            label3.Location = new Point(3, 76);
            label3.Name = "label3";
            label3.Size = new Size(90, 38);
            label3.TabIndex = 3;
            label3.Text = "Review ID:";
            label3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // reasonLbl
            // 
            reasonLbl.AutoSize = true;
            reasonLbl.Dock = DockStyle.Fill;
            reasonLbl.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            reasonLbl.Location = new Point(99, 0);
            reasonLbl.Name = "reasonLbl";
            reasonLbl.Size = new Size(139, 38);
            reasonLbl.TabIndex = 4;
            reasonLbl.Text = "label4";
            reasonLbl.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // execBtn
            // 
            execBtn.Location = new Point(15, 132);
            execBtn.Name = "execBtn";
            execBtn.Size = new Size(240, 30);
            execBtn.TabIndex = 7;
            execBtn.Text = "Close";
            execBtn.UseVisualStyleBackColor = true;
            execBtn.Click += execBtn_Click;
            // 
            // ReportForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(270, 174);
            Controls.Add(execBtn);
            Controls.Add(tableLayoutPanel1);
            Name = "ReportForm";
            Text = "ReportForm";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label reviewIdLbl;
        private Label reportedAtLbl;
        private Label reasonLbl;
        private Button execBtn;
    }
}