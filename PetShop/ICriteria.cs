public interface ICriteria<TItem>
{
    bool IsSatisfiedBy(TItem pet);
}