using Core.Interfaces.RepositoryInterfaces;
using Core.Entities;
using Core.ViewModels;
using System.Text.RegularExpressions;
using Core.Exceptions;
using System.Diagnostics;

namespace Core.Managers
{
    public class UserManager : BaseManager<UserEntity, UserViewModel>
    {
        public UserManager(IUserRepository repository) : base(repository) { }

        protected override IUserRepository Repository { get => (IUserRepository)base.Repository; }

        public UserEntity GetOneWithCredentials(string email, string password)
        {

            UserEntity? user = Repository.SelectOneByEmail(email);
            if (user == null)
            {
                throw new NotFoundException($"No `user` with `email`:{email} was found.");
            }
            if (!BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                throw new UnauthorizedException("Password credential for `user` is not correct.");
            }
            return user;
        }

        public override UserViewModel viewModelParser(UserViewModel viewModel)
        {
            if (Repository.SelectOneByEmail(viewModel.Email) != null)
            {
                throw new InputValidationException($"Provided email is not unique. User with this email alredy exists");
            }
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
