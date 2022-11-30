using System;

namespace Training.DomainClasses
{
    public static class CriteriaExtensions
    {
        public static ICriteria<TItem> Or<TItem>(this ICriteria<TItem> criteria1, ICriteria<TItem> criteria2)
        {
            return new Alternative<TItem>(criteria1, criteria2);
        }

        public static ICriteria<TItem> Not<TItem>(this ICriteria<TItem> criteria1)
        {
            return new Negation<TItem>(criteria1);
        }

        public static Conjunction<TItem> And<TItem>(this ICriteria<TItem> criteria1, ICriteria<TItem> criteria2)
        {
            return new Conjunction<TItem>(criteria1, criteria2);
        }
    }
}