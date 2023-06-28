using Core.Interfaces;
using System.Reflection;

namespace WinFormsApp.Forms.BaseForms
{
    public partial class CreateEntityForm : EntityForm
    {
        protected virtual Type EntityType => typeof(IEntity).GetType();
        public CreateEntityForm() : base() => Setup();



        private Dictionary<string, Control> inputs = new();
        protected override void Setup()
        {
            ClearRowStyles();
            PropertyInfo[] props = EntityType.GetProperties();
            AutoSize = true;
            int rowIndex = 0;
            foreach (var prop in props)
            {
                Label label = new()
                {
                    Text = prop.Name.ConvertCamelCaseToSenatnce(),
                    AutoSize = true,
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleRight
                };
                Control control;
                var nullable = Nullable.GetUnderlyingType(prop.PropertyType);
                if (prop.PropertyType == typeof(bool) || nullable == typeof(bool))
                {
                    control = new CheckBox()
                    {
                        AutoSize = true,
                        Dock = DockStyle.Fill,
                        Margin = new Padding(13, 3, 3, 3),
                        Name = "checkBox",
                        UseVisualStyleBackColor = true
                    };
                }
                else if (prop.PropertyType == typeof(string) || nullable == typeof(string))
                {
                    control = new TextBox()
                    {
                        AutoSize = true,
                        Dock = DockStyle.Fill,
                    };
                }
                else if (prop.PropertyType == typeof(int) || nullable == typeof(int))
                {
                    control = new NumericUpDown()
                    {
                        AutoSize = true,
                        Dock = DockStyle.Fill,
                    };
                }
                else { continue; }

                AddRow();
                AddControl(label, 0, rowIndex);
                AddControl(control, 1, rowIndex);
                inputs.Add(prop.Name, control);
                FormBorderStyle = FormBorderStyle.FixedSingle;
                MaximizeBox = false;
                rowIndex++;
            }
        }

        protected override void execBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
