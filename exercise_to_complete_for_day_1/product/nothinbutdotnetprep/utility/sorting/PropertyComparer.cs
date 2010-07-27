using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.utility.sorting
{
    public class PropertyComparer<ItemToSort, PropertyType> : IComparer<ItemToSort>
    {
        Func<ItemToSort, PropertyType> accessor;
        IComparer<PropertyType> regular_comparer;

        public PropertyComparer(IComparer<PropertyType> regular_comparer, Func<ItemToSort, PropertyType> accessor)
        {
            this.regular_comparer = regular_comparer;
            this.accessor = accessor;
        }

        public int Compare(ItemToSort x, ItemToSort y)
        {
            return regular_comparer.Compare(accessor(x), accessor(y));
        }
    }
}