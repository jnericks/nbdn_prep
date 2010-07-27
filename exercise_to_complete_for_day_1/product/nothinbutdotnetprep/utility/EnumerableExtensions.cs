using System;
using System.Collections.Generic;
using nothinbutdotnetprep.collections;
using nothinbutdotnetprep.utility.filtering;
using nothinbutdotnetprep.utility.sorting;

namespace nothinbutdotnetprep.utility
{
    public static class EnumerableExtensions
    {
        public static ComparerBuilder<ItemToCompare> order_by<ItemToCompare, PropertyType>(this IEnumerable<ItemToCompare> items, Func<ItemToCompare, PropertyType> property_accessor) 
            where PropertyType : IComparable<PropertyType>
        {
            return new ComparerBuilder<ItemToCompare>(
                new ComparablePropertyComparer<ItemToCompare, PropertyType>(property_accessor), items);
        }

        public static ComparerBuilder<ItemToCompare> order_by<ItemToCompare, PropertyType>(this IEnumerable<ItemToCompare> items, Func<ItemToCompare, PropertyType> property_accessor, params PropertyType[] rank_order)
        {
            return new ComparerBuilder<ItemToCompare>(
                new FixedPropertyComparer<ItemToCompare, PropertyType>(property_accessor, rank_order), items);
        }

        public static ComparerBuilder<ItemToCompare> order_by_descending<ItemToCompare, PropertyType>(this IEnumerable<ItemToCompare> items, Func<ItemToCompare, PropertyType> property_accessor) where PropertyType : IComparable<PropertyType>
        {
            return new ComparerBuilder<ItemToCompare>(
                new ReverseComparer<ItemToCompare>(
                    new ComparablePropertyComparer<ItemToCompare, PropertyType>(property_accessor)), items);
        }

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