namespace Training.DomainClasses
{
    public class Alternative<T> : BinaryCriteria<T>
    {
        private readonly ICriteria<T> _criteria1;
        private readonly ICriteria<T> _criteria2;

        public Alternative(ICriteria<T> criteria1, ICriteria<T> criteria2)
        {
            _criteria1 = criteria1;
            _criteria2 = criteria2;
        }

        public override bool IsSatisfiedBy(T item)
        {
            return _criteria1.IsSatisfiedBy(item) || _criteria2.IsSatisfiedBy(item);
        }
    }
}