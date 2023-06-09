using Core.Entities.SchoolEntities;
using Core.Managers.SchoolManagers;
using Core.ViewModels;
using Core.ViewModels.SchoolViewModels;
using System.ComponentModel.DataAnnotations;

namespace WinFormsApp.Forms.SchoolForms
{
    public partial class LanguageSchoolForm : Form
    {
        private readonly LanguageSchoolManager _manager;
        public LanguageSchoolEntity Data { get; set; }

        // CREATE
        public LanguageSchoolForm(LanguageSchoolManager manager)
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
                LanguageSchoolViewModel viewModel = new()
                {
                    Name = nameTextBox.Text,
                    City = cityTextBox.Text,
                    Number = Convert.ToInt32(numericUpDown.Value),
                    PrimaryLanguage = prLangTextBox.Text,
                    SecondaryLanguage = secLangTextBox.Text,
                    ScoreRequirement = Convert.ToInt32(scoreUpDown.Value),
                };

                ValidationContext validContext = new(viewModel, null, null);
                List<ValidationResult> validResults = new();
                if (!Validator.TryValidateObject(viewModel, validContext, validResults, true))
                {
                    validResults.ForEach(validResult => MessageBox.Show(validResult.ErrorMessage));
                    return;
                }

                Data = (LanguageSchoolEntity)_manager.CreateOne(viewModel);
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
        public LanguageSchoolForm(LanguageSchoolManager manager, LanguageSchoolEntity data)
        {
            _manager = manager;
            InitializeComponent();
            _id = data.Id;
            nameTextBox.Text = data.Name;
            cityTextBox.Text = data.City;
            numericUpDown.Value = data.Number;
            prLangTextBox.Text = data.PrimaryLanguage;
            secLangTextBox.Text = data.SecondaryLanguage;
            scoreUpDown.Value = data.ScoreRequirement == null ? 0 : (decimal)data.ScoreRequirement;
            execBtn.Text = "Update";
            execBtn.Click += updateOnClick;
        }
        public void updateOnClick(object sender, EventArgs e)
        {
            try
            {
                LanguageSchoolViewModel viewModel = new()
                {
                    Name = nameTextBox.Text,
                    City = cityTextBox.Text,
                    Number = Convert.ToInt32(numericUpDown.Value),
                    PrimaryLanguage = prLangTextBox.Text,
                    SecondaryLanguage = secLangTextBox.Text,
                    ScoreRequirement = Convert.ToInt32(scoreUpDown.Value),
                };

                ValidationContext validContext = new(viewModel, null, null);
                List<ValidationResult> validResults = new();
                if (!Validator.TryValidateObject(viewModel, validContext, validResults, true))
                {
                    validResults.ForEach(validResult => MessageBox.Show(validResult.ErrorMessage));
                    return;
                }

                Data = (LanguageSchoolEntity)_manager.UpdateOne((Guid)_id!, viewModel);
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
        public LanguageSchoolForm(LanguageSchoolEntity data)
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

            prLangTextBox.Text = data.PrimaryLanguage;
            prLangTextBox.ReadOnly = true;

            secLangTextBox.Text = data.SecondaryLanguage;
            secLangTextBox.ReadOnly = true;

            viewStatsBtn.Visible = true;
            execBtn.Text = "Close";
            execBtn.Click += delegate (object sender, EventArgs e) { Close(); };
        }
        
    }
}
