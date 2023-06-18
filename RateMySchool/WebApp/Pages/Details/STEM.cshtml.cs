using Core.Entities.SchoolEntities;
using Core.Entities;
using Core.Interfaces.RepositoryInterfaces;
using Core.Managers;
using Core.Services.StatisticServices;
using Core.Services;
using Core.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using Core.Exceptions;
using Microsoft.Extensions.Logging;
using Core.ViewModels.SchoolViewModels;

namespace WebApp.Pages.Details
{
    public class STEMModel : PageModel
    {
        private readonly ILogger<STEMModel> _logger;
        private readonly Manager<STEMSchoolEntity, STEMSchoolViewModel> _schoolManager;
        private readonly ReviewManager _reviewManager;
        private readonly RankingService _rankingService;

        public STEMModel(ILogger<STEMModel> logger, IReviewRepository reviewRepo, IRepository<STEMSchoolEntity> stemRepo)
        {
            _logger = logger;
            _reviewManager = new(reviewRepo);
            _schoolManager = new(stemRepo);
            _rankingService = new(
               reviewRepo,
               new CompareByRatingInDescendingOrder(),
               new TypeRankingCalculator()
           ); ;
        }

        public STEMSchoolEntity School { get; set; }
        public IEnumerable<ReviewEntity> Reviews { get; set; }

        [BindProperty]
        public ReviewViewModel ReviewViewModel { get; set; }

        public IActionResult OnGet(Guid id)
        {
            try
            {
                STEMSchoolEntity schoolToLoad = _schoolManager.GetOneById(id);
                School = (STEMSchoolEntity)_rankingService.LoadRanks(new[] { schoolToLoad }).First();
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
                    STEMSchoolEntity schoolToLoad = _schoolManager.GetOneById(id);
                    School = (STEMSchoolEntity)_rankingService.LoadRanks(new[] { schoolToLoad }).First();
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
