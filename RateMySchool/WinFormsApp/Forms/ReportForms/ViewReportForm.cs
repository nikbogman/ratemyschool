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

namespace WinFormsApp.Forms.ReportForms
{
    public partial class ViewReportForm : ViewEntityForm
    {
        public ViewReportForm(ReportEntity entity): base(entity) { }
    }
}
