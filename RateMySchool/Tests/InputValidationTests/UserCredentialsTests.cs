using Core.Exceptions;
using Core.Interfaces;
using Core.Interfaces.Repositories;
using Core.Managers;
using Core.Models;
using Tests.MockRepositories;

namespace Tests.InputValidationTests
{
    [TestFixture]
    public class UserCredentialsTests
    {
        private UserManager manager;
        private readonly UserModel viewModel = new() { Email = "email@email" };

        [SetUp]
        public void SetUp()
        {
            IUserRepository repository = new MockUserRepository();
            manager = new(repository);
        }

        [Test]
        public void TestEmailUniqnessBeforeSavingUser()
        {
            string email = "email@email";
            string password = "P@ssw0rd";
            UserModel viewModel1 = new() { Email = email, Password = password };
            UserModel viewModel2 = new() { Email = email, Password = password };
            manager.CreateOne(viewModel1);
            TestDelegate action = delegate () { manager.viewModelParser(viewModel2); };
            var exception = Assert.Throws<InputValidationException>(action);
            Assert.AreEqual(exception.Message, "Provided email is not unique. User with this email alredy exists");
        }

        [Test]
        public void TestPasswordVerification()
        {
            UserModel viewModel1 = new() { Email = "email1@email1", Password = "P@ssw0rd" };
            manager.CreateOne(viewModel1);
            TestDelegate action = delegate () { manager.GetOneWithCredentials("email1@email1", "password"); };
            Assert.Throws<UnauthorizedException>(action);
        }


        [Test]
        public void TestStrongPassword_AtLeastOneUppercaseLetter()
        {
            viewModel.Password = "password";
            string expectedMessage = "Password not strong enough. It should contain at least one uppercase letter.";
            Exception exception = Assert.Throws<InputValidationException>(() => manager.viewModelParser(viewModel));
            Assert.AreEqual(exception.Message, expectedMessage);
        }

        [Test]
        public void TestStrongPassword_AtLeastOneLowercaseLetter()
        {
            viewModel.Password = "PASSWORD";
            string expectedMessage = "Password not strong enough. It should contain at least one lowercase letter.";
            Exception exception = Assert.Throws<InputValidationException>(() => manager.viewModelParser(viewModel));
            Assert.AreEqual(exception.Message, expectedMessage);
        }


        [Test]
        public void TestStrongPassword_AtLeastOneDigit()
        {
            viewModel.Password = "Password";
            string expectedMessage = "Password not strong enough. It should contain at least one digit.";
            Exception exception = Assert.Throws<InputValidationException>(() => manager.viewModelParser(viewModel));
            Assert.AreEqual(exception.Message, expectedMessage);
        }

        [Test]
        public void TestStrongPassword_AtLeastOneSpecialLetter()
        {
            viewModel.Password = "Passw0rd";
            string expectedMessage = "Password not strong enough. It should contain at least one special letter.";
            Exception exception = Assert.Throws<InputValidationException>(() => manager.viewModelParser(viewModel));
            Assert.AreEqual(exception.Message, expectedMessage);
        }

        [Test]
        public void TestUserViewModelPaserSuccess()
        {
            viewModel.Password = "P@ssw0rd";
            UserModel result = manager.viewModelParser(viewModel);
            Assert.AreNotEqual(result.Password, "P@ssw0rd");
        }
    }
}
