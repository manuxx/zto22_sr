using System;
using System.Collections.Generic;

namespace Training.DomainClasses
{
    internal static class EnumerableExtensions
    {
        public static IEnumerable<T> Launder<T>(this IEnumerable<T> enumerable)
        {
            foreach (var item in enumerable)
            {
                yield return item;
            }
        }
        
        public static IEnumerable<T> ThatSatisfy<T>(this IEnumerable<T> items, Predicate<T> pred)
        {
            return items.ThatSatisfy(new PredicateCriteria<T>(pred));
        }
        
        public static IEnumerable<T> ThatSatisfy<T>(this IEnumerable<T> items, ICriteria<T> criteria)
        {
            foreach (var item in items)
            {
                if (criteria.IsSatisfiedBy(item))
                    yield return item;
            }
        }
    }
}