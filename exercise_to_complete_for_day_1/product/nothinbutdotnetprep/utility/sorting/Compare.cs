using System;
using System.Collections.Generic;
using nothinbutdotnetprep.collections;

namespace nothinbutdotnetprep.utility.sorting
{
    public class Compare<ItemToSort>
    {
        public static IComparer<ItemToSort> by_descending<PropertyType>(Func<ItemToSort, PropertyType> func) where PropertyType : IComparable<PropertyType>
        {
            return new DescendingPropertyComparer<ItemToSort, PropertyType>(func);
        }
    }

    public class DescendingPropertyComparer<ItemToSort, PropertyType> : IComparer<ItemToSort> where PropertyType : IComparable<PropertyType>
    {
        private readonly Func<ItemToSort, PropertyType> _func;

        public DescendingPropertyComparer(Func<ItemToSort, PropertyType> func)
        {
            _func = func;
        }

        public int Compare(ItemToSort x, ItemToSort y)
        {
            return -_func(x).CompareTo(_func(y));
        }
    }
}