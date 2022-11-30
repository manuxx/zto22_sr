namespace Training.DomainClasses
{
    public class Conjunction<T> : BinaryCriteria<T>
    {
        public Conjunction(ICriteria<T> criteria1, ICriteria<T> criteria2)
        {
            _criteria1 = criteria1;
            _criteria2 = criteria2;
        }

        public override bool IsSatisfiedBy(T item)
        {
            return _criteria1.IsSatisfiedBy(item) && _criteria2.IsSatisfiedBy(item);
        }
    }
}