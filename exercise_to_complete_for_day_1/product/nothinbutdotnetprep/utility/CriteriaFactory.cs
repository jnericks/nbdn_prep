using System;

namespace nothinbutdotnetprep.utility
{
    public class CriteriaFactory<ItemToFilter, PropertyType>
    {
        private Func<ItemToFilter, PropertyType> property_accessor;

        public CriteriaFactory(Func<ItemToFilter, PropertyType> property_expression)
        {
            this.property_accessor = property_expression;
        }

        public Criteria<ItemToFilter> equal_to(PropertyType value_to_match)
        {
            return new AnonymousCriteria<ItemToFilter>(x => property_accessor(x).Equals(value_to_match));
        }
    }
}