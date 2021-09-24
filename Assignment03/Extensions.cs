using System;
using System.Collections.Generic;

namespace Assignment03
{
    public static class Extensions
    {
        public static IEnumerable<T> Flatten<T>(this IEnumerable<IEnumerable<T>> items)
        {
            foreach (var item in items)
            {
                foreach (var t in item)
                {
                    yield return t;
                }
            }
        }
    }

}
