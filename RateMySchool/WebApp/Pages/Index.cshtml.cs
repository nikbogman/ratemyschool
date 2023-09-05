using Core.Managers;
using Core.Services.StatisticServices;
using Core.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Core;
using Core.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Core.Models.Schools;
using Core.Entities.Schools;
using Core.Interfaces.Repositories;

namespace WebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly Manager<SchoolEntity, SchoolModel> _schoolManager;
        private readonly RankService _rankingService;

        public IEnumerable<SchoolEntity> Schools { get; private set; }

        public IndexModel(ILogger<IndexModel> logger, IReviewRepository reviewRepo, IRepository<SchoolEntity> schoolRepo)
        {
            _logger = logger;
            _schoolManager = new(schoolRepo);
            _rankingService = new(
                reviewRepo,
                new CompareByRatingInDescendingOrder(),
                new TypeRankingCalculator()
            );
        }

        public IActionResult OnGet()
        {
            try
            {
                IEnumerable<SchoolEntity> schoolsToLoad = _schoolManager.GetAll();
                Schools = _rankingService.LoadRanks(schoolsToLoad);
                return Page();
            }
            catch (Exception ex)
            {
                return RedirectToPage("/Errors/" + ErrorHandler.GetPath(ex));
            }
        }
    }
}