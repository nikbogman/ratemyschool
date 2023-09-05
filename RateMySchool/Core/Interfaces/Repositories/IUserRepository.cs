using Core.Entities;

namespace Core.Interfaces.Repositories
{
    public interface IUserRepository : IRepository<UserEntity>
    {
        public UserEntity? SelectOneByEmail(string email);
    }
}
