using System;
using Training.Specificaton;

static internal class BuilderExtensions
{
    public static ICriteria<TItem> IsEqualTo<TItem, TField>(this FilteringEntryPoint<TItem, TField> criteriaBuilder, TField value)
    {
        return new AnonymousCriteria<TItem>(item=> criteriaBuilder.selector(item).Equals(value));
    }

    public static ICriteria<TItem> GreaterThan<TItem, TField>(this FilteringEntryPoint<TItem, TField> criteriaBuilder, TField value) 
        where TField : IComparable<TField>

    {
        return new AnonymousCriteria<TItem>(item => criteriaBuilder.selector(item).CompareTo(value)>0);
    }
}