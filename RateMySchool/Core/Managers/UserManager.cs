using Core.Interfaces;
using Core.Entities;
using Core.ViewModels;
using System.Text.RegularExpressions;
using Core.Exceptions;

namespace Core.Managers
{
    public class UserManager : BaseManager<UserEntity, UserViewModel>
    {
        public UserManager(IUserRepository repository) : base(repository) { }

        protected override IUserRepository getRepository() => (IUserRepository)base.getRepository();

        public UserEntity GetOneWithCredentials(string email, string password)
        {
            UserEntity? user = getRepository().SelectOneByEmail(email);
            if (user == null)
            {
                throw new NotFoundException($"No `user` with `email`:{email} was found.");
            }
            if (!BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                throw new InputValidationException("Password credential for `user` is not correct.");
            }
            return user;
        }

        protected override UserViewModel viewModelParser(UserViewModel viewModel)
        {
            if (!new Regex("^(?=.*?[A-Z])").IsMatch(viewModel.Password))
            {
                throw new InputValidationException("Password not strong enough. It should contain at least one uppercase letter.");
            }
            else if (!new Regex("^(?=.*?[a-z])").IsMatch(viewModel.Password))
            {
                throw new InputValidationException("Password not strong enough. It should contain at least one lowercase letter.");
            }
            else if (!new Regex("^(?=.*?[0-9])").IsMatch(viewModel.Password))
            {
                throw new InputValidationException("Password not strong enough. It should contain at least one digit.");
            }
            else if (!new Regex("^(?=.*?[#?!@$%^&*-])").IsMatch(viewModel.Password))
            {
                throw new InputValidationException("Password not strong enough. It should contain at least one special letter.");
            }
            viewModel.Password = BCrypt.Net.BCrypt.HashPassword(viewModel.Password);
            return viewModel;
        }
    }
}
