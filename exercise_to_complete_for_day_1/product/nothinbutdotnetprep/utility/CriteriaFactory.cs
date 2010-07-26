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

        public Criteria<ItemToFilter> equal_to_any(PropertyType value_to_match1, PropertyType value_to_match2)
        {
            return
                new OrCriteria<ItemToFilter>(equal_to(value_to_match1), equal_to(value_to_match2));
        }

        public Criteria<ItemToFilter> not_equal_to(PropertyType value_to_match)
        {

            return new NotCriteria<ItemToFilter>(this.equal_to(value_to_match));
        }
    }
}