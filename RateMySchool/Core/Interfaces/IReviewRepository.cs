using Core.Entities;
using System.Data;

namespace Core.Interfaces
{
    public interface IReviewRepository : IRepository<ReviewEntity>
    {
        public IEnumerable<ReviewEntity> SelectAllBySchoolId(Guid schoolId);
        public float AverageRatingOfSchool(Guid schoolId);
        public DataTable AverageRatingForeachSchool();
    }
}
