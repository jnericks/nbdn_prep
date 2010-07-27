using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.utility.sorting
{
    public class Compare<ItemToCompare>
    {
        public static IComparer<ItemToCompare> by<PropertyType>(
            Func<ItemToCompare, PropertyType> property_accessor)
            where PropertyType : IComparable<PropertyType>
        {
            return new CompareFactory<ItemToCompare, PropertyType>(property_accessor);
        }

        public static IComparer<ItemToCompare> by<PropertyType>(
            Func<ItemToCompare, PropertyType> property_accessor, params PropertyType[] rank_order)
        {
            return new RankedCompareFactory<ItemToCompare, PropertyType>(property_accessor, rank_order);
        }

        public static IComparer<ItemToCompare> by_descending<PropertyType>(
            Func<ItemToCompare, PropertyType> property_accessor)
            where PropertyType : IComparable<PropertyType>
        {
            return new ReverseComparer<ItemToCompare>(by(property_accessor));
        }
    }

    public class RankedCompareFactory<ItemToCompare, PropertyType> : IComparer<ItemToCompare>
    {
        Func<ItemToCompare, PropertyType> property_accessor;
        IDictionary<PropertyType, int> rankings;

        public RankedCompareFactory(Func<ItemToCompare, PropertyType> property_accessor, 
            IEnumerable<PropertyType> rank_order)
        {
            this.property_accessor = property_accessor;
            initialize_rankings(rank_order);
        }

        private void initialize_rankings(IEnumerable<PropertyType> rank_order) 
        {
            rankings = new Dictionary<PropertyType, int>();
            var rank = 0;
            foreach (var item in rank_order)
            {
                rankings.Add(item, rank++);
            }
        }

        public int Compare(ItemToCompare x, ItemToCompare y)
        {
            return rankings[property_accessor(x)].CompareTo(rankings[property_accessor(y)]);
        }
    }
}