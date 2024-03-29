﻿using MySql.Data.MySqlClient;
using Core.Entities;
using Core.Exceptions;
using Core.Interfaces.Repositories;

namespace DataAccess.Repositories
{
    public class UserRepository : Repository<UserEntity>, IUserRepository
    {
        public UserRepository(string connectionString) : base(connectionString) { }

        public UserEntity? SelectOneByEmail(string email)
        {
            MySqlConnection connection = new(_connectionString);
            try
            {
                using MySqlCommand command = connection.CreateCommand();
                command.CommandText = $"SELECT * FROM user WHERE email = @email";
                command.Parameters.AddWithValue("@email", email);
                connection.Open();

                using MySqlDataAdapter adapter = new(command);
                DataSet dataSet = new();
                adapter.Fill(dataSet);
                connection.Close();

                if (dataSet.Tables[0].Rows.Count == 0)
                {
                    return null;
                }
                DataRow row = dataSet.Tables[0].Rows[0];
                return new UserEntity(row);
            }
            catch (MySqlException ex)
            {
                throw new DataAccessException($"Unexpected error occured with code {ex.Number}", ex);
            }
            catch (Exception) { throw; }
            finally
            { if (connection.State == ConnectionState.Open) connection.Dispose(); }
        }

    }
}
