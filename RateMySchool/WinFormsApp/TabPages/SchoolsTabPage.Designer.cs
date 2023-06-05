namespace WinFormsApp.TabPages
{
    partial class SchoolsTabPage
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
            label2 = new Label();
            filterComboBox = new ComboBox();
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
            topPanel.Controls.Add(label2);
            topPanel.Controls.Add(filterComboBox);
            topPanel.Controls.Add(label1);
            topPanel.Dock = DockStyle.Top;
            topPanel.Location = new Point(0, 0);
            topPanel.Margin = new Padding(3, 4, 3, 4);
            topPanel.Name = "topPanel";
            topPanel.Size = new Size(943, 67);
            topPanel.TabIndex = 0;
            // 
            // resetBtn
            // 
            resetBtn.Location = new Point(854, 32);
            resetBtn.Margin = new Padding(3, 4, 3, 4);
            resetBtn.Name = "resetBtn";
            resetBtn.Size = new Size(86, 31);
            resetBtn.TabIndex = 6;
            resetBtn.Text = "Reset filter";
            resetBtn.UseVisualStyleBackColor = true;
            resetBtn.Click += resetBtn_Click;
            // 
            // searchBtn
            // 
            searchBtn.Location = new Point(854, 4);
            searchBtn.Margin = new Padding(3, 4, 3, 4);
            searchBtn.Name = "searchBtn";
            searchBtn.Size = new Size(86, 31);
            searchBtn.TabIndex = 5;
            searchBtn.Text = "Search";
            searchBtn.UseVisualStyleBackColor = true;
            searchBtn.Click += searchBtn_Click;
            // 
            // filterValueTextBox
            // 
            filterValueTextBox.Location = new Point(691, 20);
            filterValueTextBox.Margin = new Padding(3, 4, 3, 4);
            filterValueTextBox.Name = "filterValueTextBox";
            filterValueTextBox.Size = new Size(114, 27);
            filterValueTextBox.TabIndex = 4;
            // 
            // filterPropertyComboBox
            // 
            filterPropertyComboBox.FormattingEnabled = true;
            filterPropertyComboBox.Location = new Point(571, 20);
            filterPropertyComboBox.Margin = new Padding(3, 4, 3, 4);
            filterPropertyComboBox.Name = "filterPropertyComboBox";
            filterPropertyComboBox.Size = new Size(113, 28);
            filterPropertyComboBox.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(333, 23);
            label2.Name = "label2";
            label2.Size = new Size(238, 20);
            label2.TabIndex = 2;
            label2.Text = "Filter schools by proerty and value:";
            // 
            // filterComboBox
            // 
            filterComboBox.FormattingEnabled = true;
            filterComboBox.Location = new Point(179, 20);
            filterComboBox.Margin = new Padding(3, 4, 3, 4);
            filterComboBox.Name = "filterComboBox";
            filterComboBox.Size = new Size(148, 28);
            filterComboBox.TabIndex = 1;
            filterComboBox.SelectedIndexChanged += filterComboBox_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 23);
            label1.Name = "label1";
            label1.Size = new Size(168, 20);
            label1.TabIndex = 0;
            label1.Text = "View all schools of type:";
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.ColumnCount = 2;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80F));
            tableLayoutPanel.Controls.Add(dataGridView, 1, 0);
            tableLayoutPanel.Controls.Add(tableLayoutPanel1, 0, 0);
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.Location = new Point(0, 67);
            tableLayoutPanel.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.RowCount = 1;
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel.Size = new Size(943, 366);
            tableLayoutPanel.TabIndex = 1;
            // 
            // dataGridView
            // 
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Dock = DockStyle.Fill;
            dataGridView.Location = new Point(191, 4);
            dataGridView.Margin = new Padding(3, 4, 3, 4);
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 51;
            dataGridView.RowTemplate.Height = 25;
            dataGridView.Size = new Size(749, 358);
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
            tableLayoutPanel1.Location = new Point(3, 4);
            tableLayoutPanel1.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 5;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 53F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 53F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 53F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 53F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.Size = new Size(182, 358);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // detailsBtn
            // 
            detailsBtn.Dock = DockStyle.Fill;
            detailsBtn.Location = new Point(3, 163);
            detailsBtn.Margin = new Padding(3, 4, 3, 4);
            detailsBtn.Name = "detailsBtn";
            detailsBtn.Size = new Size(176, 45);
            detailsBtn.TabIndex = 3;
            detailsBtn.Text = "View Details";
            detailsBtn.UseVisualStyleBackColor = true;
            detailsBtn.Click += detailsBtn_Click;
            // 
            // deleteBtn
            // 
            deleteBtn.Dock = DockStyle.Fill;
            deleteBtn.Location = new Point(3, 110);
            deleteBtn.Margin = new Padding(3, 4, 3, 4);
            deleteBtn.Name = "deleteBtn";
            deleteBtn.Size = new Size(176, 45);
            deleteBtn.TabIndex = 2;
            deleteBtn.Text = "Delete";
            deleteBtn.UseVisualStyleBackColor = true;
            deleteBtn.Click += deleteBtn_Click;
            // 
            // updateBtn
            // 
            updateBtn.Dock = DockStyle.Fill;
            updateBtn.Location = new Point(3, 57);
            updateBtn.Margin = new Padding(3, 4, 3, 4);
            updateBtn.Name = "updateBtn";
            updateBtn.Size = new Size(176, 45);
            updateBtn.TabIndex = 1;
            updateBtn.Text = "Update";
            updateBtn.UseVisualStyleBackColor = true;
            updateBtn.Click += updateBtn_Click;
            // 
            // insertBtn
            // 
            insertBtn.Dock = DockStyle.Fill;
            insertBtn.Location = new Point(3, 4);
            insertBtn.Margin = new Padding(3, 4, 3, 4);
            insertBtn.Name = "insertBtn";
            insertBtn.Size = new Size(176, 45);
            insertBtn.TabIndex = 0;
            insertBtn.Text = "Insert";
            insertBtn.UseVisualStyleBackColor = true;
            insertBtn.Click += insertBtn_Click;
            // 
            // SchoolsTabPage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel);
            Controls.Add(topPanel);
            Margin = new Padding(3, 4, 3, 4);
            Name = "SchoolsTabPage";
            Size = new Size(943, 433);
            topPanel.ResumeLayout(false);
            topPanel.PerformLayout();
            tableLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel topPanel;
        private TableLayoutPanel tableLayoutPanel;
        private DataGridView dataGridView;
        private TableLayoutPanel tableLayoutPanel1;
        private Button resetBtn;
        private Button searchBtn;
        private TextBox filterValueTextBox;
        private ComboBox filterPropertyComboBox;
        private Label label2;
        private ComboBox filterComboBox;
        private Label label1;
        private Button detailsBtn;
        private Button deleteBtn;
        private Button updateBtn;
        private Button insertBtn;
    }
}
