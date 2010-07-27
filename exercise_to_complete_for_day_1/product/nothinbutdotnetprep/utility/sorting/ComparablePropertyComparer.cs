using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.utility.sorting
{
    public class ComparablePropertyComparer<ItemToSort,PropertyType> : IComparer<ItemToSort> where PropertyType : IComparable<PropertyType>
    {
        Func<ItemToSort, PropertyType> property_accessor;

        public ComparablePropertyComparer(Func<ItemToSort, PropertyType> property_accessor)
        {
            this.property_accessor = property_accessor;
        }

        public int Compare(ItemToSort x, ItemToSort y)
        {
            return property_accessor(x).CompareTo(property_accessor(y));
        }
    }
}