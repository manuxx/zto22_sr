namespace Training.DomainClasses
{
    public class Conjunction<TItem> : BinaryCondition<TItem>
    {
        public Conjunction(ICriteria<TItem> firstCriteria, ICriteria<TItem> secondCriteria) : base(firstCriteria, secondCriteria)
        {
        }

        public override bool IsSatisfiedBy(TItem item)
        {
            return _firstCriteria.IsSatisfiedBy(item) && _secondCriteria.IsSatisfiedBy(item);
        }
    }
}