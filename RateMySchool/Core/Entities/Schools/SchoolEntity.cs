using System.Data;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Enums.Schools;
using Core.Models.Schools;
using Core.Interfaces.Entities;
using Core.Structs;

namespace Core.Entities.Schools
{
    [Table("school")]
    public class SchoolEntity : Entity, ISchoolEntity
    {
        [Column("name")]
        public string Name { get; private set; }

        [Column("city")]
        public string City { get; private set; }

        [Column("number")]
        public int Number { get; private set; }

        [Column("category_type")]
        public SchoolCategoryType CategoryType { get; protected set; }

        public SchoolStatistics Statistic { get; protected set; }

        public SchoolEntity(DataRow row) : base(row)
        {
            Name = (string)row["name"];
            City = (string)row["city"];
            Number = (int)row["number"];
            CategoryType = row.GetEnumValue<SchoolCategoryType>("category_type");
            Statistic = new() { Rank = new() };
        }

        public SchoolEntity(SchoolModel model) : base(model)
        {
            Name = model.Name;
            City = model.City;
            Number = model.Number;
        }

        public void SetStatistics(SchoolStatistics result)
        {
            Statistic = result;
        }
    }
}