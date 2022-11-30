namespace Training.DomainClasses
{
    public class Conjunction<TItem> : BinaryCriteria<TItem>
    {

        public Conjunction(ICriteria<TItem> leftCriteria, ICriteria<TItem> rightCriteria) :base(leftCriteria, rightCriteria)
        {
        }

        public override bool IsSatisfiedBy(TItem item)
        {
            return _leftCriteria.IsSatisfiedBy(item) && _rightCriteria.IsSatisfiedBy(item);
        }
    }
}