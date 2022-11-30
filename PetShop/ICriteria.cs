using System;

namespace Training.DomainClasses
{
    public interface ICriteria<T>
    {
        bool IsSatisfiedBy(T item);
    }

}