using Microsoft.AspNetCore.Mvc.RazorPages;
using DAL.Repositories;
using DAL.Repositories.SchoolRepositories;
using Core.Entities.SchoolEntities;
using Core.Managers.SchoolManagers;

namespace WebApp.Pages.Schools
{
    public class IndexModel : PageModel
    {
        private readonly SchoolsManager _schoolManager = new(
            repository: new BaseSchoolRepository("Server=localhost;Uid=root;Database=ratemyschool;Pwd=rootpass"),
            statisticsService: new(
                reviewManager: new(
                    repository: new ReviewRepository("Server=localhost;Uid=root;Database=ratemyschool;Pwd=rootpass")
                )
                )
        );

        public IEnumerable<BaseSchoolEntity> Schools { get; private set; }

        public void OnGet()
        {
            Schools = _schoolManager.GetAllWithStatistics();
        }
    }
}
