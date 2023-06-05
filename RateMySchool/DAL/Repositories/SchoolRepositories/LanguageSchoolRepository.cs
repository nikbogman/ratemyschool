using Core.Entities.SchoolEntities;
using Core.Interfaces;

namespace DAL.Repositories.SchoolRepositories
{
    public class LanguageSchoolRepository : AbstractSchoolRepository<LanguageSchoolEntity>, ILanguageSchoolRepository
    {
        public LanguageSchoolRepository(string connectionString) : base(connectionString) { }
    }
}
