namespace nothinbutdotnetprep.utility.filtering
{
    public class NegatedCriteriaFactory<ItemToFilter, PropertyType> : CriteriaFactory<ItemToFilter, PropertyType>
    {
        CriteriaFactory<ItemToFilter, PropertyType> factory;

        public NegatedCriteriaFactory(CriteriaFactory<ItemToFilter, PropertyType> factory)
        {
            this.factory = factory;
        }

        public Criteria<ItemToFilter> equal_to(PropertyType value_to_match)
        {
            return equal_to_any(value_to_match);
        }

        public Criteria<ItemToFilter> equal_to_any(params PropertyType[] values)
        {
            return new NotCriteria<ItemToFilter>(factory.equal_to_any(values));
        }
    }
}