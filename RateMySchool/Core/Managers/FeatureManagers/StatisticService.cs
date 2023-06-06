using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Managers.FeatureManagers
{
    public class StatisticService : BaseStatisticsService
    {
        public StatisticService(IReviewRepository repository) : base(repository) { }

        protected override List<RatingStatistic> FilterStatistics(List<RatingStatistic> statistics)
        {
            return statistics
                .Where(stat => stat.Average > 0)
                .OrderByDescending(stat => stat.Average)
                .ToList();
        }
    }
}
