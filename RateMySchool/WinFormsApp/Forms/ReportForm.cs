using Core.Entities;

namespace WinFormsApp.Forms
{
    public partial class ReportForm : Form
    {
        public ReportForm(ReportEntity data)
        {
            InitializeComponent();
            reasonLbl.Text = data.Reason;
            reportedAtLbl.Text = data.ReportedAt.ToString();
            reviewIdLbl.Text = data.ReviewId.ToString();
        }

        private void execBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
