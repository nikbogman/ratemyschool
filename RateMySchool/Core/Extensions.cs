using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Reflection;

namespace Core
{
    public static class Extensions
    {
        public static T GetEnumValue<T>(this DataRow row, string columnName) where T : Enum
        {
            if (row == null)
            {
                throw new ArgumentNullException(nameof(row));
            }
            if (!row.Table.Columns.Contains(columnName))
            {
                throw new ArgumentException($"Column '{columnName}' does not exist in the DataRow.");
            }
            Type propertyType = typeof(T);
            string enumValueString = propertyType.GetEnumNames().Single(name =>
            {
                FieldInfo? fieldInfo = propertyType.GetField(name);
                if (fieldInfo == null)
                {
                    return false;
                }
                DisplayAttribute? displayAttribute = fieldInfo.GetCustomAttribute<DisplayAttribute>();
                if (displayAttribute == null)
                {
                    return false;
                }
                return displayAttribute.Name == (string)row[columnName];
            });
            var enumValue = Enum.Parse(typeof(T), enumValueString);
            if (!Enum.IsDefined(typeof(T), enumValue))
            {
                throw new InvalidOperationException($"Invalid enum value '{enumValue}' for type '{typeof(T)}'.");
            }
            return (T)enumValue;
        }
    }
}
