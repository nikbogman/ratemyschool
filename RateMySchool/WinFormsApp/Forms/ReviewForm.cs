using Core.Entities;

namespace WinFormsApp.Forms
{
    public partial class ReviewForm : Form
    {
        public ReviewForm(ReviewEntity data)
        {
            InitializeComponent();
            contentLbl.Text = data.Content;
            createdAtLbl.Text = data.CreatedAt.ToString();
            schoolIdLbl.Text = data.SchoolId.ToString();
            userIdLbl.Text = data.UserId.ToString();
            ratingLbl.Text = data.Rating.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
