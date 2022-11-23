using System;
using System.Collections.Generic;
using Training.DomainClasses;

static internal class EnumerableExtensions
{
    public static IEnumerable<TItem> OneAtATime<TItem>(this IEnumerable<TItem> items)
    {
        foreach (var item in items)
        {
            yield return item;
        }
    }

    public static IEnumerable<TItem> ThatSatisfy<TItem>(this IList<TItem> items, Func<TItem, bool> condition)
    {
        foreach (var item in items)
        {
            if (condition(item))
            {
                yield return item;
            }
        }
    }
}