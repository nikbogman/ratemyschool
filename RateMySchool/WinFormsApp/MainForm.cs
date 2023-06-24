using WinFormsApp.Forms;
using WinFormsApp.Forms.NewFolder;
using WinFormsApp.TabPages;

namespace WinFormsApp
{
    public partial class MainForm : Form
    {
        private UserControl currentPage;

        public MainForm()
        {
            InitializeComponent();
        }
        private void ShowPage(UserControl page)
        {
            tabPagePanel.SuspendLayout();
            if (page != currentPage)
            {
                tabPagePanel.Controls.Remove(currentPage);
                tabPagePanel.Controls.Add(page);
                page.Dock = DockStyle.Fill;
                currentPage = page;
                currentPage.Visible = true;
            }
            tabPagePanel.ResumeLayout();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            SchoolsTabPage schoolTabPage = new();
            schoolTabPage.PreloadPage();
            ShowPage(schoolTabPage);
        }

        private void schoolTabRedirectButton_Click(object sender, EventArgs e)
        {
            SchoolsTabPage schoolTabPage = new();
            schoolTabPage.PreloadPage();
            ShowPage(schoolTabPage);
        }

        private void reviewTabRedirectButton_Click(object sender, EventArgs e)
        {
            ReviewsTabPage reviewTabPage = new();
            reviewTabPage.PreloadPage();
            ShowPage(reviewTabPage);
        }

        private void reportTabRedirectButton_Click(object sender, EventArgs e)
        {
            ReportsTabPage reportTabPage = new();
            reportTabPage.PreloadPage();
            ShowPage(reportTabPage);
        }
    }
}