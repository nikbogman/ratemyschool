using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;
using Core.Enums;
using Core.Interfaces;
using Core.ViewModels.SchoolViewModels;

namespace Core.Entities.SchoolEntities
{
    [Table("school")]
    public class BaseSchoolEntity : BaseEntity, ISchoolEntity
    {
        [Column("name")]
        public string Name { get; private set; }

        [Column("city")]
        public string City { get; private set; }

        [Column("number")]
        public int Number { get; private set; }

        [Column("type")]
        public SchoolType Type { get; protected set; }

        public SchoolStatistic Statistic { get; protected set; }

        public BaseSchoolEntity(DataRow row)
        {
            Id = Guid.Parse((string)row["id"]);
            Name = (string)row["name"];
            City = (string)row["city"];
            Number = (int)row["number"];
            Type = row.GetEnumValue<SchoolType>("type");
            Statistic = new()
            {
                Rank = new(),
            };
        }

        public BaseSchoolEntity(BaseSchoolViewModel viewModel)
        {
            Name = viewModel.Name;
            City = viewModel.City;
            Number = viewModel.Number;
        }

        public void SetStatistics(SchoolStatistic result)
        {
            this.Statistic = result;
        }
    }
}