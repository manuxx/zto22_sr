using System;
using Training.DomainClasses;

namespace Training.Specificaton
{
    internal class FilteringEntryPoint<TItem,TField> 
    {
        public readonly Func<TItem, TField> selector;
        public bool _negation;

        public FilteringEntryPoint(Func<TItem, TField> selector)
        {
            this.selector = selector;
        }

        public FilteringEntryPoint<TItem,TField> Not()
        {
            _negation  = true;
            return this;
        }
    }
}