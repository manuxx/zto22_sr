using System.Collections.Generic;

namespace Training.DomainClasses
{
    internal static class EnumerableUtils
    {
        public static IEnumerable<T> Launder<T>(this IEnumerable<T> enumerable)
        {
            foreach (var item in enumerable)
            {
                yield return item;
            }
        }
    }
}