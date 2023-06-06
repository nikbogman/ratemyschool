using Core;
using Core.Entities;
using Core.Enums;
using Core.Exceptions;
using Core.Interfaces;
using MySql.Data.MySqlClient;
using System.Data;

namespace DAL.Repositories
{
    public class ReviewRepository : AbstractRepository<ReviewEntity>, IReviewRepository
    {
        public ReviewRepository(string connectionString) : base(connectionString) { }

        public new bool Delete(Guid id)
        {
            MySqlConnection connection = new(_connectionString);
            try
            {
                connection.Open();
                using MySqlCommand command = connection.CreateCommand();
                command.CommandText = $"UPDATE {_mapper.TableName} SET active = false WHERE id = @id";
                command.Parameters.AddWithValue("@id", id);

                bool success = command.ExecuteNonQuery() > 0;
                connection.Close();
                return success;
            }
            catch (MySqlException ex)
            {
                throw new DataAccessException($"Unexpected error occured with code {ex.Number}", ex);
            }
            catch (Exception) { throw; }
            finally
            { if (connection.State == ConnectionState.Open) connection.Dispose(); }
        }

        public IEnumerable<ReviewEntity> SelectAllBySchoolId(Guid schoolId)
        {
            MySqlConnection connection = new(_connectionString);
            try
            {
                DataSet dataSet = new();
                using MySqlCommand command = connection.CreateCommand();
                command.CommandText = $"SELECT * FROM {_mapper.TableName} WHERE school_id = @school_id";
                command.Parameters.AddWithValue("@school_id", schoolId);

                connection.Open();
                using MySqlDataAdapter adapter = new(command);
                adapter.Fill(dataSet);
                connection.Close();

                List<ReviewEntity> entities = new();
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    var entity = new ReviewEntity(row);
                    entities.Add(entity);
                }
                return entities;
            }
            catch (MySqlException ex)
            {
                throw new DataAccessException($"Unexpected error occured with code {ex.Number}", ex);
            }
            catch (Exception) { throw; }
            finally { if (connection.State == ConnectionState.Open) connection.Dispose(); }
        }

        public float AverageRatingOfSchool(Guid schoolId)
        {
            MySqlConnection connection = new(_connectionString);
            try
            {
                using MySqlCommand command = connection.CreateCommand();
                command.CommandText = $"SELECT AVG(rating) FROM {_mapper.TableName} WHERE school_id = @school_id";
                command.Parameters.AddWithValue("@school_id", schoolId);
                connection.Open();
                object scalar = command.ExecuteScalar();
                connection.Close();
                if (scalar == DBNull.Value) { return 0; }
                return Convert.ToSingle(scalar);
            }
            catch (MySqlException ex)
            {
                throw new DataAccessException($"Unexpected error occured with code {ex.Number}", ex);
            }
            catch (Exception) { throw; }
            finally { if (connection.State == ConnectionState.Open) connection.Dispose(); }
        }

        public DataTable AverageRatingForeachSchool()
        {
            MySqlConnection connection = new(_connectionString);
            try
            {
                using MySqlCommand command = connection.CreateCommand();
                command.CommandText = @$"
                SELECT r.school_id, AVG(r.rating) AS average_rating, s.type, s.city, u.birth_year
                FROM review AS r
                JOIN school AS s 
                ON r.school_id = s.id
                JOIN user AS u
                ON r.user_id = u.id
                GROUP BY r.school_id, s.type, u.birth_year, s.city";
                connection.Open();
                DataTable dataTable = new DataTable();
                dataTable.Load(command.ExecuteReader());
                connection.Close();
                return dataTable;
            }
            catch (MySqlException ex)
            {
                throw new DataAccessException($"Unexpected error occured with code {ex.Number}", ex);
            }
            catch (Exception) { throw; }
            finally { if (connection.State == ConnectionState.Open) connection.Dispose(); }
        }
    }
}