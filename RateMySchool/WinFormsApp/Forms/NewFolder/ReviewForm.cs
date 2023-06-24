using Core.Entities;
using System.Text.RegularExpressions;

namespace WinFormsApp.Forms.NewFolder
{
    public partial class ReviewForm : EntityForm
    {
        public ReviewForm(ReviewEntity data)
        {
            InitializeComponent();
            MapObjects<ReviewEntity>(data);
            return;
        }
    }
}
