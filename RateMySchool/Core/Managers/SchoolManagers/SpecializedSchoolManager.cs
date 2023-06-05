using Core.Entities.SchoolEntities;
using Core.Enums;
using Core.Exceptions;
using Core.Interfaces;
using Core.ViewModels.SchoolViewModels;

namespace Core.Managers.SchoolManagers
{
    public class SpecializedSchoolManager : BaseManager<SpecializedSchoolEntity, SpecializedSchoolViewModel>
    {
        public SpecializedSchoolManager(ISpecializedSchoolRepository repository) : base(repository) { }

        protected override ISpecializedSchoolRepository getRepository() => (ISpecializedSchoolRepository)base.getRepository();

        public SpecializedSchoolEntity GetOneById(Guid id, ReviewManager reviewManager)
        {
            SpecializedSchoolEntity? entity = getRepository().SelectOne(id);
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