namespace Training.DomainClasses;

public class NegationCriteria<T> : ICriteria<T> {
	private readonly ICriteria<T> criteriaToNegate;

	public NegationCriteria(ICriteria<T> criteriaToNegate) {
		this.criteriaToNegate = criteriaToNegate;
	}

	public bool IsSatisfiedBy(T item) {
		return !criteriaToNegate.IsSatisfiedBy(item);
	}
}
