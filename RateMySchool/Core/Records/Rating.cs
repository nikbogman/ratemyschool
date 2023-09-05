using Core.Enums.Schools;

namespace Core.Structs
{
    public record RatingInfo
    {
        public Guid schoolId;
        public SchoolCategoryType schoolCategoryType;
    }

    public record Rating
    {
        public float value;
        public RatingInfo info;
    }
}
