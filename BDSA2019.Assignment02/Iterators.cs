using System;
using System.Collections.Generic;

namespace BDSA2019.Assignment02
{
    public static class Helpers
    {
        public static IEnumerable<T> Flatten<T>(IEnumerable<IEnumerable<T>> items)
        {
            foreach (var innerStream in items)
            {
                foreach (var item in innerStream)
                {
                    yield return item;
                }
            }
        }

        public static IEnumerable<T> Filter<T>(IEnumerable<T> items, Predicate<T> predicate)
        {
            foreach (var item in items)
            {
                if(predicate(item))
                {
                    yield return item;
                }
            }
        }
    }
}
