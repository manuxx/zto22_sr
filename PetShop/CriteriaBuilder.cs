using System;
using System.Collections.Generic;
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
        
        public readonly Func<TItem, TField> _selector;
        private LinkedList<Func<Predicate<TField>, Predicate<TField>>> _predicateChain = new LinkedList<Func<Predicate<TField>, Predicate<TField>>>();

        public CriteriaBuilder(Func<TItem, TField> selector)
        {
            _selector = selector;
        }

        public CriteriaBuilder<TItem, TField> Require(Predicate<TField> requirement)
        {
            _predicateChain.AddFirst(pred => (item => pred(item) && requirement(item)));
            return this;
        }

        public CriteriaBuilder<TItem, TField> Not()
        {
            _predicateChain.AddLast(pred => (item => !pred(item)));
            return this;
        }

        public ICriteria<TItem> Build()
        {
            Predicate<TField> composition = item => true;
            foreach (var func in _predicateChain)
                composition = func.Invoke(composition);
            _predicateChain.Clear();
            return new PredicateCriteria<TItem>(item => composition(_selector(item)));
        }

    }
}