using Core.Entities;
using Core.Exceptions;
using Core.Interfaces.Repositories;
using Core.Managers;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;
using System.Security.Claims;

namespace WebApp.Pages.CreateReport
{
    public class IndexModel : PageModel
    {
        private readonly Manager<ReportEntity, ReportModel> _manager;
        private readonly ReviewManager _reviewManager;


        public IndexModel(IRepository<ReportEntity> repo, IReviewRepository reviewRepo)
        {
            _manager = new(repo);
            _reviewManager = new(reviewRepo);
        }

        [BindProperty]
        public ReportModel ReportViewModel { get; set; }

        public IActionResult OnGet()
        {
            try
            {
                if (User.Identity == null || User.Identity.IsAuthenticated == false)
                {
                    throw new UnauthorizedException();
                }
                return Page();
            }
            catch (Exception ex)
            {
                return RedirectToPage("/Errors/" + ErrorHandler.GetPath(ex));
            }
        }

        public IActionResult OnPost(Guid id)
        {
            try
            {
                ReportViewModel.ReviewId = id;
                if (User.Identity == null || User.Identity.IsAuthenticated == false)
                {
                    throw new UnauthorizedException();
                }
                if (!ModelState.IsValid)
                {
                    return Page();
                }
                _manager.CreateOne(ReportViewModel);
                _reviewManager.MarkAsRepoted(id);
                return Redirect("/");
            }
            catch (Exception ex)
            {
                return RedirectToPage("/Errors/" + ErrorHandler.GetPath(ex));
            }
            
        }
    }
}
