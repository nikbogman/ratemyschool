using Core.Entities.SchoolEntities;
using Core.Interfaces.RepositoryInterfaces;
using Core.ViewModels.SchoolViewModels;
using Core.FeatureManagers;

namespace Core.Managers.SchoolManagers
{
    public class SpecializedSchoolManager : BaseManager<SpecializedSchoolEntity, SpecializedSchoolViewModel>
    {
        public SpecializedSchoolManager(IRepository<SpecializedSchoolEntity> repository) : base(repository) { }
    }
}
