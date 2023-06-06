using Core.Entities.SchoolEntities;
using Core.Interfaces;
using Core.Enums;
using Core.ViewModels.SchoolViewModels;
using Core.Exceptions;
using Core.Managers.FeatureManagers;

namespace Core.Managers.SchoolManagers
{
    public class LanguageSchoolManager : BaseManager<LanguageSchoolEntity, LanguageSchoolViewModel>
    {
        private readonly StatisticService _statisticsService;
        public LanguageSchoolManager(ILanguageSchoolRepository repository, StatisticService statisticsService) : base(repository)
        {
            _statisticsService = statisticsService;
        }
        public LanguageSchoolManager(ILanguageSchoolRepository repository) : base(repository) { }
        protected override ILanguageSchoolRepository getRepository() => (ILanguageSchoolRepository)base.getRepository();

        // move to one method probably
        public override LanguageSchoolEntity GetOneById(Guid id)
        {
            var entity = base.GetOneById(id);
            var statistics = this._statisticsService.GetStatistics();
            BaseStatisticsService.SetStatisticsToSchool(entity, statistics);
            return entity;
        }

    }
}
