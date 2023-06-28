using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp.Forms.BaseForms;

namespace WinFormsApp.Forms.ReviewForms
{
    public partial class ViewReviewForm : ViewEntityForm
    {
        public ViewReviewForm(ReviewEntity entity) : base(entity) { }
    }
}
