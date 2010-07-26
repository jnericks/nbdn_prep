using System;

namespace nothinbutdotnetprep.utility
{
    public class ComparableCriteriaFactory<ItemToFilter,PropertyType>: CriteriaFactory<ItemToFilter,PropertyType> where PropertyType : IComparable<PropertyType>
    {
        Func<ItemToFilter,PropertyType> accessor;
        CriteriaFactory<ItemToFilter, PropertyType> original;

        public ComparableCriteriaFactory(Func<ItemToFilter, PropertyType> accessor, CriteriaFactory<ItemToFilter, PropertyType> original)
        {
            this.accessor = accessor;
            this.original = original;
        }

        public Criteria<ItemToFilter> greater_than(PropertyType value)
        {
            return new AnonymousCriteria<ItemToFilter>(item => accessor(item).CompareTo(value) > 0);
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