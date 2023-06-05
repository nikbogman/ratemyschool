using Core.Entities;
using Core.Enums;
using Core.Managers;
using DAL.Repositories;
using WinFormsApp.Forms;
using WinFormsApp;
using Core.Managers.FeatureManagers;

namespace WinFormsApp.TabPages
{
    public partial class UsersTabPage : UserControl
    {
        const string connectionString = "Server=localhost;Uid=root;Database=ratemyschool;Pwd=rootpass";
        private readonly UserManager _userManager;

        public UsersTabPage()
        {
            UserRepository userRepository = new(connectionString);
            _userManager = new(userRepository);
            InitializeComponent();
        }

        public void PreloadPage()
        {
            filterPropertyComboBox.LoadPropsFromType(typeof(UserEntity), x => x != "Password");
            dataGridView.Load(_userManager.GetAll());
        }

        private void insertBtn_Click(object sender, EventArgs e)
        {
            try
            {
                UserForm langSchoolForm = new(_userManager);
                if (langSchoolForm.ShowDialog() == DialogResult.OK && langSchoolForm.Data != null)
                {
                    var dataSource = (List<UserEntity>)dataGridView.DataSource;
                    dataSource.Add(langSchoolForm.Data);
                    dataGridView.Load(dataSource);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var dataBoundItem = dataGridView.SelectedRows.Count <= 0 ? null : dataGridView.SelectedRows[0].DataBoundItem;
                if (dataBoundItem == null)
                {
                    throw new Exception("Row with school has to be selected in order to delete it");
                }
                var langSchool = (UserEntity)dataBoundItem;
                UserForm form = new(_userManager, langSchool);
                if (form.ShowDialog() == DialogResult.OK && form.Data != null)
                {
                    if (langSchool != form.Data)
                    {
                        var dataSource = (List<UserEntity>)dataGridView.DataSource;
                        int idx = dataSource.IndexOf(langSchool);
                        dataSource.RemoveAt(idx);
                        dataSource.Insert(idx, form.Data);
                        dataGridView.Load(dataSource);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var dataBoundItem = dataGridView.SelectedRows.Count <= 0 ? null : dataGridView.SelectedRows[0].DataBoundItem;
                if (dataBoundItem == null)
                {
                    throw new Exception("Row with school has to be selected in order to delete it");
                }
                var langSchool = (UserEntity)dataBoundItem;
                _userManager.DeleteOne(langSchool.Id);
                var langSchoolDataSource = (List<UserEntity>)dataGridView.DataSource;
                langSchoolDataSource.Remove(langSchool);
                dataGridView.Load(langSchoolDataSource);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void detailsBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var dataBoundItem = dataGridView.SelectedRows.Count <= 0 ? null : dataGridView.SelectedRows[0].DataBoundItem;
                if (dataBoundItem == null)
                {
                    throw new Exception("Row with school has to be selected in order to delete it");
                }
                UserForm form = new((UserEntity)dataBoundItem);
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string searchValue = filterValueTextBox.Text;
                if (searchValue == null || searchValue == string.Empty)
                {
                    throw new Exception("Value needs to be provided for search filtering");
                }
                var users = SearchFilterManager.Filter(
                    unfiltered: (IEnumerable<UserEntity>)dataGridView.DataSource,
                    propertyName: filterPropertyComboBox.Text,
                    searchValue
                );
                if (users == Enumerable.Empty<UserEntity>())
                {
                    throw new Exception("");
                }
                dataGridView.Load(users);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void resetBtn_Click(object sender, EventArgs e)
        {
            try
            {
                filterValueTextBox.Clear();
                dataGridView.Load(_userManager.GetAll());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
    }
}
