using System.Collections.Generic;
using nothinbutdotnetprep.collections;

namespace nothinbutdotnetprep.utility
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> all_items_matching<T>(this IEnumerable<T> items,CriteriaFor<T> criteria)
        {
            foreach (T item in items)
            {
                if (criteria(item)) yield return item;
            } 
        }
    }
}