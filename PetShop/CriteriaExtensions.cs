namespace Training.DomainClasses
{
    public static class CriteriaExtensions
    {
        public static ICriteria<TItem> Or<TItem>(this ICriteria<TItem> leftCriteria, ICriteria<TItem> rightCriteria)
        {
            return new Alternative<TItem>(leftCriteria, rightCriteria);
        }

        public static Conjunction<Pet> And(this ICriteria<Pet> leftCriteria, ICriteria<Pet> rightCriteria)
        {
            return new Conjunction<Pet>(leftCriteria, rightCriteria);
        }
    }
}