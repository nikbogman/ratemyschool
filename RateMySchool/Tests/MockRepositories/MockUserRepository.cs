using Core.Entities;
using Core.Interfaces.Repositories;

namespace Tests.MockRepositories
{
    internal class MockUserRepository : MockRepository<UserEntity>, IUserRepository
    {
        public UserEntity? SelectOneByEmail(string email) => _mockData.Find(user => user.Email == email);
    }
}
