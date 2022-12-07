using System;
using Training.DomainClasses;

namespace Training.Specificaton
{
    internal class FilteringEntryPoint<TItem,TField> 
    {
        public readonly Func<TItem, TField> selector;
        public bool _negation;

        public FilteringEntryPoint(Func<TItem, TField> selector) : this(selector, false)
        {
        }

        private FilteringEntryPoint(Func<TItem, TField> selector, bool negation) 
        {
            this.selector = selector;
            _negation = negation;
        }

        public FilteringEntryPoint<TItem,TField> Not()
        {

            return new FilteringEntryPoint<TItem, TField>(selector, !_negation);
        }
    }
}