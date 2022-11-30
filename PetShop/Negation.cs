namespace Training.DomainClasses
{
    public class Negation<T> : ICriteria<T>
    {
        private ICriteria<T> _criteria;

        public Negation(ICriteria<T> criteria)
        {
            _criteria = criteria;
        }

        public bool IsSatisfiedBy(T item)
        {
            return !_criteria.IsSatisfiedBy(item);
        }
    }
}