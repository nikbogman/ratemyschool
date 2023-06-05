using Core.Entities.SchoolEntities;
using Core.Interfaces;

namespace DAL.Repositories.SchoolRepositories
{
    public class BaseSchoolRepository : AbstractSchoolRepository<BaseSchoolEntity>, ISchoolRepository
    {
        public BaseSchoolRepository(string connectionString) : base(connectionString) { }
    }
}
