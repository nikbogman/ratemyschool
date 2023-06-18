using Core.Entities.SchoolEntities;
using Core.Exceptions;
using Core.Interfaces.RepositoryInterfaces;
using Core.Managers;
using Core.ViewModels.SchoolViewModels;
using Tests.MockRepositories;

namespace Tests.InputValidationTests
{
    [TestFixture]
    public class DistinctLanguages
    {
        private LanguageSchoolManager _manager;
        
        [SetUp]
        public void SetUp()
        {
            IRepository<LanguageSchoolEntity> repository = new MockRepository<LanguageSchoolEntity>();
            _manager = new(repository);
        }

        [Test]
        public void TestDistinctLanguagesBeforeSavingLanguageSchool()
        {
            LanguageSchoolViewModel viewModel = new()
            {
                Name = "Test1",
                City = "TestCity1",
                Number = 1,
                PrimaryLanguage = "Test",
                SecondaryLanguage = "Test",
            };
            TestDelegate action = () => { _manager.viewModelParser(viewModel); };
            Assert.Throws<InputValidationException>(action);
        }
    }
}
