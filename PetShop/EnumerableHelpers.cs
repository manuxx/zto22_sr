using System.Collections.Generic;

namespace Training.DomainClasses
{
    static internal class EnumerableHelpers
    {
        public static IEnumerable<TItem> GetEnumerable<TItem>(this IEnumerable<TItem> enumerable)
        {
            foreach (var item in enumerable)
            {
                yield return item;
            }
        }
    }
}