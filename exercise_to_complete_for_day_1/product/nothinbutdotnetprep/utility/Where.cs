using System;

namespace nothinbutdotnetprep.utility
{
    public class Where<ItemToFilter>
    {
        public static WhereResult<ItemToFilter, PropertyType> has_a<PropertyType>(Func<ItemToFilter, PropertyType> property_accessor)
        {
            return new WhereResult<ItemToFilter, PropertyType>(property_accessor);
        }

    }


    public class WhereResult<ItemToFilter, PropertyType>
    {
        private Func<ItemToFilter, PropertyType> property_accessor;

        public WhereResult(Func<ItemToFilter, PropertyType> property_expression)
        {
            this.property_accessor = property_expression;
        }

        public Criteria<ItemToFilter> equal_to(PropertyType value_to_match)
        {
            return new AnonymousCriteria<ItemToFilter>(x => property_accessor(x).Equals(value_to_match));
        }
    }
    
}