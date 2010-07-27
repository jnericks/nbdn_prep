using System.Collections.Generic;

namespace nothinbutdotnetprep.utility.sorting
{
    public class FixedPropertyComparer<T> : IComparer<T>
    {
        IList<T> rankings;

        public FixedPropertyComparer(params T[] rankings)
        {
            this.rankings = new List<T>(rankings);
        }

        public int Compare(T x, T y)
        {
            return rankings.IndexOf(x).CompareTo(rankings.IndexOf(y));
        }
    }
}