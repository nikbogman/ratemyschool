using System.Windows.Forms;

namespace WinFormsApp.Forms.BaseForms
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
            execBtn.Margin = new Padding(3, 4, 3, 4);
            execBtn.Name = "execBtn";
            execBtn.Size = new Size(425, 44);
            execBtn.TabIndex = 6;
            execBtn.Text = "Save or Close";
            execBtn.UseVisualStyleBackColor = true;
            execBtn.Click += execBtn_Click;
            // 
            // panel
            // 
            panel.Controls.Add(execBtn);
            panel.Dock = DockStyle.Bottom;
            panel.Location = new Point(6, 57);
            panel.Margin = new Padding(3, 4, 3, 4);
            panel.Name = "panel";
            panel.Size = new Size(425, 44);
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
            tableLayoutPanel.Location = new Point(6, 7);
            tableLayoutPanel.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.RowCount = 1;
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 51F));
            tableLayoutPanel.Size = new Size(425, 50);
            tableLayoutPanel.TabIndex = 8;
            // 
            // EntityForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(437, 108);
            Controls.Add(tableLayoutPanel);
            Controls.Add(panel);
            Margin = new Padding(3, 4, 3, 4);
            Name = "EntityForm";
            Padding = new Padding(6, 7, 6, 7);
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