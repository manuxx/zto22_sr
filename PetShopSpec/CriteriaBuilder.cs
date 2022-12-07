using System;

namespace Training.Specificaton
{
    internal class CriteriaBuilder<TItem,TField> 
    {
        public readonly Func<TItem, TField> _selector;

        public CriteriaBuilder(Func<TItem, TField> selector)
        {
            _selector = selector;
        }
    }
}