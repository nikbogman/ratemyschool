using Core.Entities;
namespace Core.Interfaces.RepositoryInterfaces
{
    public interface IUserRepository : IRepository<UserEntity>
    {
        public UserEntity? SelectOneByEmail(string email);
    }
}
