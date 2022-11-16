using System.Collections;
using System.Collections.Generic;

namespace Training.DomainClasses
{
    public class ReadOnlySet<T>: IEnumerable<T>
    {
        private IEnumerable<T> _items;

        public ReadOnlySet(IEnumerable<T> pets)
        {
            _items = pets;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}