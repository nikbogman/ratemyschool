using Core.Entities;
using Core.Enums;
using Core.Managers;
using Core.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace WinFormsApp.Forms
{
    public partial class UserForm : Form
    {
        private readonly UserManager _manager;
        public UserEntity Data { get; private set; }

        // CREATE
        public UserForm(UserManager manager)
        {
            _manager = manager;
            InitializeComponent();
            roleComboBox.DataSource = Enum.GetValues(typeof(UserRole));
            roleComboBox.SelectedIndex = 0;
            execBtn.Text = "Save";
            execBtn.Click += createOnClick;
        }
        private void createOnClick(object sender, EventArgs e)
        {
            try
            {
                UserViewModel viewModel = new()
                {
                    Email = emailTextBox.Text,
                    BirthYear = Convert.ToInt32(birthyearTextBox.Text),
                    Password = passwordTextBox.Text,
                    Role = (UserRole)roleComboBox.SelectedIndex + 1,
                    SuspendedBefore = dateTimePicker.Value,
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
        public UserForm(UserManager manager, UserEntity data)
        {
            _manager = manager;
            InitializeComponent();
            _id = data.Id;

            roleComboBox.DataSource = Enum.GetValues(typeof(UserRole));
            roleComboBox.SelectedIndex = (int)data.Role;

            emailTextBox.Text = data.Email;
            passwordTextBox.Text = data.Password;
            birthyearTextBox.Text = data.BirthYear.ToString();

            bannLbl.Visible = true;
            dateTimePicker.Visible = true;
            if (data.SuspendedBefore != null)
            {
                dateTimePicker.Value = (DateTime)data.SuspendedBefore;
            }

            execBtn.Text = "Update";
            execBtn.Click += updateOnClick;
        }
        private void updateOnClick(object sender, EventArgs e)
        {
            try
            {
                UserViewModel viewModel = new()
                {
                    Email = emailTextBox.Text,
                    BirthYear = Convert.ToInt32(birthyearTextBox.Text),
                    Password = passwordTextBox.Text,
                    Role = (UserRole)roleComboBox.SelectedIndex + 1,
                    SuspendedBefore = dateTimePicker.Value,
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
        public UserForm(UserEntity data)
        {
            InitializeComponent();
            _id = data.Id;

            roleComboBox.DataSource = Enum.GetValues(typeof(UserRole));
            roleComboBox.SelectedIndex = (int)data.Role;
            roleComboBox.Enabled = false;

            emailTextBox.Text = data.Email;
            emailTextBox.Enabled = false;

            passwordTextBox.Text = data.Password;
            passwordTextBox.Enabled = false;

            birthyearTextBox.Text = data.BirthYear.ToString();
            birthyearTextBox.Enabled = false;

            bannLbl.Visible = true;
            dateTimePicker.Visible = true;
            dateTimePicker.Enabled = false;
            if (data.SuspendedBefore != null)
            {
                dateTimePicker.Value = (DateTime)data.SuspendedBefore;
            }

            execBtn.Text = "Close";
            execBtn.Click += closeOnClick;
        }
        private void closeOnClick(object sender, EventArgs e)
        {
            Close();
        }
    }
}
