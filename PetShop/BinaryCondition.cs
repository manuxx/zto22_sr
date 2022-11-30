namespace Training.DomainClasses
{
    public abstract class BinaryCondition<TItem> : ICriteria<TItem>
    {
        protected ICriteria<TItem> _firstCriteria;
        protected ICriteria<TItem> _secondCriteria;

        public BinaryCondition(ICriteria<TItem> firstCriteria, ICriteria<TItem> secondCriteria)
        {
            _firstCriteria = firstCriteria;
            _secondCriteria = secondCriteria;
        }

        public abstract bool IsSatisfiedBy(TItem item);
    }
}