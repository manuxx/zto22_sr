using System;

namespace Training.Specificaton
{
    internal static class Where<TItem>
    {
        public static CriteriaBuilder<TItem,TField> HasAn<TField>(Func<TItem, TField> selector) 
        {
            return new CriteriaBuilder<TItem,TField>(selector);
        }

    }
}