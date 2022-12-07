using System;
using Newtonsoft.Json.Serialization;
using Training.DomainClasses;

namespace Training.Specificaton
{
    static internal class CriteriaBuilderExtensions
    {
        public static ICriteria<TItem> IsEqualTo<TItem, TField>(this FilteringEntryPoint<TItem, TField> filteringEntryPoint, TField value)
        {
            var resultCriteria = new AnonymousCriteria<TItem>(item=> filteringEntryPoint.Selector(item).Equals(value));
            return filteringEntryPoint.ApplyNegation(resultCriteria);
        }

        public static ICriteria<TItem> GreaterThan<TItem, TField>(this FilteringEntryPoint<TItem, TField> filteringEntryPoint, TField value) 
            where TField : IComparable<TField>

        {
            return new AnonymousCriteria<TItem>(item => filteringEntryPoint.Selector(item).CompareTo(value)>0 != filteringEntryPoint.Negation);
        }
    }
}