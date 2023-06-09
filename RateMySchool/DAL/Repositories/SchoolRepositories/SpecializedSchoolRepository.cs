using Core.Entities.SchoolEntities;
using Core.Interfaces.RepositoryInterfaces;

namespace DAL.Repositories.SchoolRepositories
{
    public class SpecializedSchoolRepository : AbstractSchoolRepository<SpecializedSchoolEntity>, IRepository<SpecializedSchoolEntity>
    {
        public SpecializedSchoolRepository(string connectionString) : base(connectionString) { }
    }
}
