using Core.Entities.SchoolEntities;
using Core.Managers.SchoolManagers;
using Core.ViewModels.SchoolViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp.Forms.SchoolForms
{
    public partial class SpecializedSchoolForm : Form
    {
        private readonly SpecializedSchoolManager _manager;
        public SpecializedSchoolEntity Data { get; set; }

        // CREATE
        public SpecializedSchoolForm(SpecializedSchoolManager manager)
        {
            _manager = manager;
            InitializeComponent();
            execBtn.Text = "Save";
            execBtn.Click += createOnClick;
        }
        public void createOnClick(object sender, EventArgs e)
        {
            try
            {
                SpecializedSchoolViewModel viewModel = new()
                {
                    Name = nameTextBox.Text,
                    City = cityTextBox.Text,
                    Number = Convert.ToInt32(numericUpDown.Value),
                    Specialization = specTextBox.Text,
                    Assessment = asmntTextBox.Text,
                };

                ValidationContext validContext = new(viewModel, null, null);
                List<ValidationResult> validResults = new();
                if (!Validator.TryValidateObject(viewModel, validContext, validResults, true))
                {
                    validResults.ForEach(validResult => MessageBox.Show(validResult.ErrorMessage));
                    return;
                }

                Data = _manager.CreateOne(viewModel);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        // UPDATE
        private readonly Guid? _id;
        public SpecializedSchoolForm(SpecializedSchoolManager manager, SpecializedSchoolEntity data)
        {
            _manager = manager;
            InitializeComponent();
            _id = data.Id;
            nameTextBox.Text = data.Name;
            cityTextBox.Text = data.City;
            numericUpDown.Value = data.Number;
            specTextBox.Text = data.Specialization;
            asmntTextBox.Text = data.Assessment;
            execBtn.Text = "Update";
            execBtn.Click += updateOnClick;
        }
        public void updateOnClick(object sender, EventArgs e)
        {
            try
            {
                SpecializedSchoolViewModel viewModel = new()
                {
                    Name = nameTextBox.Text,
                    City = cityTextBox.Text,
                    Number = Convert.ToInt32(numericUpDown.Value),
                    Specialization = specTextBox.Text,
                    Assessment = asmntTextBox.Text,
                };

                ValidationContext validContext = new(viewModel, null, null);
                List<ValidationResult> validResults = new();
                if (!Validator.TryValidateObject(viewModel, validContext, validResults, true))
                {
                    validResults.ForEach(validResult => MessageBox.Show(validResult.ErrorMessage));
                    return;
                }

                Data = _manager.UpdateOne((Guid)_id!, viewModel);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        // DETAILS
        public SpecializedSchoolForm(SpecializedSchoolEntity data)
        {
            InitializeComponent();
            nameTextBox.Text = data.Name;
            nameTextBox.ReadOnly = true;

            cityTextBox.Text = data.City;
            cityTextBox.ReadOnly = true;

            numericUpDown.Text = data.Number.ToString();
            numericUpDown.ReadOnly = true;

            specTextBox.Text = data.Specialization;
            specTextBox.ReadOnly = true;

            asmntTextBox.Text = data.Assessment;
            asmntTextBox.ReadOnly = true;

            execBtn.Text = "Close";
            execBtn.Click += delegate (object sender, EventArgs e) { Close(); };
        }
    }
}
