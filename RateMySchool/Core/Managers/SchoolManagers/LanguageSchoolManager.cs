using Core.Entities.SchoolEntities;
using Core.Interfaces;
using Core.Enums;
using Core.ViewModels.SchoolViewModels;
using Core.Exceptions;

namespace Core.Managers.SchoolManagers
{
    public class LanguageSchoolManager : BaseManager<LanguageSchoolEntity, LanguageSchoolViewModel>
    {
        public LanguageSchoolManager(ILanguageSchoolRepository repository) : base(repository) { }

        protected override ILanguageSchoolRepository getRepository() => (ILanguageSchoolRepository)base.getRepository();

        public LanguageSchoolEntity GetOneById(Guid id, ReviewManager reviewManager)
        {
            LanguageSchoolEntity? entity = getRepository().SelectOne(id);
            if (entity == null)
            {
                throw new NotFoundException($"No `{_entityName}` with `id`:{id} was found");
            }

            float avrgRating = reviewManager.GetAverageRatingOfSchool(id);
            if (avrgRating == 0)
            {
                return entity;
            }
            entity.Rating = avrgRating;

            var allStatistics = reviewManager
                .GetAverageRatingForeachSchool()
                .Where(stat => stat.Average > 0)
                .OrderByDescending(stat => stat.Average);

            int overAllRank = 1;
            int typeRank = 1;
            SchoolType prevType = allStatistics.First().SchoolType;
            foreach (var statistic in allStatistics)
            {
                if (statistic.SchoolId == id)
                {
                    entity.OverallRank = overAllRank;
                    entity.TypeRank = typeRank;
                    break;
                }
                if (statistic.SchoolType == entity.Type)
                {
                    typeRank++;
                }
                overAllRank++;
            }
            return entity;
        }
    }
}
