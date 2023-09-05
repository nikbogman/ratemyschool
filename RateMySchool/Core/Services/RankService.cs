using Core.Entities.Schools;
using Core.Enums.Schools;
using Core.Interfaces;
using Core.Interfaces.Repositories;
using Core.Structs;
using System.Data;

namespace Core.Services
{
    public class RankService
    {
        private readonly IReviewRepository _repository;
        private readonly IComparer<Rating> _comparer;
        private readonly IRankCalculator _calculator;

        public RankService(IReviewRepository repository, IComparer<Rating> comparer, IRankCalculator calculator)
        {
            _repository = repository;
            _comparer = comparer;
            _calculator = calculator;
        }

        public IEnumerable<SchoolEntity> LoadRanks(IEnumerable<SchoolEntity> schools)
        {
            DataTable result = _repository.AverageRatingForeachSchool();
            List<Rating> ratings = new();
            foreach (DataRow row in result.Rows)
            {
                Rating rating = new()
                {
                    value = Convert.ToSingle(row["average_rating"]),
                    info = new()
                    {
                        schoolId = Guid.Parse((string)row["school_id"]),
                        schoolCategoryType = row.GetEnumValue<SchoolCategoryType>("school_category_type")
                    }
                };
                ratings.Add(rating);
            }
            ratings.Sort(_comparer);
            foreach (SchoolEntity school in schools)
            {
                var calculation = _calculator.Calculate(school, ratings);
                school.SetStatistics(calculation);
            }
            return schools;
        }
    }
}
