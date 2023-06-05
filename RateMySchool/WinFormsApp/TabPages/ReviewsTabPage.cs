using Core.Entities;
using Core.Managers;
using DAL.Repositories;
using WinFormsApp.Forms;
using WinFormsApp;
using Core.Managers.FeatureManagers;

namespace WinFormsApp.TabPages
{
    public partial class ReviewsTabPage : UserControl
    {
        const string connectionString = "Server=localhost;Uid=root;Database=ratemyschool;Pwd=rootpass";
        private readonly ReviewManager _reviewManager;

        public ReviewsTabPage()
        {
            ReviewRepository reviewRepository = new(connectionString);
            _reviewManager = new(reviewRepository);
            InitializeComponent();
        }

        public void PreloadPage()
        {
            filterPropertyComboBox.LoadPropsFromType(typeof(ReviewEntity), x => x != "CreatedAt");
            dataGridView.Load(_reviewManager.GetAll());
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
                var langSchool = (ReviewEntity)dataBoundItem;
                _reviewManager.DeleteOne(langSchool.Id);
                var langSchoolDataSource = (List<ReviewEntity>)dataGridView.DataSource;
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
                    throw new Exception("Row with school has to be selected in order to view its details");
                }
                ReviewForm form = new((ReviewEntity)dataBoundItem);
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
                    unfiltered: (IEnumerable<ReviewEntity>)dataGridView.DataSource,
                    propertyName: filterPropertyComboBox.Text,
                    searchValue
                );
                if (users == Enumerable.Empty<ReviewEntity>())
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
                dataGridView.Load(_reviewManager.GetAll());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
    }
}
