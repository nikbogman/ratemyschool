using Core.Entities;
using Core.Interfaces;
using Core.ViewModels;
using System.Data;

namespace Core.Managers
{
    public class ReviewManager: BaseManager<ReviewEntity, ReviewViewModel>
    {
        public ReviewManager(IReviewRepository repository): base(repository) { }

        protected override IReviewRepository getRepository() => (IReviewRepository)base.getRepository();

        public IEnumerable<ReviewEntity> GetAllBySchoolId(Guid schoolId)
        {
            return getRepository().SelectAllBySchoolId(schoolId);
        }

        public float GetAverageRatingOfSchool(Guid schoolId)
        {
            return getRepository().AverageRatingOfSchool(schoolId);
        }

        public List<RatingStatistic> GetAverageRatingForeachSchool()
        {
            var result = getRepository().AverageRatingForeachSchool();
            List<RatingStatistic> statistics = new();
            if (result.Rows.Count <= 0)
            {
                return new();
            }
            foreach (DataRow row in result.Rows)
            {
                statistics.Add(new(row));
            }
            return statistics;
        }
    }
}