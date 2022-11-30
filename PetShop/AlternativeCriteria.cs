namespace Training.DomainClasses;

public class AlternativeCriteria<T> : ICriteria<T> {
	private readonly ICriteria<T> criteriumA;
	private readonly ICriteria<T> criteriumB;

	public AlternativeCriteria(ICriteria<T> criteriumA, ICriteria<T> criteriumB) {
		this.criteriumA = criteriumA;
		this.criteriumB = criteriumB;
	}

	public bool IsSatisfiedBy(T item) {
		return criteriumA.IsSatisfiedBy(item)
		       || criteriumB.IsSatisfiedBy(item);
	}
}

static internal class CriteriaExtensionAlternative {
	public static ICriteria<T> Or<T>(this ICriteria<T> left, ICriteria<T> right) {
		return new AlternativeCriteria<T>(left, right);
	}
}
