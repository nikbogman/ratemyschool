namespace WinFormsApp.TabPages
{
    partial class UsersTabPage
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
            topPanel = new Panel();
            resetBtn = new Button();
            searchBtn = new Button();
            filterValueTextBox = new TextBox();
            filterPropertyComboBox = new ComboBox();
            label1 = new Label();
            tableLayoutPanel = new TableLayoutPanel();
            dataGridView = new DataGridView();
            tableLayoutPanel1 = new TableLayoutPanel();
            detailsBtn = new Button();
            deleteBtn = new Button();
            updateBtn = new Button();
            insertBtn = new Button();
            topPanel.SuspendLayout();
            tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // topPanel
            // 
            topPanel.Controls.Add(resetBtn);
            topPanel.Controls.Add(searchBtn);
            topPanel.Controls.Add(filterValueTextBox);
            topPanel.Controls.Add(filterPropertyComboBox);
            topPanel.Controls.Add(label1);
            topPanel.Dock = DockStyle.Top;
            topPanel.Location = new Point(0, 0);
            topPanel.Name = "topPanel";
            topPanel.Size = new Size(825, 50);
            topPanel.TabIndex = 1;
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
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(304, 20);
            label1.Name = "label1";
            label1.Size = new Size(177, 15);
            label1.TabIndex = 2;
            label1.Text = "Filter users by proerty and value:";
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.ColumnCount = 2;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80F));
            tableLayoutPanel.Controls.Add(dataGridView, 1, 0);
            tableLayoutPanel.Controls.Add(tableLayoutPanel1, 0, 0);
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.Location = new Point(0, 50);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.RowCount = 1;
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel.Size = new Size(825, 275);
            tableLayoutPanel.TabIndex = 2;
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
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(detailsBtn, 0, 3);
            tableLayoutPanel1.Controls.Add(deleteBtn, 0, 2);
            tableLayoutPanel1.Controls.Add(updateBtn, 0, 1);
            tableLayoutPanel1.Controls.Add(insertBtn, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(3, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 5;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.Size = new Size(159, 269);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // detailsBtn
            // 
            detailsBtn.Dock = DockStyle.Fill;
            detailsBtn.Location = new Point(3, 123);
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
            deleteBtn.Location = new Point(3, 83);
            deleteBtn.Name = "deleteBtn";
            deleteBtn.Size = new Size(153, 34);
            deleteBtn.TabIndex = 2;
            deleteBtn.Text = "Delete";
            deleteBtn.UseVisualStyleBackColor = true;
            deleteBtn.Click += deleteBtn_Click;
            // 
            // updateBtn
            // 
            updateBtn.Dock = DockStyle.Fill;
            updateBtn.Location = new Point(3, 43);
            updateBtn.Name = "updateBtn";
            updateBtn.Size = new Size(153, 34);
            updateBtn.TabIndex = 1;
            updateBtn.Text = "Update";
            updateBtn.UseVisualStyleBackColor = true;
            updateBtn.Click += updateBtn_Click;
            // 
            // insertBtn
            // 
            insertBtn.Dock = DockStyle.Fill;
            insertBtn.Location = new Point(3, 3);
            insertBtn.Name = "insertBtn";
            insertBtn.Size = new Size(153, 34);
            insertBtn.TabIndex = 0;
            insertBtn.Text = "Insert";
            insertBtn.UseVisualStyleBackColor = true;
            insertBtn.Click += insertBtn_Click;
            // 
            // UsersTabPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel);
            Controls.Add(topPanel);
            Name = "UsersTabPage";
            Size = new Size(825, 325);
            topPanel.ResumeLayout(false);
            topPanel.PerformLayout();
            tableLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel topPanel;
        private Button resetBtn;
        private Button searchBtn;
        private TextBox filterValueTextBox;
        private ComboBox filterPropertyComboBox;
        private Label label1;
        private TableLayoutPanel tableLayoutPanel;
        private DataGridView dataGridView;
        private TableLayoutPanel tableLayoutPanel1;
        private Button detailsBtn;
        private Button deleteBtn;
        private Button updateBtn;
        private Button insertBtn;
    }
}
