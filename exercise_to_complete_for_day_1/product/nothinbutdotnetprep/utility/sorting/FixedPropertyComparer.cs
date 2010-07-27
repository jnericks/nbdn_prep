using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.utility.sorting
{
    public class FixedPropertyComparer<ItemToCompare, PropertyType> : IComparer<ItemToCompare>
    {
        Func<ItemToCompare, PropertyType> property_accessor;
        IList<PropertyType> rankings;

        public FixedPropertyComparer(Func<ItemToCompare, PropertyType> property_accessor, 
                                    IEnumerable<PropertyType> rank_order)
        {
            this.property_accessor = property_accessor;
            rankings = new List<PropertyType>(rank_order);
        }

        public IComparer<ItemToCompare> then_by<PropertyType2>(Func<ItemToCompare, PropertyType2> property_accessor2)
            where PropertyType2 : IComparable<PropertyType2>
        {
            var to_chain = new ComparablePropertyComparer<ItemToCompare, PropertyType2>(property_accessor2);
            return new ChainedComparer<ItemToCompare>(this, to_chain);
        }

        public int Compare(ItemToCompare x, ItemToCompare y)
        {
            return get_ranking_of(x).CompareTo(get_ranking_of(y));
        }

        int get_ranking_of(ItemToCompare item_to_compare)
        {
            return rankings.IndexOf(property_accessor(item_to_compare));
        }
    }
}