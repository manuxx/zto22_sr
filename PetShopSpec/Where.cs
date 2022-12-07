using System;

namespace Training.Specificaton;

internal static class Where<TBase> {
	public static CriteriaBuilder<TBase, TField> HasAn<TField>(
		Func<TBase, TField> selector) {
		return new CriteriaBuilder<TBase, TField>(selector);
	}
}
