using Core.Structs;

namespace Core.Services
{
    public class CompareByRatingInDescendingOrder : IComparer<Rating>
    {
        public int Compare(Rating? x, Rating? y)
        {
            if (x == null && y == null) { return 0; }
            if (x == null) { return 1; }
            if (y == null) { return -1; }
            return -1 * x.value.CompareTo(y.value);
        }
    }

    public class CompareByRatingInAescendingOrder : IComparer<Rating>
    {
        public int Compare(Rating? x, Rating? y)
        {
            if (x == null && y == null) { return 0; }
            if (x == null) { return -1; }
            if (y == null) { return 1; }
            return x.value.CompareTo(y.value);
        }
    }
}
