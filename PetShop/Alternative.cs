namespace Training.DomainClasses
{
    public class Alternative<TItem> : BinaryCondition<TItem>
    {
        public Alternative(ICriteria<TItem> firstCriteria, ICriteria<TItem> secondCriteria) : base(firstCriteria, secondCriteria)
        {
        }

        public override bool IsSatisfiedBy(TItem item)
        {
            return _firstCriteria.IsSatisfiedBy(item) || _secondCriteria.IsSatisfiedBy(item);
        }
    }
}