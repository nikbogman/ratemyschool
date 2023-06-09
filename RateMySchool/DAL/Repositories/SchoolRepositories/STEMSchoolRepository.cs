using Core.Entities.SchoolEntities;
using Core.Interfaces.RepositoryInterfaces;

namespace DAL.Repositories.SchoolRepositories
{
    public class STEMSchoolRepository : AbstractSchoolRepository<STEMSchoolEntity>, IRepository<STEMSchoolEntity>
    {
        public STEMSchoolRepository(string connectionString) : base(connectionString) { }
    }
}
