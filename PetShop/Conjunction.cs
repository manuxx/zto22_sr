namespace Training.DomainClasses
{
    public class Conjunction<T> : ICriteria<Pet>
    {
        private readonly ICriteria<Pet> _leftCriteria;
        private readonly ICriteria<Pet> _rightCriteria;

        public Conjunction(ICriteria<Pet> leftCriteria, ICriteria<Pet> rightCriteria)
        {
            _leftCriteria = leftCriteria;
            _rightCriteria = rightCriteria;
        }

        public bool IsSatisfiedBy(Pet item)
        {
            return _leftCriteria.IsSatisfiedBy(item) && _rightCriteria.IsSatisfiedBy(item);
        }
    }
}