using System.Data;
using Core.Entities;

namespace Core.Interfaces.Repositories
{
    public interface IReviewRepository : IRepository<ReviewEntity>
    {
        public IEnumerable<ReviewEntity> SelectAllBySchoolId(Guid schoolId);
        public DataTable AverageRatingForeachSchool();
        public bool UpdateReportedStatus(Guid id);
    }
}
