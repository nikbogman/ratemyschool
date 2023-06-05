using Core.Entities;

namespace Core.Interfaces
{
    public interface IUserRepository : IRepository<UserEntity>
    {
        public UserEntity? SelectOneByEmail(string email);
    }
}
