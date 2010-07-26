using System;

namespace nothinbutdotnetprep.utility
{
    public class Where<ItemToFilter>
    {
        public static Func<ItemToFilter,ReturnType> has_a<ReturnType>(Func<ItemToFilter, ReturnType> property_accessor)
        {
            return property_accessor;
        }
    }
}