using Core.Entities.SchoolEntities;
using Core.Interfaces.RepositoryInterfaces;
using Core.Managers;
using Core.Services.StatisticServices;
using Core.Services;
using Core.ViewModels.SchoolViewModels;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Core;
using Core.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly BaseManager<BaseSchoolEntity, BaseSchoolViewModel> _schoolManager;
        private readonly TypeRankingService _ratingStatisticService;

        private IComparer<Statistic> _comparer;
        public IEnumerable<BaseSchoolEntity> Schools { get; private set; }

        public IndexModel(ILogger<IndexModel> logger, IReviewRepository reviewRepo, IRepository<BaseSchoolEntity> schoolRepo)
        {
            _logger = logger;
            _schoolManager = new(schoolRepo);
            _comparer = new CompareByRatingInDescendingOrder();
            _ratingStatisticService = new(reviewRepo, _comparer);
        }

        public IActionResult OnGet()
        {
            try
            {
                IEnumerable<BaseSchoolEntity> schoolsToLoad = _schoolManager.GetAll();
                Schools = _ratingStatisticService.LoadRanks(schoolsToLoad);
                return Page();
            }
            catch (Exception ex)
            {
                return RedirectToPage("/Errors/" + ErrorHandler.GetPath(ex));
            }
        }
    }
}