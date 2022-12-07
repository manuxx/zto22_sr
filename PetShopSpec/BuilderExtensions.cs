using System;
using Training.Specificaton;

static internal class BuilderExtensions
{
    public static ICriteria<TItem> IsEqualTo<TItem, TField>(this CriteriaBuilder<TItem, TField> criteriaBuilder, TField value)
    {
        return new AnonymousCriteria<TItem>(pet=> criteriaBuilder._selector(pet).Equals(value));
    }

    public static ICriteria<TItem> GreaterThan<TItem, TField>(this CriteriaBuilder<TItem, TField> criteriaBuilder, TField value) 
        where TField : IComparable<TField>

    {
        return new AnonymousCriteria<TItem>(pet => criteriaBuilder._selector(pet).CompareTo(value)>0);
    }
}