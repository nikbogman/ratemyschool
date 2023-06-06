using Core.Entities.SchoolEntities;
using Core.Interfaces;
using System.Data;

namespace Core.Managers.FeatureManagers
{
    public abstract class BaseStatisticsService
    {
        private readonly IReviewRepository _repository;
        public BaseStatisticsService(IReviewRepository repository)
        {
            _repository = repository;
        }
        
        protected virtual List<RatingStatistic> FilterStatistics(List<RatingStatistic> statistics) 
        { 
            return statistics;
        }

        public List<RatingStatistic> GetStatistics()
        {
            var result = _repository.AverageRatingForeachSchool();
            List<RatingStatistic> statistics = new();
            foreach (DataRow row in result.Rows)
            {
                statistics.Add(new(row));
            }
            return FilterStatistics(statistics);
        }

        public void SetStatisticsToSchool(
            BaseSchoolEntity school, 
            IEnumerable<RatingStatistic> statistics
        ) {
            int overAllRank = 1;
            int typeRank = 1;
            foreach (var statistic in statistics)
            {
                if (statistic.SchoolId == school.Id)
                {
                    school.Rating = statistic.Average;
                    school.OverallRank = overAllRank;
                    school.TypeRank = typeRank;
                    break;
                }
                if (statistic.SchoolType == school.Type)
                {
                    typeRank++;
                }
                overAllRank++;
            }
            return;
        }
    }


}
