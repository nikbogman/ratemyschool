using Core.Entities.SchoolEntities;
using Core.Interfaces;

namespace DAL.Repositories.SchoolRepositories
{
    public class STEMSchoolRepository : AbstractSchoolRepository<STEMSchoolEntity>, ISTEMSchoolRepository
    {
        public STEMSchoolRepository(string connectionString) : base(connectionString) { }
    }
}
