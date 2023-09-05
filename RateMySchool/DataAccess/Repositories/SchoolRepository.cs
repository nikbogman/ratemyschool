using System.Data;
using MySql.Data.MySqlClient;
using Core.Exceptions;
using Core.Entities.Schools;
using Core.Interfaces.Repositories;

namespace DataAccess.Repositories
{
    public class SchoolRepository<SchoolEntityT> : IRepository<SchoolEntityT> where SchoolEntityT : SchoolEntity
    {
        protected readonly string _connectionString;
        protected readonly EntityMapper<SchoolEntityT> _childMapper = new();
        protected readonly EntityMapper<SchoolEntity> _parentMapper = new();
        public SchoolRepository(string connectionString) { _connectionString = connectionString; }

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
            catch (MySqlException ex)
            {
                throw new DataAccessException($"Unexpected error occured with code {ex.Number}", ex);
            }
            catch (Exception) { throw; }
            finally
            {
                if (connection.State == ConnectionState.Open) connection.Dispose();
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
            catch (MySqlException ex)
            {
                throw new DataAccessException($"Unexpected error occured with code {ex.Number}", ex);
            }
            catch (Exception) { throw; }
            finally
            {
                if (connection.State == ConnectionState.Open) connection.Dispose();
            }
        }

        public bool Insert(SchoolEntityT entity)
        {
            MySqlConnection connection = new(_connectionString);
            try
            {
                Dictionary<string, string> parentMapStr = _parentMapper.GetCommandTextMapStrings();
                Dictionary<string, string> childMapStr = _childMapper.GetCommandTextMapStrings();

                bool success = false;
                connection.Open();
                MySqlTransaction transaction = connection.BeginTransaction();
                try
                {
                    using (MySqlCommand command = connection.CreateCommand())
                    {
                        command.Transaction = transaction;
                        command.CommandText = $"INSERT INTO {_parentMapper.TableName} ({parentMapStr["Keys"]}) VALUES ({parentMapStr["Values"]})";
                        _parentMapper.MapCommandParameters(command.Parameters, entity);
                        success = command.ExecuteNonQuery() > 0;
                    }
                    using (MySqlCommand command = connection.CreateCommand())
                    {
                        command.Transaction = transaction;
                        command.CommandText = $"INSERT INTO {_childMapper.TableName} ({childMapStr["Keys"]}) VALUES ({childMapStr["Values"]})";
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
            catch (MySqlException ex)
            {
                throw new DataAccessException($"Unexpected error occured with code {ex.Number}", ex);
            }
            catch (Exception) { throw; }
            finally
            {
                if (connection.State == ConnectionState.Open) connection.Dispose();
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
            catch (MySqlException ex)
            {
                throw new DataAccessException($"Unexpected error occured with code {ex.Number}", ex);
            }
            catch (Exception) { throw; }
            finally
            {
                if (connection.State == ConnectionState.Open) connection.Dispose();
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
            catch (MySqlException ex)
            {
                throw new DataAccessException($"Unexpected error occured with code {ex.Number}", ex);
            }
            catch (Exception) { throw; }
            finally
            {
                if (connection.State == ConnectionState.Open) connection.Dispose();
            }
        }
    }
}