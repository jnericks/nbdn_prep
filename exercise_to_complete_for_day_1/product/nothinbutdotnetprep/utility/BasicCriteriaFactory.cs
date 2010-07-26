using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.utility
{
    public class BasicCriteriaFactory<ItemToFilter, PropertyType> : CriteriaFactory<ItemToFilter, PropertyType>
    {
        private Func<ItemToFilter, PropertyType> property_accessor;

        public BasicCriteriaFactory(Func<ItemToFilter, PropertyType> property_expression)
        {
            this.property_accessor = property_expression;
        }

        public Criteria<ItemToFilter> equal_to(PropertyType value_to_match)
        {
            return new AnonymousCriteria<ItemToFilter>(x => property_accessor(x).Equals(value_to_match));
        }

        public Criteria<ItemToFilter> equal_to_any(params PropertyType[] values)
        {
            return new AnonymousCriteria<ItemToFilter>(item => new List<PropertyType>(values).Contains(property_accessor(item)));
        }

        public Criteria<ItemToFilter> not_equal_to(PropertyType value_to_match)
        {
            return new NotCriteria<ItemToFilter>(this.equal_to(value_to_match));
        }
    }
}