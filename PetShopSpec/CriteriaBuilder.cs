using System;

namespace Training.Specificaton;

internal class CriteriaBuilder<TBase, TField> {
	public readonly Func<TBase, TField> _selector;
	public readonly bool negate;

	public CriteriaBuilder(Func<TBase, TField> selector) {
		_selector = selector;
		negate = false;
	}

	public CriteriaBuilder(Func<TBase, TField> selector, bool negate) {
		_selector = selector;
		this.negate = negate;
	}

	public CriteriaBuilder<TBase, TField> Not() {
		return new CriteriaBuilder<TBase, TField>(_selector, !negate);
	}
}
