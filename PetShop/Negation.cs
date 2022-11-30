namespace Training.DomainClasses
{
    public class Negation<TItem> : ICriteria<TItem>
    {
        private readonly ICriteria<TItem> _criteria;

        public Negation(ICriteria<TItem> criteria)
        {
            _criteria = criteria;
        }

        public bool IsSatisfiedBy(TItem item)
        {
            return !_criteria.IsSatisfiedBy(item);
        }
    }
}