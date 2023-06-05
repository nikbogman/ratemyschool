using Core.Entities.SchoolEntities;
using Core.Enums;
using Core.Exceptions;
using Core.Interfaces;
using Core.ViewModels.SchoolViewModels;

namespace Core.Managers.SchoolManagers
{
    public class STEMSchoolManager : BaseManager<STEMSchoolEntity, STEMSchoolViewModel>
    {
        public STEMSchoolManager(ISTEMSchoolRepository repository) : base(repository) { }

        protected override ISTEMSchoolRepository getRepository() => (ISTEMSchoolRepository)base.getRepository();

        public STEMSchoolEntity GetOneById(Guid id, ReviewManager reviewManager)
        {
            STEMSchoolEntity? entity = getRepository().SelectOne(id);
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
