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

    public static IEnumerable<TItem> ThatSatisfy<TItem>(this IEnumerable<TItem> items, Predicate<TItem> condition)
    {
        return items.ThatSatisfy(new AnonymousCriteria<TItem>(condition));
    }
    public static IEnumerable<TItem> ThatSatisfy<TItem>(this IEnumerable<TItem> items, ICriteria<TItem> criteria)
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

internal class AnonymousCriteria<T> : ICriteria<T>      
{
    public AnonymousCriteria(Predicate<T> condition)
    {
        throw new NotImplementedException();
    }

    public bool IsSatisfiedBy(T pet)
    {
        throw new NotImplementedException();
    }
}