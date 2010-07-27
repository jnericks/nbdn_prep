using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.utility.sorting
{
    public class Compare<ItemToCompare>
    {
        public static ComparerBuilder<ItemToCompare> by<PropertyType>(
            Func<ItemToCompare, PropertyType> property_accessor)
            where PropertyType : IComparable<PropertyType>
        {
            return
                new ComparerBuilder<ItemToCompare>(
                    new ComparablePropertyComparer<ItemToCompare, PropertyType>(property_accessor));
        }

        public static ComparerBuilder<ItemToCompare> by<PropertyType>(
            Func<ItemToCompare, PropertyType> property_accessor, params PropertyType[] rank_order)
        {
            return new ComparerBuilder<ItemToCompare>(new FixedPropertyComparer<ItemToCompare, PropertyType>(property_accessor, rank_order));
        }

        public static ComparerBuilder<ItemToCompare> by_descending<PropertyType>(
            Func<ItemToCompare, PropertyType> property_accessor)
            where PropertyType : IComparable<PropertyType>
        {
            return new ComparerBuilder<ItemToCompare>(
                new ReverseComparer<ItemToCompare>(
                    new ComparablePropertyComparer<ItemToCompare, PropertyType>(property_accessor)));
        }
    }
}