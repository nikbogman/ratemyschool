namespace Core.Services
{
    public class CompareByRatingInDescendingOrder : IComparer<RatingStatistic>
    {
        public int Compare(RatingStatistic? x, RatingStatistic? y)
        {
            if (x == null && y == null) { return 0; }
            if (x == null) { return 1; }
            if (y == null) { return -1; }
            return -1 * x.AverageRating.CompareTo(y.AverageRating);
        }
    }

    public class CompareByRatingInAescendingOrder : IComparer<RatingStatistic>
    {
        public int Compare(RatingStatistic? x, RatingStatistic? y)
        {
            if (x == null && y == null) { return 0; }
            if (x == null) { return -1; }
            if (y == null) { return 1; }
            return x.AverageRating.CompareTo(y.AverageRating);
        }
    }
}
