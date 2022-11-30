namespace Training.DomainClasses
{
    public abstract class BinaryCriteria<T> : ICriteria<T>
    {
        protected ICriteria<T> _criteria1;
        protected ICriteria<T> _criteria2;
        public abstract bool IsSatisfiedBy(T item);
    }
}