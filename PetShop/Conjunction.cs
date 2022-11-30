namespace Training.DomainClasses
{
    public class Conjunction<TItem> : ICriteria<TItem>
    {
        private readonly ICriteria<TItem> _leftCriteria;
        private readonly ICriteria<TItem> _rightCriteria;

        public Conjunction(ICriteria<TItem> leftCriteria, ICriteria<TItem> rightCriteria)
        {
            _leftCriteria = leftCriteria;
            _rightCriteria = rightCriteria;
        }

        public bool IsSatisfiedBy(TItem item)
        {
            return _leftCriteria.IsSatisfiedBy(item) && _rightCriteria.IsSatisfiedBy(item);
        }
    }
}