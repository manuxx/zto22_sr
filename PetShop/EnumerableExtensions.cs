using System;
using System.Collections.Generic;

static internal class EnumerableExtensions
{
    public static IEnumerable<TItem> OneAtATime<TItem>(this IEnumerable<TItem> items)
    {
        foreach (var item in items)
        {
            yield return item;
        }
    }

    public static IEnumerable<TItem> ThatSatisfy<TItem>(
        this IEnumerable<TItem> collection,
        Func<TItem, bool> condition)
    {
        foreach (var item in collection)
        {
            if (condition(item))
            {
                yield return item;
            }
        }
    }
}