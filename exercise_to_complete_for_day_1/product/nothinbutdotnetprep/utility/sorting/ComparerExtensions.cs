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

        public static IComparer<ItemToCompare> then_by<ItemToCompare, PropertyType>(
            this IComparer<ItemToCompare> first, Func<ItemToCompare, 
            PropertyType> property_accessor)
            where PropertyType : IComparable<PropertyType>
        {
            return first.followed_by(new PropertyComparer<ItemToCompare, PropertyType>(property_accessor));
        }
    }
}