using System;
using System.Collections.Generic;

static internal class EnumerableHelpers {
    public static IEnumerable<TItem> OneAtATime<TItem>(
        this IEnumerable<TItem> items) {
        foreach(var item in items) {
            yield return item;
        }
    }

    public static IEnumerable<T> ThatSatisfy<T>(this IEnumerable<T> items,
        Func<T, bool> predicate) {
        return items.ThatSatisfy(new PredicateCriteria<T>(predicate));
    }

    public static IEnumerable<T> ThatSatisfy<T>(this IEnumerable<T> items,
        ICriteria<T> criteria) {
        foreach(var item in items) {
            if(criteria.IsSatisfiedBy(item)) {
                yield return item;
            }
        }
    }
}

internal class PredicateCriteria<T> : ICriteria<T> {
    private readonly Func<T, bool> predicate;

    public PredicateCriteria(Func<T, bool> predicate) {
        this.predicate = predicate;
    }

    public bool IsSatisfiedBy(T item) {
        return predicate(item);
    }
}

public interface ICriteria<T> {
    bool IsSatisfiedBy(T item);
}