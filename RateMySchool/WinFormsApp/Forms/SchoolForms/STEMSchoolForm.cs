using Core.Entities.Schools;
using Core.Managers;
using Core.Models.Schools;
using System.ComponentModel.DataAnnotations;
using WinFormsApp;

namespace WinFormsApp.Forms.SchoolForms
{
    public partial class STEMSchoolForm : Form
    {
        private readonly Manager<ScienceSchoolEntity, ScienceSchoolModel> _manager;
        public ScienceSchoolEntity Data { get; set; }

        // CREATE
        public STEMSchoolForm(Manager<ScienceSchoolEntity, ScienceSchoolModel> manager)
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
                ScienceSchoolModel viewModel = new()
                {
                    Name = nameTextBox.Text,
                    City = cityTextBox.Text,
                    Number = Convert.ToInt32(numericUpDown.Value),
                    ScoreRequirement = Convert.ToInt32(scoreUpDown.Value),
                    Study = studyTextBox.Text,
                    EntryAssessment = entryAsmntCheckBox.Checked
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
        public STEMSchoolForm(Manager<ScienceSchoolEntity, ScienceSchoolModel> manager, ScienceSchoolEntity data)
        {
            _manager = manager;
            InitializeComponent();
            _id = data.Id;
            nameTextBox.Text = data.Name;
            cityTextBox.Text = data.City;
            numericUpDown.Value = data.Number;
            studyTextBox.Text = data.Study;
            scoreUpDown.Value = data.ScoreRequirement == null ? 0 : (decimal)data.ScoreRequirement;
            entryAsmntCheckBox.Checked = data.EntryAssessment;
            execBtn.Text = "Update";
            execBtn.Click += updateOnClick;
        }
        public void updateOnClick(object sender, EventArgs e)
        {
            try
            {
                ScienceSchoolModel viewModel = new()
                {
                    Name = nameTextBox.Text,
                    City = cityTextBox.Text,
                    Number = Convert.ToInt32(numericUpDown.Value),
                    Study = studyTextBox.Text,
                    EntryAssessment = entryAsmntCheckBox.Checked
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
        public STEMSchoolForm(ScienceSchoolEntity data)
        {
            InitializeComponent();
            nameTextBox.Text = data.Name;
            nameTextBox.ReadOnly = true;

            cityTextBox.Text = data.City;
            cityTextBox.ReadOnly = true;

            numericUpDown.Text = data.Number.ToString();
            numericUpDown.ReadOnly = true;

            scoreUpDown.Value = data.ScoreRequirement == null ? 0 : (decimal)data.ScoreRequirement;
            scoreUpDown.ReadOnly = true;

            studyTextBox.Text = data.Study;
            studyTextBox.ReadOnly = true;

            entryAsmntCheckBox.Checked = data.EntryAssessment;
            entryAsmntCheckBox.Enabled = false;

            execBtn.Text = "Close";
            execBtn.Click += delegate (object sender, EventArgs e) { Close(); };
        }
    }
}
