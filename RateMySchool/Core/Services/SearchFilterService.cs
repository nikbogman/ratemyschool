namespace Core.Services
{
    public static class SearchFilterService
    {
        public static IEnumerable<T> Filter<T>(IEnumerable<T> unfiltered, string propertyName, string searchValue) where T : class
        {
            var filtered = new List<T>();
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
                        if (dynamicPropertyValue is string && dynamicPropertyValue.Contains(dynamicValue))
                        {
                            filtered.Add(entity);
                        }
                        else
                        {
                            if (dynamicPropertyValue.Equals(dynamicValue))
                            {
                                filtered.Add(entity);
                            }
                        }
                    }
                }
            }
            return filtered;
        }
    }
}
