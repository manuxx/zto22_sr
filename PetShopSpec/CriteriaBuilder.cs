using System;

namespace Training.Specificaton;

internal class CriteriaBuilder<TBase, TField> {
	public readonly Func<TBase, TField> _selector;

	public CriteriaBuilder(Func<TBase, TField> selector) {
		_selector = selector;
	}
}
