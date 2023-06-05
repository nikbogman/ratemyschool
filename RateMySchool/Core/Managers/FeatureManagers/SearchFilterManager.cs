namespace Core.Managers.FeatureManagers
{
    public class SearchFilterManager
    {
        public static IEnumerable<T> Filter<T>(IEnumerable<T> unfiltered, string propertyName, string searchValue)
        {
            List<T> filtered = new();
            foreach (var entity in unfiltered)
            {
                var property = entity.GetType().GetProperty(propertyName);
                if (property != null)
                {
                    var propertyValue = property.GetValue(entity);
                    if (propertyValue != null)
                    {
                        dynamic dynamicValue = Convert.ChangeType(searchValue, property.PropertyType);
                        dynamic dynamicPropertyValue = Convert.ChangeType(propertyValue, property.PropertyType);
                        if (dynamicPropertyValue.Equals(dynamicValue))
                        {
                            filtered.Add(entity);
                        }
                    }
                }
            }
            return filtered;
        }
    }
}
