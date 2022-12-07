using System;
using Training.DomainClasses;

namespace Training.Specificaton
{
    internal class FilteringEntryPoint<TItem,TField> 
    {
        public readonly Func<TItem, TField> Selector;
        public bool Negation;

        public FilteringEntryPoint(Func<TItem, TField> selector) : this(selector, false)
        {
        }

        private FilteringEntryPoint(Func<TItem, TField> selector, bool negation)
        {
            Selector = selector;
            Negation = negation;
        }

        public FilteringEntryPoint<TItem, TField> Not()
        {
            return new FilteringEntryPoint<TItem, TField>(Selector, !Negation);
        }
        
        public ICriteria<TItem> ApplyNegation(AnonymousCriteria<TItem> resultCriteria)
        {
            if (Negation)
                return new Negation<TItem>(resultCriteria);
            else 
                return resultCriteria;
        }
    }
}