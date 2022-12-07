using System;

namespace Training.Specificaton
{
    internal static class Where<TItem>
    {
        public static FilteringEntryPoint<TItem,TField> HasAn<TField>(Func<TItem, TField> selector) 
        {
            return new FilteringEntryPoint<TItem,TField>(selector);
        }

    }
}