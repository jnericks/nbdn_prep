using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.utility.sorting
{
    public class Compare<ItemToCompare>
    {
        public static IComparer<ItemToCompare> by<PropertyType>(
            Func<ItemToCompare, PropertyType> property_accessor)
            where PropertyType : IComparable<PropertyType>
        {
            return new CompareFactory<ItemToCompare, PropertyType>(property_accessor);
        }

        public static IComparer<ItemToCompare> by<PropertyType>(
            Func<ItemToCompare, PropertyType> property_accessor, params PropertyType[] rank_order)
        {
            return new RankedCompareFactory<ItemToCompare, PropertyType>(property_accessor, rank_order);
        }

        public static IComparer<ItemToCompare> by_descending<PropertyType>(
            Func<ItemToCompare, PropertyType> property_accessor)
            where PropertyType : IComparable<PropertyType>
        {
            return new ReverseComparer<ItemToCompare>(by(property_accessor));
        }
    }
}