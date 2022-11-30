namespace Training.DomainClasses
{
    public abstract class BinaryCriteria<TItem> : ICriteria<TItem>
    {
        protected ICriteria<TItem> _leftCriteria;
        protected ICriteria<TItem> _rightCriteria;

        public BinaryCriteria(ICriteria<TItem> leftCriteria, ICriteria<TItem> rightCriteria)
        {
            _leftCriteria = leftCriteria;
            _rightCriteria = rightCriteria;
        }

        public abstract bool IsSatisfiedBy(TItem item);
    }

    public class Alternative<TItem> : BinaryCriteria<TItem>
    {
        public Alternative(ICriteria<TItem> leftCriteria, ICriteria<TItem> rightCriteria) : base(leftCriteria, rightCriteria)
        {
        }

        public override bool IsSatisfiedBy(TItem item)
        {
            return _leftCriteria.IsSatisfiedBy(item) || _rightCriteria.IsSatisfiedBy(item);
        }
    }
}