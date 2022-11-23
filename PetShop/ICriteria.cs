using System;

namespace Training.DomainClasses
{
    public interface ICriteria<TItem>
    {
        bool IsSatisfiedBy(TItem item);
    }

    public class PredicateCriteria<T> : ICriteria<T>
    {
        private Predicate<T> _predicate;

        public PredicateCriteria(Predicate<T> predicate)
        {
            _predicate = predicate;
        }

        public bool IsSatisfiedBy(T item)
        {
            return _predicate(item);
        }
    }

}