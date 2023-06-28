using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp.Forms.BaseForms
{
    public partial class UpdateEntityForm : EntityForm
    {
        protected readonly IEntity _entity;
        public UpdateEntityForm(IEntity entity) : base()
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
                Control control;
                object? value = prop.GetValue(_entity);
                var nullable = Nullable.GetUnderlyingType(prop.PropertyType);
                if (prop.PropertyType == typeof(bool) || nullable == typeof(bool))
                {
                    control = new CheckBox()
                    {
                        Checked = (bool)value,
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
                        Text = value.ToString(),
                        AutoSize = true,
                        Dock = DockStyle.Fill,
                    };
                }
                else if (prop.PropertyType == typeof(int) || nullable == typeof(int))
                {
                    control = new NumericUpDown()
                    {
                        Value = (int)value,
                        AutoSize = true,
                        Dock = DockStyle.Fill,
                    };
                }
                else { continue; }

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
