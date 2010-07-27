using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.utility.sorting
{
    public class Compare<ItemToSort>
    {
        public static IComparer<ItemToSort> by_ascending<PropertyType>(Func<ItemToSort, PropertyType> property_accessor)
            where PropertyType : IComparable<PropertyType>
        {
            return new ComparablePropertyComparer<ItemToSort, PropertyType>(property_accessor);
        }

        public static IComparer<ItemToSort> by_descending<PropertyType>(Func<ItemToSort, PropertyType> property_accessor)
            where PropertyType : IComparable<PropertyType>
        {
            return new ReverseComparer<ItemToSort>(new ComparablePropertyComparer<ItemToSort,PropertyType>(property_accessor)); 
        }
    }
}