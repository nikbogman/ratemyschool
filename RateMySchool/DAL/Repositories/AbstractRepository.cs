﻿using MySql.Data.MySqlClient;
using System.Data;
using Core.Interfaces;

namespace DAL
{
    public abstract class AbstractRepository<EntityT> : IRepository<EntityT> where EntityT : IEntity
    {
        protected readonly string _connectionString;
        protected readonly EntityMapper<EntityT> _mapper = new();
        public AbstractRepository(string connectionString) { _connectionString = connectionString; }

        public IEnumerable<EntityT> SelectAll()
        {
            MySqlConnection connection = new(_connectionString);
            try
            {
                using MySqlCommand command = connection.CreateCommand();
                command.CommandText = $"SELECT * FROM {_mapper.TableName}";
                
                connection.Open();
                using MySqlDataAdapter adapter = new(command);
                DataSet dataSet = new();
                adapter.Fill(dataSet);
                connection.Close();

                List<EntityT> entities = new();
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    var entity = Activator.CreateInstance(typeof(EntityT), row);
                    if (entity == null) 
                    { 
                        continue;
                    }
                    entities.Add((EntityT)entity);
                }
                return entities;
            }
            catch (Exception ex)
            {
                connection.Dispose();
                throw DataAccessExceptionHandler.Handle(ex);
            }
        }
        public EntityT? SelectOne(Guid id)
        {
            MySqlConnection connection = new(_connectionString);
            try
            {
                using MySqlCommand command = connection.CreateCommand();
                command.CommandText = $"SELECT * FROM {_mapper.TableName} WHERE id = @id";
                command.Parameters.AddWithValue("@id", id);
                
                connection.Open();
                using MySqlDataAdapter adapter = new(command);
                DataSet dataSet = new();
                adapter.Fill(dataSet);
                connection.Close();

                if (dataSet.Tables[0].Rows.Count == 0)
                {
                    return default;
                }
                DataRow row = dataSet.Tables[0].Rows[0];
                var entity = Activator.CreateInstance(typeof(EntityT), row);
                if (entity == null) { return default; }
                return (EntityT)entity;
            }
            catch (Exception ex)
            {
                connection.Dispose();
                throw DataAccessExceptionHandler.Handle(ex);
            }
        }
        public bool Insert(EntityT entity)
        {
            MySqlConnection connection = new(_connectionString);
            try
            {
                Dictionary<string, string> mapStr = _mapper.GetCommandTextMapStrings();
                connection.Open();
                using MySqlCommand command = connection.CreateCommand();
                command.CommandText = $"INSERT INTO {_mapper.TableName} ({mapStr["Keys"]}) VALUES ({mapStr["Values"]})";
                _mapper.MapCommandParameters(command.Parameters, entity);

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
        public bool Update(EntityT entity)
        {
            MySqlConnection connection = new(_connectionString);
            try
            {
                connection.Open();
                using MySqlCommand command = connection.CreateCommand();
                command.CommandText = $"UPDATE {_mapper.TableName} AS t SET {_mapper.GetClausesString()} WHERE id = @id";
                _mapper.MapCommandParameters(command.Parameters, entity);
                
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
                command.CommandText = $"DELETE FROM {_mapper.TableName} WHERE id = @id";
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