using Core.Enums;
using System.Data;

namespace Core
{
    public struct RatingStatistic
    {
        public float Average { get; private set; }
        public Guid SchoolId { get; private set; }
        public SchoolType SchoolType { get; private set; }
        
        public RatingStatistic(DataRow row)
        {
            Average = Convert.ToSingle(row["average_rating"]);
            SchoolId =  Guid.Parse((string)row["school_id"]);
            SchoolType = row.GetEnumValue<SchoolType>("type");
        }
    }
}
