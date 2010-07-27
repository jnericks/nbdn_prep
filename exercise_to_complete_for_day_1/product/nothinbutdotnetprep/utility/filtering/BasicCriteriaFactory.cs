using System;

namespace nothinbutdotnetprep.utility.filtering
{
    public class BasicCriteriaFactory<ItemToFilter, PropertyType> : CriteriaFactory<ItemToFilter, PropertyType>
    {
        Func<ItemToFilter, PropertyType> property_accessor;

        public BasicCriteriaFactory(Func<ItemToFilter, PropertyType> property_expression)
        {
            this.property_accessor = property_expression;
        }

        public Criteria<ItemToFilter> equal_to(PropertyType value_to_match)
        {
            return equal_to_any(value_to_match);
        }

        public Criteria<ItemToFilter> equal_to_any(params PropertyType[] values)
        {
            return new PropertyCriteria<ItemToFilter, PropertyType>(property_accessor,
                                                                    new EqualToAny<PropertyType>(values));
        }
    }
}