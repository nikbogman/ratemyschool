namespace Core.Services
{
    public class CompareByRatingInDescendingOrder : IComparer<Statistic>
    {
        public int Compare(Statistic? x, Statistic? y)
        {
            if (x == null && y == null) { return 0; }
            if (x == null) { return 1; }
            if (y == null) { return -1; }
            return -1 * x.AverageRating.CompareTo(y.AverageRating);
        }
    }

    public class CompareByRatingInAescendingOrder : IComparer<Statistic>
    {
        public int Compare(Statistic? x, Statistic? y)
        {
            if (x == null && y == null) { return 0; }
            if (x == null) { return -1; }
            if (y == null) { return 1; }
            return x.AverageRating.CompareTo(y.AverageRating);
        }
    }
}
