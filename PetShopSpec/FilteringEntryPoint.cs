using System;

namespace Training.Specificaton
{
    internal class FilteringEntryPoint<TItem,TField> 
    {
        public readonly Func<TItem, TField> selector;

        public FilteringEntryPoint(Func<TItem, TField> selector)
        {
            this.selector = selector;
        }
    }
}