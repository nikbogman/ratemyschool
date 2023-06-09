using Core.Entities.SchoolEntities;
using Core.Interfaces.RepositoryInterfaces;
using Core.ViewModels.SchoolViewModels;
using Core.FeatureManagers;
using Core.Exceptions;
namespace Core.Managers.SchoolManagers
{
    public class LanguageSchoolManager : BaseManager<LanguageSchoolEntity, LanguageSchoolViewModel>
    {
        public LanguageSchoolManager(IRepository<LanguageSchoolEntity> repository) : base(repository) { }

        public override LanguageSchoolViewModel viewModelParser(LanguageSchoolViewModel viewModel)
        {
            if (viewModel.PrimaryLanguage == viewModel.SecondaryLanguage)
            {
                throw new InputValidationException("The two languages must be different in order to save `LanguageSchool`");
            }
            return viewModel;
        }
    }
}
