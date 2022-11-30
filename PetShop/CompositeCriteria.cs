using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Training.DomainClasses;

namespace PetShop
{
    public static class CompositeCriteriaExtensions
    {
        public static NegatedCriteria<T> Not<T>(this ICriteria<T> criteria)
        {
            return new NegatedCriteria<T>(criteria);
        }

        public static AndCriteria<T> And<T>(this ICriteria<T> leftCriteria, ICriteria<T> rightCriteria)
        {
            return new AndCriteria<T>(new []{leftCriteria, rightCriteria});
        }

        public static OrCriteria<T> Or<T>(this ICriteria<T> leftCriteria, ICriteria<T> rightCriteria)
        {
            return new OrCriteria<T>(new[] { leftCriteria, rightCriteria });
        }
    }
    
    public class PredicateCriteria<T> : ICriteria<T>
    {
        private readonly Predicate<T> _predicate;

        public PredicateCriteria(Predicate<T> predicate)
        {
            _predicate = predicate;
        }

        public bool IsSatisfiedBy(T item)
        {
            return _predicate(item);
        }
    }
    
    public class NegatedCriteria<T> : ICriteria<T>
    {
        private ICriteria<T> _innerCriteria;

        public NegatedCriteria(ICriteria<T> innerCriteria)
        {
            _innerCriteria = innerCriteria;
        }

        public bool IsSatisfiedBy(T item)
        {
            return !_innerCriteria.IsSatisfiedBy(item);
        }
    }


    public abstract class CompositeCriteria<T> : ICriteria<T>
    {
        protected readonly List<ICriteria<T>> _innerCriteria;

        public CompositeCriteria(IEnumerable<ICriteria<T>> criteria)
        {
            _innerCriteria = new List<ICriteria<T>>(criteria);
        }

        public abstract bool IsSatisfiedBy(T item);
    }

    public class AndCriteria<T> : CompositeCriteria<T>
    {
        public AndCriteria(IEnumerable<ICriteria<T>> criteria) : base(criteria)
        {
        }

        public override bool IsSatisfiedBy(T item)
        {
            foreach (var innerCriterion in _innerCriteria)
            {
                if (!innerCriterion.IsSatisfiedBy(item))
                    return false;
            }

            return true;
        }
    }

    public class OrCriteria<T> : CompositeCriteria<T>
    {
        public OrCriteria(IEnumerable<ICriteria<T>> criteria) : base(criteria)
        {
        }
        
        public override bool IsSatisfiedBy(T item)
        {
            foreach(var innerCriterion in _innerCriteria)
            {
                if (innerCriterion.IsSatisfiedBy(item))
                    return true;
            }

            return false;
        }
    }
}