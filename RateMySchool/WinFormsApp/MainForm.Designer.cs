namespace WinFormsApp
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tableLayoutPanel1 = new TableLayoutPanel();
            schoolTabRedirectButton = new Button();
            reviewTabRedirectButton = new Button();
            reportTabRedirectButton = new Button();
            userTabRedirectButton = new Button();
            tabPagePanel = new Panel();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.Controls.Add(schoolTabRedirectButton, 0, 0);
            tableLayoutPanel1.Controls.Add(reviewTabRedirectButton, 1, 0);
            tableLayoutPanel1.Controls.Add(reportTabRedirectButton, 2, 0);
            tableLayoutPanel1.Controls.Add(userTabRedirectButton, 3, 0);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(3, 2, 3, 2);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(825, 45);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // schoolTabRedirectButton
            // 
            schoolTabRedirectButton.AutoSize = true;
            schoolTabRedirectButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            schoolTabRedirectButton.BackColor = SystemColors.Window;
            schoolTabRedirectButton.Dock = DockStyle.Fill;
            schoolTabRedirectButton.Location = new Point(3, 2);
            schoolTabRedirectButton.Margin = new Padding(3, 2, 3, 2);
            schoolTabRedirectButton.Name = "schoolTabRedirectButton";
            schoolTabRedirectButton.Size = new Size(200, 41);
            schoolTabRedirectButton.TabIndex = 0;
            schoolTabRedirectButton.Text = "Schools";
            schoolTabRedirectButton.UseVisualStyleBackColor = false;
            schoolTabRedirectButton.Click += schoolTabRedirectButton_Click;
            // 
            // reviewTabRedirectButton
            // 
            reviewTabRedirectButton.AutoSize = true;
            reviewTabRedirectButton.Dock = DockStyle.Fill;
            reviewTabRedirectButton.Location = new Point(209, 2);
            reviewTabRedirectButton.Margin = new Padding(3, 2, 3, 2);
            reviewTabRedirectButton.Name = "reviewTabRedirectButton";
            reviewTabRedirectButton.Size = new Size(200, 41);
            reviewTabRedirectButton.TabIndex = 1;
            reviewTabRedirectButton.Text = "Reviews";
            reviewTabRedirectButton.UseVisualStyleBackColor = true;
            reviewTabRedirectButton.Click += reviewTabRedirectButton_Click;
            // 
            // reportTabRedirectButton
            // 
            reportTabRedirectButton.AutoSize = true;
            reportTabRedirectButton.Dock = DockStyle.Fill;
            reportTabRedirectButton.Location = new Point(415, 2);
            reportTabRedirectButton.Margin = new Padding(3, 2, 3, 2);
            reportTabRedirectButton.Name = "reportTabRedirectButton";
            reportTabRedirectButton.Size = new Size(200, 41);
            reportTabRedirectButton.TabIndex = 2;
            reportTabRedirectButton.Text = "Report";
            reportTabRedirectButton.UseVisualStyleBackColor = true;
            reportTabRedirectButton.Click += reportTabRedirectButton_Click;
            // 
            // userTabRedirectButton
            // 
            userTabRedirectButton.AutoSize = true;
            userTabRedirectButton.Dock = DockStyle.Fill;
            userTabRedirectButton.Location = new Point(621, 2);
            userTabRedirectButton.Margin = new Padding(3, 2, 3, 2);
            userTabRedirectButton.Name = "userTabRedirectButton";
            userTabRedirectButton.Size = new Size(201, 41);
            userTabRedirectButton.TabIndex = 3;
            userTabRedirectButton.Text = "User";
            userTabRedirectButton.UseVisualStyleBackColor = true;
            userTabRedirectButton.Click += userTabRedirectButton_Click;
            // 
            // tabPagePanel
            // 
            tabPagePanel.BackColor = SystemColors.Control;
            tabPagePanel.Dock = DockStyle.Fill;
            tabPagePanel.Location = new Point(0, 45);
            tabPagePanel.Margin = new Padding(3, 2, 3, 2);
            tabPagePanel.Name = "tabPagePanel";
            tabPagePanel.Size = new Size(825, 325);
            tabPagePanel.TabIndex = 1;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(825, 370);
            Controls.Add(tabPagePanel);
            Controls.Add(tableLayoutPanel1);
            Name = "MainForm";
            Text = "Home";
            Load += MainForm_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Button schoolTabRedirectButton;
        private Button reviewTabRedirectButton;
        private Button reportTabRedirectButton;
        private Button userTabRedirectButton;
        private Panel tabPagePanel;
    }
}