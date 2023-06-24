namespace WinFormsApp.Forms
{
    partial class EntityForm
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
            panel = new Panel();
            tableLayoutPanel = new TableLayoutPanel();
            panel.SuspendLayout();
            SuspendLayout();
            // 
            // execBtn
            // 
            execBtn.Dock = DockStyle.Fill;
            execBtn.Location = new Point(0, 0);
            execBtn.Name = "execBtn";
            execBtn.Size = new Size(255, 33);
            execBtn.TabIndex = 6;
            execBtn.Text = "Save or Close";
            execBtn.UseVisualStyleBackColor = true;
            // 
            // panel
            // 
            panel.Controls.Add(execBtn);
            panel.Dock = DockStyle.Bottom;
            panel.Location = new Point(5, 43);
            panel.Name = "panel";
            panel.Size = new Size(255, 33);
            panel.TabIndex = 7;
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.AutoSize = true;
            tableLayoutPanel.BackColor = SystemColors.Control;
            tableLayoutPanel.ColumnCount = 2;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.Location = new Point(5, 5);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.RowCount = 1;
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            tableLayoutPanel.Size = new Size(255, 38);
            tableLayoutPanel.TabIndex = 8;
            // 
            // EntityForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(265, 81);
            Controls.Add(tableLayoutPanel);
            Controls.Add(panel);
            Name = "EntityForm";
            Padding = new Padding(5);
            Text = "EntityForm";
            panel.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button execBtn;
        private Panel panel;
        private TableLayoutPanel tableLayoutPanel;
    }
}