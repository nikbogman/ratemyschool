using Core.Entities;
using System.Data;

namespace Core.Interfaces.RepositoryInterfaces
{
    public interface IReviewRepository : IRepository<ReviewEntity>
    {
        public IEnumerable<ReviewEntity> SelectAllBySchoolId(Guid schoolId);
        public DataTable AverageRatingForeachSchool();
        public bool UpdateReportedStatus(Guid id);
    }
}
