using Training.DomainClasses;

static internal class CriteriaExtensions
{
    public static Alternative<TItem> Or<TItem>(this ICriteria<TItem> leftCriteria, ICriteria<TItem> rightCriteria)
    {
        return new Alternative<TItem>(leftCriteria,rightCriteria);
    }
}