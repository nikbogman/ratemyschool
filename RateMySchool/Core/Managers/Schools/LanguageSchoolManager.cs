using Core.FeatureManagers;
using Core.Exceptions;
using Core.Entities.Schools;
using Core.Interfaces.Repositories;
using Core.Models.Schools;

namespace Core.Managers.Schools
{
    public class LanguageSchoolManager : Manager<LanguageSchoolEntity, LanguageSchoolModel>
    {
        public LanguageSchoolManager(IRepository<LanguageSchoolEntity> repository) : base(repository) { }

        public override LanguageSchoolModel viewModelParser(LanguageSchoolModel viewModel)
        {
            if (viewModel.PrimaryLanguage == viewModel.SecondaryLanguage)
            {
                throw new InputValidationException("The two languages must be different in order to save `LanguageSchool`");
            }
            return viewModel;
        }
    }
}
