using Core.Entities.SchoolEntities;
using Core.Entities;
using Core.Interfaces.RepositoryInterfaces;
using Core.Managers.SchoolManagers;
using Core.Managers;
using Core.Services.StatisticServices;
using Core.Services;
using Core.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using Core.Exceptions;

namespace WebApp.Pages.Details
{
    public class LanguageModel : PageModel
    {
        private readonly ILogger<LanguageModel> _logger;
        private readonly LanguageSchoolManager _langSchoolManager;
        private readonly ReviewManager _reviewManager;
        private readonly TypeRankingService _ratingStatisticService;

        public LanguageModel(ILogger<LanguageModel> logger, IReviewRepository reviewrepo, IRepository<LanguageSchoolEntity> langrepo)
        {
            _logger = logger;
            _reviewManager = new(reviewrepo);
            _langSchoolManager = new(langrepo);
            _ratingStatisticService = new(reviewrepo, new CompareByRatingInDescendingOrder());
        }

        public LanguageSchoolEntity School { get; set; }
        public IEnumerable<ReviewEntity> Reviews { get; set; }

        [BindProperty]
        public ReviewViewModel ReviewViewModel { get; set; }

        public IActionResult OnGet(Guid id)
        {
            try
            {
                LanguageSchoolEntity schoolToLoad = _langSchoolManager.GetOneById(id);
                School = (LanguageSchoolEntity)_ratingStatisticService.LoadRanks(new[] { schoolToLoad }).First();
                Reviews = _reviewManager.GetAllBySchoolId(id).Where(review => review.Reported == false);
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
                string? idClaim = User.FindFirstValue("id");
                if (idClaim == null)
                {
                    throw new UnauthorizedException();
                }
                Guid userId = Guid.Parse(idClaim);

                ReviewViewModel.SchoolId = id;
                ReviewViewModel.UserId = userId;

                if (!ModelState.IsValid)
                {
                    LanguageSchoolEntity schoolToLoad = _langSchoolManager.GetOneById(id);
                    School = (LanguageSchoolEntity)_ratingStatisticService.LoadRanks(new[] { schoolToLoad }).First();
                    Reviews = _reviewManager.GetAllBySchoolId(id).Where(review => review.Reported == false);
                    return Page();
                }

                _reviewManager.CreateOne(ReviewViewModel);
                return RedirectToPage();
            }
            catch (Exception ex)
            {
                return RedirectToPage("/Errors/" + ErrorHandler.GetPath(ex));
            }
        }
    }
}