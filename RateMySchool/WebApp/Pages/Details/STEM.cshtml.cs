using Core.Entities;
using Core.Managers;
using Core.Services.StatisticServices;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using Core.Exceptions;
using Microsoft.Extensions.Logging;
using Core.Interfaces.Repositories;
using Core.Models;
using Core.Models.Schools;
using Core.Entities.Schools;

namespace WebApp.Pages.Details
{
    public class STEMModel : PageModel
    {
        private readonly ILogger<STEMModel> _logger;
        private readonly Manager<ScienceSchoolEntity, ScienceSchoolModel> _schoolManager;
        private readonly ReviewManager _reviewManager;
        private readonly RankService _rankingService;

        public STEMModel(ILogger<STEMModel> logger, IReviewRepository reviewRepo, IRepository<ScienceSchoolEntity> stemRepo)
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

        public ScienceSchoolEntity School { get; set; }
        public IEnumerable<ReviewEntity> Reviews { get; set; }

        [BindProperty]
        public ReviewModel ReviewViewModel { get; set; }

        public IActionResult OnGet(Guid id)
        {
            try
            {
                ScienceSchoolEntity schoolToLoad = _schoolManager.GetOneById(id);
                School = (ScienceSchoolEntity)_rankingService.LoadRanks(new[] { schoolToLoad }).First();
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
                    ScienceSchoolEntity schoolToLoad = _schoolManager.GetOneById(id);
                    School = (ScienceSchoolEntity)_rankingService.LoadRanks(new[] { schoolToLoad }).First();
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
