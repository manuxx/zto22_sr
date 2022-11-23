using System;
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
        public static IEnumerable<T> SelectAllThatSatisfy<T>(this IEnumerable<T> items, Predicate<T> pred)
        {
            foreach (var item in items)
            {
                if (pred(item))
                    yield return item;
            }
        }
    }
}