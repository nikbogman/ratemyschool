using Core.Entities.SchoolEntities;
using Core.Enums;
using Core.Interfaces;

namespace Core.Managers.SchoolManagers
{
    public class SchoolsManager
    {
        private readonly ISchoolRepository _repository;
        private readonly ReviewManager _reviewManager;
        public SchoolsManager(ISchoolRepository repository, ReviewManager reviewManager)
        {
            _repository = repository;
            _reviewManager = reviewManager;
        }

        public IEnumerable<BaseSchoolEntity> GetAllWithStatistics()
        {
            var allStatistics = _reviewManager
                .GetAverageRatingForeachSchool()
                .Where(stat => stat.Average > 0)
                .OrderByDescending(stat => stat.Average);
            var schools = _repository.SelectAll();

            int overAllRank = 1;
            int typeRank = 1;
            SchoolType prevType = schools.First().Type;
            foreach (var statistic in allStatistics)
            {
                var school = schools.Single(school => school.Id == statistic.SchoolId);
                school.Rating = statistic.Average;
                school.OverallRank = overAllRank;
                if (statistic.SchoolType == prevType)
                {
                    school.TypeRank = typeRank;
                }
                else
                {
                    prevType = statistic.SchoolType;
                    typeRank = 1;
                    school.TypeRank = typeRank;
                }
                typeRank++;
                overAllRank++;
            }
            return schools;
        }

    }
}