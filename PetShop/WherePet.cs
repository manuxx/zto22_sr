using System;
using PetShop;

namespace Training.DomainClasses
{
    public class WherePet
    {
        public static PetCriteriaBuilder<T> Has<T>(Func<Pet, T> selector)
        {
            return new PetCriteriaBuilder<T>(selector);
        }
    }

    public class PetCriteriaBuilder<T>
    {
        private readonly Func<Pet, T> _selector;

        public PetCriteriaBuilder(Func<Pet, T> selector)
        {
            _selector = selector;
        }

        public ICriteria<Pet> EqualTo(T value)
        {
            return new PredicateCriteria<Pet>(pet => _selector(pet).Equals(value));
        }
    }
}