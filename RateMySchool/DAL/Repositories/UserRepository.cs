using Core.Entities;
using Core.Interfaces;
using MySql.Data.MySqlClient;
using System.Data;

namespace DAL.Repositories
{
    public class UserRepository : AbstractRepository<UserEntity>, IUserRepository
    {
        public UserRepository(string connectionString) : base(connectionString) { }

        public UserEntity? SelectOneByEmail(string email)
        {
            DataSet dataSet = new();
            using MySqlConnection connection = new(_connectionString);
            connection.Open();
            using MySqlCommand command = connection.CreateCommand();
            command.CommandText = $"SELECT * FROM user WHERE email=@email";
            command.Parameters.AddWithValue("@email", email);
            using MySqlDataAdapter adapter = new(command);
            adapter.Fill(dataSet);
            if (dataSet.Tables[0].Rows.Count == 0)
            {
                return null;
            }
            DataRow row = dataSet.Tables[0].Rows[0];
            return new UserEntity(row);
        }
    }
}
