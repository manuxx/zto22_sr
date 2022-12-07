using System;
using Training.Specificaton;

static internal class BuilderExtensions
{
    public static ICriteria<TItem> IsEqualTo<TItem, TField>(this CriteriaBuilder<TItem, TField> criteriaBuilder, TField value)
    {
        return new AnonymousCriteria<TItem>(pet=> criteriaBuilder._selector(pet).Equals(value));
    }

    public static ICriteria<TItem> GreaterThan<TComparableField, TItem, TField>(this CriteriaBuilder<TItem, TField> criteriaBuilder, TComparableField value) 
        where TComparableField : IComparable<TField>

    {
        return new AnonymousCriteria<TItem>(pet => value.CompareTo(criteriaBuilder._selector(pet))<0);
    }
}