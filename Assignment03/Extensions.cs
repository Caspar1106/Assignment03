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

        public static IEnumerable<T> Filter<T>(this IEnumerable<T> items, Predicate<T> predicate)
        {
            foreach (var t in items)
            {
                if (predicate(t))
                {
                    yield return t;
                }
            }
        }

        public static bool isSecure(this Uri uri)
        {
            return uri.Scheme == Uri.UriSchemeHttps;
        }

        public static int wordCount(this string s) {
            var temp = s.Split(" ");
            return temp.Length;
        }
    }

}
