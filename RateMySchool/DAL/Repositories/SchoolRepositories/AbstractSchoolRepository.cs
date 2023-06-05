using Core.Entities.SchoolEntities;
using Core.Interfaces;
using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using System.Data;

namespace DAL.Repositories.SchoolRepositories
{
    public abstract class AbstractSchoolRepository<SchoolEntityT> : IRepository<SchoolEntityT> where SchoolEntityT : BaseSchoolEntity
    {
        protected readonly string _connectionString;
        protected readonly EntityMapper<SchoolEntityT> _childMapper = new();
        protected readonly EntityMapper<BaseSchoolEntity> _parentMapper = new();
        public AbstractSchoolRepository(string connectionString) { _connectionString = connectionString; }

        public IEnumerable<SchoolEntityT> SelectAll()
        {
            MySqlConnection connection = new(_connectionString);
            try
            {
                using MySqlCommand command = connection.CreateCommand();
                command.CommandText = @$"
                    SELECT * FROM {_childMapper.TableName} AS child
                    INNER JOIN {_parentMapper.TableName} AS parent
                    ON parent.id = child.id;
                ";
                connection.Open();
                using MySqlDataAdapter adapter = new(command);
                DataSet dataSet = new();
                adapter.Fill(dataSet);
                connection.Close();

                List<SchoolEntityT> entities = new();
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    var entity = Activator.CreateInstance(typeof(SchoolEntityT), row);
                    if (entity == null) { continue; }
                    entities.Add((SchoolEntityT)entity);
                }
                return entities;
            }
            catch (Exception ex)
            {
                connection.Dispose();
                throw DataAccessExceptionHandler.Handle(ex);
            }
        }

        public SchoolEntityT? SelectOne(Guid id)
        {
            MySqlConnection connection = new(_connectionString);
            try
            {
                DataSet dataSet = new();
                using MySqlCommand command = connection.CreateCommand();
                command.CommandText = @$"
                    SELECT * FROM {_childMapper.TableName} AS child
                    INNER JOIN {_parentMapper.TableName} AS parent
                    ON parent.id = child.id 
                    WHERE child.id = @id
                ";
                command.Parameters.AddWithValue("@id", id);

                connection.Open();
                using MySqlDataAdapter adapter = new(command);
                adapter.Fill(dataSet);
                connection.Close();
                if (dataSet.Tables[0].Rows.Count == 0)
                {
                    return default;
                }

                DataRow row = dataSet.Tables[0].Rows[0];
                var entity = Activator.CreateInstance(typeof(SchoolEntityT), row);
                if (entity == null) { return default; }
                return (SchoolEntityT)entity;
            }
            catch (Exception ex)
            {
                connection.Dispose();
                throw DataAccessExceptionHandler.Handle(ex);
            }
        }

        public bool Insert(SchoolEntityT entity)
        {
            MySqlConnection connection = new(_connectionString);
            try
            {
                string[] parentColumnNames = _parentMapper.GetColumnNames();
                string parentColumns = string.Join(", ", parentColumnNames);
                string parentValues = string.Join(", ", parentColumnNames.Select(c => "@" + c));

                string[] columnNames = _childMapper.GetColumnNames();
                string columns = string.Join(", ", columnNames);
                string values = string.Join(", ", columnNames.Select(c => "@" + c));

                bool success = false;
                connection.Open();
                MySqlTransaction transaction = connection.BeginTransaction();
                try
                {
                    using (MySqlCommand command = connection.CreateCommand())
                    {
                        command.Transaction = transaction;
                        command.CommandText = $"INSERT INTO {_parentMapper.TableName} ({parentColumns}) VALUES ({parentValues})";
                        _parentMapper.MapCommandParameters(command.Parameters, entity);
                        success = command.ExecuteNonQuery() > 0;
                    }
                    using (MySqlCommand command = connection.CreateCommand())
                    {
                        command.Transaction = transaction;
                        command.CommandText = $"INSERT INTO {_childMapper.TableName} ({columns}) VALUES ({values})";
                        _childMapper.MapCommandParameters(command.Parameters, entity);
                        success = command.ExecuteNonQuery() > 0;
                    }
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
                connection.Close();
                return success;
            }
            catch (Exception ex)
            {
                connection.Dispose();
                throw DataAccessExceptionHandler.Handle(ex);
            }
        }
        public bool Update(SchoolEntityT entity)
        {
            MySqlConnection connection = new(_connectionString);
            try
            {
                connection.Open();
                using MySqlCommand command = connection.CreateCommand();
                command.CommandText = @$"
                    UPDATE {_childMapper.TableName} AS child 
                    INNER JOIN {_parentMapper.TableName} AS parent 
                    ON child.id = parent.id 
                    SET {_childMapper.GetClausesString("child")}, {_parentMapper.GetClausesString("parent")} 
                    WHERE child.id = @id
                ";
                _parentMapper.MapCommandParameters(command.Parameters, entity);
                _childMapper.MapCommandParameters(command.Parameters, entity);

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
        public bool Delete(Guid id)
        {
            MySqlConnection connection = new(_connectionString);
            try
            {
                connection.Open();
                using MySqlCommand command = connection.CreateCommand();
                command.CommandText = @$"
                    DELETE {_childMapper.TableName}, {_parentMapper.TableName}
                    FROM {_childMapper.TableName} 
                    INNER JOIN {_parentMapper.TableName} 
                    ON {_parentMapper.TableName}.id = {_childMapper.TableName}.id
                    WHERE {_childMapper.TableName}.id = @id
                ";
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
    }
}