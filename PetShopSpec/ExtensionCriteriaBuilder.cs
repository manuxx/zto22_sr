using System;

namespace Training.Specificaton;

internal static class ExtensionCriteriaBuilder {

	public static ICriteria<TBase> IsEqualTo<TBase, TField>(this CriteriaBuilder<TBase, TField> self, TField value) {
		return self.Apply(new AnonymousCriteria<TBase>(item =>
			self._selector(item).Equals(value)));
	}

	public static ICriteria<TBase> GreaterThan<TBase, TField>(this CriteriaBuilder<TBase, TField> self, IComparable<TField> value) {
		return new AnonymousCriteria<TBase>(item =>
			(value.CompareTo(self._selector(item)) < 0 )^ self.negate);
	}
}
