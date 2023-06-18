using Core.Entities.SchoolEntities;
using Core.Interfaces;
using Core.Interfaces.RepositoryInterfaces;
using System.Data;

namespace Core.Services
{
    public class RankingService
    {
        private readonly IReviewRepository _repository;
        private readonly IComparer<RatingStatistic> _comparer;
        private readonly IRankingCalculator _calculator;

        public RankingService(IReviewRepository repository, IComparer<RatingStatistic> comparer, IRankingCalculator calculator)
        {
            _repository = repository;
            _comparer = comparer;
            _calculator = calculator;
        }

        public IEnumerable<BaseSchoolEntity> LoadRanks(IEnumerable<BaseSchoolEntity> schools)
        {
            DataTable result = _repository.AverageRatingForeachSchool();
            List<RatingStatistic> statistics = new();
            foreach (DataRow row in result.Rows)
            {
                statistics.Add(new(row));
            }
            statistics.Sort(_comparer);
            foreach (var school in schools)
            {
                var calculation = _calculator.Calculate(school, statistics);
                school.SetStatistics(calculation);
            }
            return schools;
        }
    }
}
