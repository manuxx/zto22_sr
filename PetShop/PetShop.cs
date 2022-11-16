using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace Training.DomainClasses
{
    public class PetShop
    {
        private IList<Pet> _petsInTheStore;

        public PetShop(IList<Pet> petsInTheStore)
        {
            this._petsInTheStore = petsInTheStore;
        }

        public IEnumerable<Pet> AllPets()
        {
            foreach (var pet in _petsInTheStore)
            {
                yield return pet;
            }
        }

        public void Add(Pet newPet)
        {
            if (_petsInTheStore.Contains(newPet))
                return;

            _petsInTheStore.Add(newPet);
        }

        public IEnumerable<Pet> AllCats()
        {
            foreach (var pet in _petsInTheStore)
            {
                if (pet.species == Species.Cat)
                {
                    yield return pet;
                }
            }
        }

        public IEnumerable<Pet> AllPetsSortedByName()
        {
            var sortedSet = _petsInTheStore.ToImmutableSortedSet(new PetNameComparer());

            foreach (var pet in sortedSet)
            {
                yield return pet;
            }
        }
    }

    internal class PetNameComparer : IComparer<Pet>
    {
        public int Compare(Pet x, Pet y)
        {
            if (x == null && y == null) return 0;
            if (x != null && y == null) return -1;
            if (x == null && y != null) return 1;
            
            return string.Compare(x.name, y.name, StringComparison.Ordinal);
        }
    }
}