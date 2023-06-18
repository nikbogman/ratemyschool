using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using MySql.Data.MySqlClient;
using System.Data;
using System.ComponentModel.DataAnnotations;
using Org.BouncyCastle.Asn1.Crmf;

namespace DAL
{
    public class EntityMapper<T>
    {
        private readonly IEnumerable<PropertyInfo> _columns;
        private readonly string _tableName;
        public string TableName { get => _tableName; }

        public string GetClausesString(string prefix = "t")
        {
            return string.Join(", ",
                _columns
                    .Select(p => p.GetCustomAttribute<ColumnAttribute>())
                    .Where(p => p.Name != "id")
                    .Select(p => $"{prefix}.{p.Name}=@{p.Name}")
            );
        }

        public void MapCommandParameters(MySqlParameterCollection commandParameters, T entity)
        {
            foreach (var property in _columns)
            {
                ColumnAttribute? column = property.GetCustomAttribute<ColumnAttribute>();
                if (column == null) continue;
                object? propertyValue = property.GetValue(entity);
                if (commandParameters.Contains("@" + column.Name)) continue;
                if (propertyValue != null && propertyValue != DBNull.Value)
                {
                    if (property.PropertyType.IsEnum)
                    {
                        propertyValue = (int)propertyValue;
                    }
                    else if (Guid.TryParse(propertyValue.ToString(), out _))
                    {
                        propertyValue = propertyValue.ToString();
                    }
                }
                commandParameters.AddWithValue("@" + column.Name, propertyValue);
            }
            return;
        }

        public Dictionary<string, string> GetCommandTextMapStrings()
        {
            List<string> columnNames = new();
            foreach (var property in _columns)
            {
                ColumnAttribute? column = property.GetCustomAttribute<ColumnAttribute>();
                if (column == null || column.Name == null) continue;
                columnNames.Add(column.Name);
            }
            return new Dictionary<string, string>()
            {
                { "Keys", string.Join(", ", columnNames) },
                { "Values", string.Join(", ", columnNames.Select(c => "@" + c)) }
            };
        }

        public EntityMapper()
        {
            Type type = typeof(T);
            TableAttribute? table = type.GetCustomAttribute<TableAttribute>();
            if (table == null)
            {
                throw new InvalidOperationException("The TableName attribute is missing.");
            }
            _tableName = table.Name;

            var columns = type
                .GetProperties()
                .Where(p => p.GetCustomAttribute<ColumnAttribute>() != null);

            Type? baseType = type.BaseType;
            if (baseType != null && !baseType.Equals(typeof(Object)))
            {
                var baseColumns = baseType.GetProperties()
                    .Where(p => p.GetCustomAttribute<ColumnAttribute>() != null);

                var idColumn = baseColumns.Single(prop => prop.Name == "Id");
                _columns = columns
                     .Where(property => !baseColumns.Any(excludedProp => property.Name == excludedProp.Name))
                     .Concat(new PropertyInfo[] { idColumn });
            }
            else
            {
                _columns = type
                    .GetProperties()
                    .Where(p => p.GetCustomAttribute<ColumnAttribute>() != null);
            }
            if (!_columns.Any())
            {
                throw new InvalidOperationException("The class has not properties with column attributes");
            }
        }
    }
}
