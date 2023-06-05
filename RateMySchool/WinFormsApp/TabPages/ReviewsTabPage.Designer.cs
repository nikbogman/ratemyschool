namespace WinFormsApp.TabPages
{
    partial class ReviewsTabPage
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            resetBtn = new Button();
            searchBtn = new Button();
            filterValueTextBox = new TextBox();
            filterPropertyComboBox = new ComboBox();
            label3 = new Label();
            tableLayoutPanel = new TableLayoutPanel();
            dataGridView = new DataGridView();
            tableLayoutPanel3 = new TableLayoutPanel();
            detailsBtn = new Button();
            deleteBtn = new Button();
            panel1.SuspendLayout();
            tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            tableLayoutPanel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(resetBtn);
            panel1.Controls.Add(searchBtn);
            panel1.Controls.Add(filterValueTextBox);
            panel1.Controls.Add(filterPropertyComboBox);
            panel1.Controls.Add(label3);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(825, 50);
            panel1.TabIndex = 2;
            // 
            // resetBtn
            // 
            resetBtn.Location = new Point(747, 24);
            resetBtn.Name = "resetBtn";
            resetBtn.Size = new Size(75, 23);
            resetBtn.TabIndex = 6;
            resetBtn.Text = "Reset filter";
            resetBtn.UseVisualStyleBackColor = true;
            resetBtn.Click += resetBtn_Click;
            // 
            // searchBtn
            // 
            searchBtn.Location = new Point(747, 3);
            searchBtn.Name = "searchBtn";
            searchBtn.Size = new Size(75, 23);
            searchBtn.TabIndex = 5;
            searchBtn.Text = "Search";
            searchBtn.UseVisualStyleBackColor = true;
            searchBtn.Click += searchBtn_Click;
            // 
            // filterValueTextBox
            // 
            filterValueTextBox.Location = new Point(605, 15);
            filterValueTextBox.Name = "filterValueTextBox";
            filterValueTextBox.Size = new Size(100, 23);
            filterValueTextBox.TabIndex = 4;
            // 
            // filterPropertyComboBox
            // 
            filterPropertyComboBox.FormattingEnabled = true;
            filterPropertyComboBox.Location = new Point(500, 15);
            filterPropertyComboBox.Name = "filterPropertyComboBox";
            filterPropertyComboBox.Size = new Size(99, 23);
            filterPropertyComboBox.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(304, 20);
            label3.Name = "label3";
            label3.Size = new Size(189, 15);
            label3.TabIndex = 2;
            label3.Text = "Filter reviews by proerty and value:";
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.ColumnCount = 2;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80F));
            tableLayoutPanel.Controls.Add(dataGridView, 1, 0);
            tableLayoutPanel.Controls.Add(tableLayoutPanel3, 0, 0);
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.Location = new Point(0, 50);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.RowCount = 1;
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel.Size = new Size(825, 275);
            tableLayoutPanel.TabIndex = 3;
            // 
            // dataGridView
            // 
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Dock = DockStyle.Fill;
            dataGridView.Location = new Point(168, 3);
            dataGridView.Name = "dataGridView";
            dataGridView.RowTemplate.Height = 25;
            dataGridView.Size = new Size(654, 269);
            dataGridView.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 1;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Controls.Add(detailsBtn, 0, 1);
            tableLayoutPanel3.Controls.Add(deleteBtn, 0, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(3, 3);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 3;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle());
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel3.Size = new Size(159, 269);
            tableLayoutPanel3.TabIndex = 1;
            // 
            // detailsBtn
            // 
            detailsBtn.Dock = DockStyle.Fill;
            detailsBtn.Location = new Point(3, 43);
            detailsBtn.Name = "detailsBtn";
            detailsBtn.Size = new Size(153, 34);
            detailsBtn.TabIndex = 3;
            detailsBtn.Text = "View Details";
            detailsBtn.UseVisualStyleBackColor = true;
            detailsBtn.Click += detailsBtn_Click;
            // 
            // deleteBtn
            // 
            deleteBtn.Dock = DockStyle.Fill;
            deleteBtn.Location = new Point(3, 3);
            deleteBtn.Name = "deleteBtn";
            deleteBtn.Size = new Size(153, 34);
            deleteBtn.TabIndex = 2;
            deleteBtn.Text = "Delete";
            deleteBtn.UseVisualStyleBackColor = true;
            deleteBtn.Click += deleteBtn_Click;
            // 
            // ReviewsTabPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel);
            Controls.Add(panel1);
            Name = "ReviewsTabPage";
            Size = new Size(825, 325);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tableLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            tableLayoutPanel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button resetBtn;
        private Button searchBtn;
        private TextBox filterValueTextBox;
        private ComboBox filterPropertyComboBox;
        private Label label3;
        private TableLayoutPanel tableLayoutPanel;
        private DataGridView dataGridView;
        private TableLayoutPanel tableLayoutPanel3;
        private Button detailsBtn;
        private Button deleteBtn;
    }
}
