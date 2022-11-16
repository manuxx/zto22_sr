using System.Collections.Generic;
using Training.DomainClasses;

static internal class EnumerableHelpers
{
    public static IEnumerable<TItem> OneAtATime<TItem>(this IEnumerable<TItem> items)
    {
        foreach (var item in items)
        {
            yield return item;
        }
    }
}