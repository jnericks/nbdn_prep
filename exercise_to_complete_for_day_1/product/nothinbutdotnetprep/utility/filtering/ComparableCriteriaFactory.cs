using System;
using nothinbutdotnetprep.utility.ranges;

namespace nothinbutdotnetprep.utility.filtering
{
    public class ComparableCriteriaFactory<ItemToFilter, PropertyType> : CriteriaFactory<ItemToFilter, PropertyType>
        where PropertyType : IComparable<PropertyType>
    {
        Func<ItemToFilter, PropertyType> accessor;
        CriteriaFactory<ItemToFilter, PropertyType> original;

        public ComparableCriteriaFactory(Func<ItemToFilter, PropertyType> accessor,
                                         CriteriaFactory<ItemToFilter, PropertyType> original)
        {
            this.accessor = accessor;
            this.original = original;
        }

        public Criteria<ItemToFilter> greater_than(PropertyType value)
        {
            return new PropertyCriteria<ItemToFilter, PropertyType>(accessor,
                                                                    new FallsInRange<PropertyType>(
                                                                        new ExclusiveRangeWithNoUpperBound<PropertyType>
                                                                            (value)));
            ;
        }

        public Criteria<ItemToFilter> within_range(PropertyType range_start, PropertyType range_end)
        {
            return new PropertyCriteria<ItemToFilter, PropertyType>(accessor,
                                                                    new FallsInRange<PropertyType>(
                                                                        new InclusiveRange<PropertyType>(range_start,
                                                                                                         range_end)));
        }

        public Criteria<ItemToFilter> equal_to(PropertyType value_to_match)
        {
            return original.equal_to(value_to_match);
        }

        public Criteria<ItemToFilter> equal_to_any(params PropertyType[] values)
        {
            return original.equal_to_any(values);
        }

        public Criteria<ItemToFilter> not_equal_to(PropertyType value_to_match)
        {
            return original.not_equal_to(value_to_match);
        }
    }
}