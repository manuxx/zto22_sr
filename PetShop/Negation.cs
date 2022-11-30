namespace Training.DomainClasses
{
    public class Negation<TItem> : ICriteria<TItem>
    {
        private readonly ICriteria<TItem> _criteriaToNegate;

        public Negation(ICriteria<TItem> criteriaToNegate)
        {
            _criteriaToNegate = criteriaToNegate;
        }

        public bool IsSatisfiedBy(TItem item)
        {
            return !_criteriaToNegate.IsSatisfiedBy(item);
        }
    }
}