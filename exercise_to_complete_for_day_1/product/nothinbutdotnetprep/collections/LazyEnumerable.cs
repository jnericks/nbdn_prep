using System;
using System.Collections;
using System.Collections.Generic;

namespace nothinbutdotnetprep.collections
{
    public class LazyEnumerable<T> : IEnumerable<T>
    {
        IEnumerable<T> items;

        public LazyEnumerable(IEnumerable<T> items)
        {
            this.items = items;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            var results = new List<T>();
            Console.Out.WriteLine("I am about to iterate over all of the items");
            foreach (var item in items)
            {
                Console.Out.WriteLine("I am returning the item");
                results.Add(item);
            }
            return results.GetEnumerator();
        }
    }
}