using System;
using Training.Specificaton;

static internal class FilteringEntryPointExtensions
{
    public static ICriteria<TItem> IsEqualTo<TItem, TField>(this FilteringEntryPoint<TItem, TField> entryPoint, TField value)
    {
        return new AnonymousCriteria<TItem>(item=> entryPoint.selector(item).Equals(value) != entryPoint._negation);
    }

    public static ICriteria<TItem> GreaterThan<TItem, TField>(this FilteringEntryPoint<TItem, TField> entryPoint, TField value) 
        where TField : IComparable<TField>

    {
        return new AnonymousCriteria<TItem>(item => entryPoint.selector(item).CompareTo(value)>0);
    }
}