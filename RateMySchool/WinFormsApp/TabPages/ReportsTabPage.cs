using Core.Entities;
using Core.FeatureManagers;
using Core.Interfaces.RepositoryInterfaces;
using Core.Managers;
using DAL;
using DAL.Repositories;
using WinFormsApp.Forms;

namespace WinFormsApp.TabPages
{
    public partial class ReportsTabPage : UserControl
    {
        const string connectionString = "Server=localhost;Uid=root;Database=ratemyschool;Pwd=rootpass";
        private readonly ReviewManager _reviewManager;
        private readonly ReportManager _manager;
        public ReportsTabPage()
        {
            IReviewRepository reviewRepository = new ReviewRepository(connectionString);
            IRepository<ReportEntity> reportRepository = new BaseRepository<ReportEntity>(connectionString);
            _reviewManager = new(reviewRepository);
            _manager = new(reportRepository);
            InitializeComponent();
        }

        public void PreloadPage()
        {
            filterPropertyComboBox.LoadPropsFromType(typeof(ReportEntity), x => x != "CreatedAt");
            dataGridView.Load(_manager.GetAll());
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
                var report = (ReportEntity)dataBoundItem;
                _reviewManager.DeleteOne(report.ReviewId);
                var reportDataSource = (List<ReportEntity>)dataGridView.DataSource;
                reportDataSource.Remove(report);
                dataGridView.Load(reportDataSource);
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
                ReportForm form = new((ReportEntity)dataBoundItem);
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
                var reports = SearchFilterService.Filter(
                    unfiltered: (IEnumerable<ReportEntity>)dataGridView.DataSource,
                    propertyName: filterPropertyComboBox.Text,
                    searchValue
                );
                if (reports == Enumerable.Empty<ReportEntity>())
                {
                    throw new Exception("There were no reports found for this search");
                }
                dataGridView.Load(reports);
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
