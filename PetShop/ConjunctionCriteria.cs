namespace Training.DomainClasses;

public class ConjunctionCriteria<T> : ICriteria<T> {
	private readonly ICriteria<T> criteriumA;
	private readonly ICriteria<T> criteriumB;

	public ConjunctionCriteria(ICriteria<T> criteriumA, ICriteria<T> criteriumB) {
		this.criteriumA = criteriumA;
		this.criteriumB = criteriumB;
	}

	public bool IsSatisfiedBy(T item) {
		return criteriumA.IsSatisfiedBy(item)
		       && criteriumB.IsSatisfiedBy(item);
	}
}

static internal class CriteriaExtensionConjunction {
	public static ICriteria<T> And<T>(this ICriteria<T> left, ICriteria<T> right) {
		return new ConjunctionCriteria<T>(left, right);
	}
}
