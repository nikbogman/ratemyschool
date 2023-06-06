using Core.Entities;
using Core.Managers;
using DAL.Repositories;
using WinFormsApp.Forms;

namespace WinFormsApp.TabPages
{
    public partial class ReportsTabPage : UserControl
    {
        const string connectionString = "Server=localhost;Uid=root;Database=ratemyschool;Pwd=rootpass";
        private readonly ReportManager _reportManager;

        public ReportsTabPage()
        {
            ReportRepository reportRepository = new(connectionString);
            _reportManager = new(reportRepository);
            InitializeComponent();
        }

        public void PreloadPage()
        {
            DataGridView_Load(_reportManager.GetAll());
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
                var langSchool = (ReportEntity)dataBoundItem;
                _reportManager.DeleteOne(langSchool.Id);
                var langSchoolDataSource = (List<ReportEntity>)dataGridView.DataSource;
                langSchoolDataSource.Remove(langSchool);
                DataGridView_Load(langSchoolDataSource);
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
                ReportForm form = new((ReportEntity)dataBoundItem);
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private DataGridView DataGridView_Load<T>(IEnumerable<T> dataSource)
        {
            dataGridView.DataSource = null;
            dataGridView.DataSource = dataSource;
            dataGridView.AutoGenerateColumns = true;
            return dataGridView;
        }
    }
}
