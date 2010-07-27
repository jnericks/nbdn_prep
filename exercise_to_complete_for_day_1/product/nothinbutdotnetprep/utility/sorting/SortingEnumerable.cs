using System;
using System.Collections;
using System.Collections.Generic;

namespace nothinbutdotnetprep.utility.sorting
{
    public class SortingEnumerable<T> : IEnumerable<T>
    {
        ComparerBuilder<T> comparer;
        IEnumerable<T> items;

        public SortingEnumerable(ComparerBuilder<T> comparer,IEnumerable<T> items)
        {
            this.comparer = comparer;
            this.items = items;
        }


        public SortingEnumerable<T> then_by<PropertyType>(Func<T, PropertyType> accessor, params PropertyType[] values)
        {
            comparer = comparer.then_by(accessor, values);
            return this;
        }

        public SortingEnumerable<T> then_by_descending<PropertyType>(Func<T, PropertyType> accessor) where PropertyType : IComparable<PropertyType>
        {
            comparer = comparer.then_by_descending(accessor);
            return this;
        }

        public SortingEnumerable<T> then_by<PropertyType>(Func<T, PropertyType> accessor) where PropertyType : IComparable<PropertyType>
        {
            comparer = comparer.then_by(accessor);
            return this;
        }

        public int Compare(T x, T y)
        {
            return comparer.Compare(x, y);
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            var sorted = new List<T>(items);
            sorted.Sort(comparer);
            return sorted.GetEnumerator();
        }
    }
}