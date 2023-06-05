using Core.Entities;
using Core.Entities.SchoolEntities;
using Core.Managers;
using Core.Managers.SchoolManagers;
using Core.ViewModels;
using DAL.Repositories;
using DAL.Repositories.SchoolRepositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;
using System.Security.Claims;

namespace WebApp.Pages.Schools.Details
{
    public class LanguageModel : PageModel
    {
        const string _connectionString = "Server=localhost;Uid=root;Database=ratemyschool;Pwd=rootpass";

        private readonly LanguageSchoolManager _langSchoolManager = new(
           repository: new LanguageSchoolRepository(_connectionString)
        );
        private readonly ReviewManager _reviewManager = new(
           repository: new ReviewRepository(_connectionString)
        );

        public LanguageSchoolEntity LanguageSchool { get; set; }
        public IEnumerable<ReviewEntity> Reviews { get; set; }

        [BindProperty]
        public ReviewViewModel ReviewViewModel { get; set; }

        public IActionResult OnGet(Guid id)
        {
            LanguageSchool = _langSchoolManager.GetOneById(id, _reviewManager);
            Reviews = _reviewManager.GetAllBySchoolId(id);
            return Page();
        }

        public IActionResult OnPost(Guid id)
        {
            var idClaim = User.FindFirstValue("id");
            if (idClaim == null)
            {
                throw new Exception("Claim `id` cannot be parsed correctly. Check if authenticated.");
            }
            Guid userId = Guid.Parse(idClaim);
            ReviewViewModel.SchoolId = id;
            ReviewViewModel.UserId = userId;
            if (!ModelState.IsValid)
            {
                LanguageSchool = _langSchoolManager.GetOneById(id, _reviewManager);
                Reviews = _reviewManager.GetAllBySchoolId(id);
                return Page();
            }
            _reviewManager.CreateOne(ReviewViewModel);
            return RedirectToPage();
        }
    }
}
