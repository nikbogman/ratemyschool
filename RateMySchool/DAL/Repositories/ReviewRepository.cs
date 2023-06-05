using Core;
using Core.Entities;
using Core.Enums;
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
            catch (Exception ex)
            {
                connection.Dispose();
                throw DataAccessExceptionHandler.Handle(ex);
            }
        }

        public IEnumerable<ReviewEntity> SelectAllBySchoolId(Guid schoolId)
        {
            DataSet dataSet = new();
            using MySqlConnection connection = new(_connectionString);
            connection.Open();
            using MySqlCommand command = connection.CreateCommand();
            command.CommandText = $"SELECT * FROM {_mapper.TableName} WHERE school_id = @school_id";
            command.Parameters.AddWithValue("@school_id", schoolId);
            using MySqlDataAdapter adapter = new(command);
            adapter.Fill(dataSet);
            List<ReviewEntity> entities = new();
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                var entity = new ReviewEntity(row);
                entities.Add(entity);
            }
            return entities;
        }

        public float AverageRatingOfSchool(Guid schoolId)
        {
            using MySqlConnection connection = new(_connectionString);
            connection.Open();
            using MySqlCommand command = connection.CreateCommand();
            command.CommandText = $"SELECT AVG(rating) FROM {_mapper.TableName} WHERE school_id = @school_id";
            command.Parameters.AddWithValue("@school_id", schoolId);
            object scalar = command.ExecuteScalar();
            if (scalar == DBNull.Value)
            {
                return 0;
            }
            return Convert.ToSingle(scalar);
        }

        public DataTable AverageRatingForeachSchool()
        {
            using MySqlConnection connection = new(_connectionString);
            connection.Open();
            using MySqlCommand command = connection.CreateCommand();
            command.CommandText = @$"
                SELECT r.school_id, AVG(r.rating) AS average_rating, s.type
                FROM review AS r
                JOIN school AS s 
                ON r.school_id = s.id
                GROUP BY r.school_id, s.type";
            DataTable dataTable = new DataTable();
            dataTable.Load(command.ExecuteReader());
            return dataTable;
        }
    }
}