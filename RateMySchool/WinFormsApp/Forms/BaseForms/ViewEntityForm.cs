using Core.Entities;
using Core.Interfaces;
using System.Reflection;
using WinFormsApp;

namespace WinFormsApp.Forms.BaseForms
{
    public partial class ViewEntityForm : EntityForm
    {
        protected readonly IEntity _entity;
        public ViewEntityForm(IEntity entity) : base()
        {
            _entity = entity;
            Setup();
        }

        protected override void Setup()
        {
            ClearRowStyles();
            PropertyInfo[] props = _entity.GetType().GetProperties();
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
                object? value = prop.GetValue(_entity);
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
                    };
                }
                AddRow();
                AddControl(label, 0, rowIndex);
                AddControl(control, 1, rowIndex);
                FormBorderStyle = FormBorderStyle.FixedSingle;
                MaximizeBox = false;
                rowIndex++;
            }
        }
    }
}
