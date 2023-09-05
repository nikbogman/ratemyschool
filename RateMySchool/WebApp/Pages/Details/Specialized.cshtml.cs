using Core.Entities.SchoolEntities;
using Core.Entities;
using Core.Managers;
using Core.Services.StatisticServices;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using Core.Exceptions;
using Core.Schemas.SchoolSchemas;
using Core.Interfaces.Repositories;
using Core.Models;

namespace WebApp.Pages.Details
{
    public class SpecializedModel : PageModel
    {
        private readonly ILogger<SpecializedModel> _logger;
        private readonly Manager<VocationalSchoolEntity, VocationalSchoolSchema> _schoolManager;
        private readonly ReviewManager _reviewManager;
        private readonly RankService _rankingService;

        public SpecializedModel(ILogger<SpecializedModel> logger, IReviewRepository reviewRepo, IRepository<VocationalSchoolEntity> specRepo)
        {
            _logger = logger;
            _reviewManager = new(reviewRepo);
            _schoolManager = new(specRepo);
            _rankingService = new(
                reviewRepo,
                new CompareByRatingInDescendingOrder(),
                new TypeRankingCalculator()
            ); ;
        }

        public VocationalSchoolEntity School { get; set; }
        public IEnumerable<ReviewEntity> Reviews { get; set; }

        [BindProperty]
        public ReviewModel ReviewViewModel { get; set; }

        public IActionResult OnGet(Guid id)
        {
            try
            {
                VocationalSchoolEntity schoolToLoad = _schoolManager.GetOneById(id);
                School = (VocationalSchoolEntity)_rankingService.LoadRanks(new[] { schoolToLoad }).First();
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
                    VocationalSchoolEntity schoolToLoad = _schoolManager.GetOneById(id);
                    School = (VocationalSchoolEntity)_rankingService.LoadRanks(new[] { schoolToLoad }).First();
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
