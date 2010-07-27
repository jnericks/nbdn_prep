using System;
using System.Collections;
using System.Collections.Generic;

namespace nothinbutdotnetprep.utility.sorting
{
    public class ComparerBuilder<ItemToSort> : IComparer<ItemToSort>, IEnumerable<ItemToSort>
    {
        IComparer<ItemToSort> initial_comparer;
        IEnumerable<ItemToSort> items_to_sort;

        public ComparerBuilder(IComparer<ItemToSort> initial_comparer, IEnumerable<ItemToSort> items_to_sort)
        {
            this.initial_comparer = initial_comparer;
            this.items_to_sort = items_to_sort;
        }

        public ComparerBuilder<ItemToSort> then_by<PropertyType>(Func<ItemToSort, PropertyType> accessor,
                                                                 params PropertyType[] values)
        {
            return then_using(new FixedPropertyComparer<ItemToSort, PropertyType>(accessor, values));
        }

        public ComparerBuilder<ItemToSort> then_by_descending<PropertyType>(Func<ItemToSort, PropertyType> accessor) where PropertyType : IComparable<PropertyType>
        {
            return
                then_using(
                    new ReverseComparer<ItemToSort>(new ComparablePropertyComparer<ItemToSort, PropertyType>(accessor)));
        }

        public ComparerBuilder<ItemToSort> then_by<PropertyType>(Func<ItemToSort, PropertyType> accessor) where PropertyType : IComparable<PropertyType>
        {
            return then_using(new ComparablePropertyComparer<ItemToSort, PropertyType>(accessor));
        }

        ComparerBuilder<ItemToSort> then_using(IComparer<ItemToSort> next)
        {
            return new ComparerBuilder<ItemToSort>(new ChainedComparer<ItemToSort>(initial_comparer, next), items_to_sort);
        }

        public int Compare(ItemToSort x, ItemToSort y)
        {
            return initial_comparer.Compare(x, y);
        }

        public IEnumerator<ItemToSort> GetEnumerator()
        {
            var sorted = new List<ItemToSort>(items_to_sort);
            sorted.Sort(initial_comparer);
            return sorted.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}