using System;
using PetShop;

namespace Training.DomainClasses
{
    public class Where<TItem>
    {
        public static CriteriaBuilder<TItem, TField> Has<TField>(Func<TItem, TField> selector)
        {
            return new CriteriaBuilder<TItem, TField>(selector);
        }
    }

    public class CriteriaBuilder<TItem, TField>
    {
        private readonly Func<TItem, TField> _selector;

        public CriteriaBuilder(Func<TItem, TField> selector)
        {
            _selector = selector;
        }

        public ICriteria<TItem> EqualTo(TField value)
        {
            return new PredicateCriteria<TItem>(item => _selector(item).Equals(value));
        }

    }
}