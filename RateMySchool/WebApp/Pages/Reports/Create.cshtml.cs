using Core.Managers;
using Core.ViewModels;
using DAL.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages.Reports
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public ReportViewModel ReportViewModel { get; set; }

        private readonly ReportManager _reportManager = new(
            repository: new ReportRepository("Server=localhost;Uid=root;Database=ratemyschool;Pwd=rootpass")
        );

        public void OnPost(Guid id)
        {

        }
    }
}
