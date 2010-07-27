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

    }
}