using System;
using System.Collections.Generic;
using PetShop;

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

        public static IEnumerable<T> SelectAllThatSatisfy<T>(this IEnumerable<T> items, Predicate<T> condition)
        {
            return items.SelectAllThatSatisfy(new PredicateCriteria<T>(condition));
        }

        public static IEnumerable<T> SelectAllThatSatisfy<T>(this IEnumerable<T> items, ICriteria<T> criteria)
        {
            foreach (var item in items)
            {
                if (criteria.IsSatisfiedBy(item))
                {
                    yield return item;
                }
            }
        }
    }
}