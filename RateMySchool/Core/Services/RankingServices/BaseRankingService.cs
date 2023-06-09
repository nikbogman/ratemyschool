using Core.Entities.SchoolEntities;
using Core.Exceptions;
using Core.Interfaces.RepositoryInterfaces;
using System.Data;
using System.Diagnostics;

namespace Core.Services.StatisticServices
{
    public class BaseRankingService
    {
        private readonly IReviewRepository _repository;
        private readonly IComparer<Statistic> _comparer;
        public BaseRankingService(IReviewRepository repository, IComparer<Statistic> comparer)
        {
            _repository = repository;
            _comparer = comparer;
        }

        public virtual void CalculateAndSetRanks(BaseSchoolEntity school, IEnumerable<Statistic> statistics)
        {
            int overAllRank = 1;
            foreach (var statistic in statistics)
            {
                if (statistic.SchoolId == school.Id)
                {
                    school.Rating = statistic.AverageRating;
                    school.Rank = new()
                    {
                        { "Overall", overAllRank }
                    };
                    break;
                }
                overAllRank++;
            }
        }

        public virtual IEnumerable<BaseSchoolEntity> LoadRanks(IEnumerable<BaseSchoolEntity> schools)
        {
            DataTable result = _repository.AverageRatingForeachSchool();
            List<Statistic> statistics = new();
            foreach (DataRow row in result.Rows)
            {
                statistics.Add(new(row));
            }
            statistics.Sort(_comparer);
            foreach (var school in schools)
            {
                CalculateAndSetRanks(school, statistics);
            }
            return schools;
        }
    }
}
