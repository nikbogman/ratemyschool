using Core.Entities.SchoolEntities;
using Core.Enums;
using Core.Interfaces;
using Core.Managers.FeatureManagers;

namespace Core.Managers.SchoolManagers
{
    public class SchoolsManager
    {

        private readonly ISchoolRepository _repository;
        private readonly StatisticService _statisticsService;
        public SchoolsManager(ISchoolRepository repository, StatisticService statisticsService)
        {
            _repository = repository;
            _statisticsService = statisticsService;
        }

        // move to one method
        public IEnumerable<BaseSchoolEntity> GetAllWithStatistics()
        {
            var schools = _repository.SelectAll();
            var statistics = this._statisticsService.GetStatistics();
            foreach(var school in schools)
            {
                BaseStatisticsService.SetStatisticsToSchool(school, statistics);
            }
            return schools;
        }
    }
}