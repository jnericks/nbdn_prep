using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.utility.sorting
{
    public class ComparerBuilder<ItemToSort> : IComparer<ItemToSort>
    {
        IComparer<ItemToSort> initial_comparer;

        public ComparerBuilder(IComparer<ItemToSort> initial_comparer)
        {
            this.initial_comparer = initial_comparer;
        }

        public ComparerBuilder<ItemToSort> then_by<PropertyType>(Func<ItemToSort, PropertyType> accessor,
                                                                 params PropertyType[] values)
        {
            return then_using(new FixedPropertyComparer<ItemToSort, PropertyType>(accessor, values));
        }

        public ComparerBuilder<ItemToSort> then_by_descending<PropertyType>(Func<ItemToSort, PropertyType> accessor)
            where PropertyType : IComparable<PropertyType>
        {
            return
                then_using(
                    new ReverseComparer<ItemToSort>(new ComparableComparer<ItemToSort, PropertyType>(accessor)));
        }

        public ComparerBuilder<ItemToSort> then_by<PropertyType>(Func<ItemToSort, PropertyType> accessor)
            where PropertyType : IComparable<PropertyType>
        {
            return then_using(new ComparableComparer<ItemToSort, PropertyType>(accessor));
        }

        ComparerBuilder<ItemToSort> then_using(IComparer<ItemToSort> next)
        {
            return new ComparerBuilder<ItemToSort>(new ChainedComparer<ItemToSort>(initial_comparer, next));
        }

        public int Compare(ItemToSort x, ItemToSort y)
        {
            return initial_comparer.Compare(x, y);
        }
    }
}