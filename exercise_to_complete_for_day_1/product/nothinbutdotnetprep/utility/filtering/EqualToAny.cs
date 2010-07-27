using System.Collections.Generic;

namespace nothinbutdotnetprep.utility.filtering
{
    public class EqualToAny<T> : Criteria<T>
    {
        IList<T> values;

        public EqualToAny(params  T[] values)
        {
            this.values = new List<T>(values);
        }

        public bool is_satisfied_by(T item)
        {
            return values.Contains(item);
        }
    }
}