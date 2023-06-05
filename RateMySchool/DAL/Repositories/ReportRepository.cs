using Core.Entities;
using Core.Interfaces;

namespace DAL.Repositories
{
    public class ReportRepository : AbstractRepository<ReportEntity>, IReportRepository
    {
        public ReportRepository(string connectionString) : base(connectionString) { }
    }
}
