using System;

namespace nothinbutdotnetprep.utility.filtering
{
    public class NegatedCriteriaFactory<ItemToFilter, PropertyType> : CriteriaFactory<ItemToFilter, PropertyType>
    {
        private readonly CriteriaFactory<ItemToFilter, PropertyType> _factory;

        public NegatedCriteriaFactory(CriteriaFactory<ItemToFilter, PropertyType> factory)
        {
            _factory = factory;
        }

        public CriteriaFactory<ItemToFilter, PropertyType> not
        {
            get { return new NegatedCriteriaFactory<ItemToFilter, PropertyType>(_factory); }
        }

        public Criteria<ItemToFilter> equal_to(PropertyType value_to_match)
        {
            return new NotCriteria<ItemToFilter>(_factory.equal_to(value_to_match));
        }

        public Criteria<ItemToFilter> equal_to_any(params PropertyType[] values)
        {
            return new NotCriteria<ItemToFilter>(_factory.equal_to_any(values));
        }
    }
}