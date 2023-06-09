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
    public class SpecializedModel : PageModel
    {
        private readonly ILogger<SpecializedModel> _logger;
        private readonly SpecializedSchoolManager _langSchoolManager;
        private readonly ReviewManager _reviewManager;
        private readonly TypeRankingService _ratingStatisticService;

        public SpecializedModel(ILogger<SpecializedModel> logger, IReviewRepository reviewrepo, IRepository<SpecializedSchoolEntity> langrepo)
        {
            _logger = logger;
            _reviewManager = new(reviewrepo);
            _langSchoolManager = new(langrepo);
            _ratingStatisticService = new(reviewrepo, new CompareByRatingInDescendingOrder());
        }

        public SpecializedSchoolEntity School { get; set; }
        public IEnumerable<ReviewEntity> Reviews { get; set; }

        [BindProperty]
        public ReviewViewModel ReviewViewModel { get; set; }

        public IActionResult OnGet(Guid id)
        {
            try
            {
                SpecializedSchoolEntity schoolToLoad = _langSchoolManager.GetOneById(id);
                School = (SpecializedSchoolEntity)_ratingStatisticService.LoadRanks(new[] { schoolToLoad }).First();
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
                    SpecializedSchoolEntity schoolToLoad = _langSchoolManager.GetOneById(id);
                    School = (SpecializedSchoolEntity)_ratingStatisticService.LoadRanks(new[] { schoolToLoad }).First();
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
