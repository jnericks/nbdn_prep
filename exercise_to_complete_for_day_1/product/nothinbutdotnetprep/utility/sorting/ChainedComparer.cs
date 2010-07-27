using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.utility.sorting
{
    public class ChainedComparer<ItemToCompare> : IComparer<ItemToCompare>
    {
        IComparer<ItemToCompare> first;
        IComparer<ItemToCompare> second;

        public ChainedComparer(IComparer<ItemToCompare> first, IComparer<ItemToCompare> second)
        {
            this.first = first;
            this.second = second;
       }

        public int Compare(ItemToCompare x, ItemToCompare y)
        {
            var result = first.Compare(x, y);
            if (result == 0) return second.Compare(x, y);
            return result;
        }

        public ChainedComparer<ItemToCompare> then_by<PropertyType>(Func<ItemToCompare, PropertyType> property_accessor2)
            where PropertyType : IComparable<PropertyType>
        {
            var to_chain = new ComparablePropertyComparer<ItemToCompare, PropertyType>(property_accessor2);
            return new ChainedComparer<ItemToCompare>(this, to_chain);
        }
    }
}