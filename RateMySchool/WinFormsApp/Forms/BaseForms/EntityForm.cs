using System.Windows.Forms;

namespace WinFormsApp.Forms.BaseForms
{
    public partial class EntityForm : Form
    {
        public EntityForm()
        {
            InitializeComponent();
            tableLayoutPanel.RowStyles.Clear();
        }

        protected void ClearRowStyles() => tableLayoutPanel.RowStyles.Clear();

        private int addedRows = 0;
        protected void AddRow()
        {
            // first row is created by default
            if (addedRows > 0)
            {
                tableLayoutPanel.Height += 38;
                tableLayoutPanel.RowCount += 1;
            }
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            addedRows++;
        }

        // wrapper function since tableLayoutPanel is private
        protected void AddControl(Control control, int column, int row) => tableLayoutPanel.Controls.Add(control, column, row);

        protected virtual void Setup() => throw new NotImplementedException();

        protected virtual void execBtn_Click(object sender, EventArgs e) => Close();
    }
}
