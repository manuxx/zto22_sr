using System;

namespace Training.DomainClasses
{
    public interface ICriteria<T>
    {
        bool IsSatisfiedBy(T item);
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
}