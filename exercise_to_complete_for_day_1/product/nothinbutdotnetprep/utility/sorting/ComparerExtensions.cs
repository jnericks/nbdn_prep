using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.utility.sorting
{
    public static class ComparerExtensions
    {
        public static IComparer<T> followed_by<T>(this IComparer<T> first, IComparer<T> second)
        {
            return new ChainedComparer<T>(first, second);
        }
    }
}