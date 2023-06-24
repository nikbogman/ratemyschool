using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace WinFormsApp.Forms
{
    public partial class EntityForm : Form
    {
        public EntityForm()
        {
            InitializeComponent();
            tableLayoutPanel.RowStyles.Clear();
        }

        private int addedRows = 0;
        protected void addRow()
        {
            // first row is created by default
            if (addedRows > 0)
            {
                tableLayoutPanel.Height += 38;
                tableLayoutPanel.RowCount += 1;
            }
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            addedRows++;
            return;
        }

        protected void addControl(Control control, int column, int row)
        {
            // wrapper function since tableLayoutPanel is private
            tableLayoutPanel.Controls.Add(control, column, row);
            return;
        }

        protected void MapObjects<EntityT>(EntityT entity, Func<PropertyInfo, bool>? predicate = null)
        {
            PropertyInfo[] props = typeof(EntityT).GetProperties();
            if (predicate != null)
            {
                props = props.Where(predicate).ToArray();
            }
            int rowIndex = 0;
            foreach (var prop in props)
            {
                string pattern = @"(?<!^)(?=[A-Z])";
                string[] words = Regex.Split(prop.Name, pattern);
                string text = string.Join(" ", words);
                Label label = new()
                {
                    Text = text,
                    AutoSize = true,
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleRight
                };
                object? value = prop.GetValue(entity);
                Control control;
                if (prop.PropertyType == typeof(bool))
                {
                    control = new CheckBox()
                    {
                        AutoSize = true,
                        Dock = DockStyle.Fill,
                        Enabled = false,
                        Margin = new Padding(13, 3, 3, 3),
                        Name = "checkBox",
                        UseVisualStyleBackColor = true
                    };
                }
                else
                {
                    control = new TextBox()
                    {
                        Text = value.ToString(),
                        AutoSize = true,
                        Dock = DockStyle.Fill,
                        ReadOnly = true,
                        BorderStyle = 0,
                        TabStop = false,
                        Multiline = true
                    };
                }
                addRow();
                addControl(label, 0, rowIndex);
                addControl(control, 1, rowIndex);
                FormBorderStyle = FormBorderStyle.FixedSingle;
                MaximizeBox = false;
                rowIndex++;
            }
        }
    }
}
