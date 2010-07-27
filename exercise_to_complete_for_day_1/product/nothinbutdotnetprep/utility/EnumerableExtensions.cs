using System.Collections.Generic;
using nothinbutdotnetprep.collections;
using nothinbutdotnetprep.utility.filtering;

namespace nothinbutdotnetprep.utility
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> all_items_matching<T>(this IEnumerable<T> items,CriteriaFor<T> criteria)
        {
            foreach (T item in items) if (criteria(item)) yield return item;
        }

        public static IEnumerable<T> all_items_matching<T>(this IEnumerable<T> items,Criteria<T> criteria)
        {
            return items.all_items_matching(criteria.is_satisfied_by);
        }

        public static IEnumerable<T> all_items_not_matching<T>(this IEnumerable<T> items, CriteriaFor<T> criteria)
        {
            foreach (T item in items)
            {
                if (!criteria(item)) yield return item;
            }
        }
    }
}