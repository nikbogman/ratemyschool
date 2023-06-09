using Core.Enums;
using System.Data;

namespace Core
{
    public class Statistic
    {
        public float AverageRating { get; set; }
        public Guid SchoolId { get; set; }
        public SchoolType SchoolType { get; set; }


        public Statistic(DataRow row)
        {
            AverageRating = Convert.ToSingle(row["average_rating"]);
            SchoolId =  Guid.Parse((string)row["school_id"]);
            SchoolType = row.GetEnumValue<SchoolType>("type");
        }

        public Statistic(){}
    }
}
