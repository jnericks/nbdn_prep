using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.utility.sorting
{
    public class PropertyComparer<ItemToCompare, PropertyType> : IComparer<ItemToCompare> 
        where PropertyType : IComparable<PropertyType>
    {
        Func<ItemToCompare, PropertyType> property_accessor;

        public PropertyComparer(Func<ItemToCompare, PropertyType> property_accessor)
        {
            this.property_accessor = property_accessor;
        }

        public int Compare(ItemToCompare x, ItemToCompare y)
        {
            return property_accessor(x).CompareTo(property_accessor(y));
        }
    }
}