using System;
using Training.DomainClasses;

namespace PetShop
{
    public static class ExtCriteriaBuilder
    {
        
        public static CriteriaBuilder<TItem, TField> EqualTo<TItem, TField>(this CriteriaBuilder<TItem, TField> builder, TField value)
        {
            return builder.Require(field => field.Equals(value));
        }

        public static CriteriaBuilder<TItem, TField> GreaterThan<TItem, TField>(
            this CriteriaBuilder<TItem, TField> builder, TField lowerBound)
            where TField: IComparable<TField>
        {
            return builder.Require(field => field.CompareTo(lowerBound) > 0);
        }
    }
}