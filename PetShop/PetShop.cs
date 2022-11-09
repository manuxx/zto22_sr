using System;
using System.Collections.Generic;

namespace Training.DomainClasses
{
    public class PetShop
    {
        private Dictionary<String, Pet> _petsInTheStore;

        public PetShop(IList<Pet> petsInTheStore)
        {
            _petsInTheStore = new Dictionary<String, Pet>();
            foreach (Pet pet in petsInTheStore)
                Add(pet);
        }

        public IEnumerable<Pet> AllPets()
        {
            return _petsInTheStore.Values;
        }

        public void Add(Pet newPet)
        {
            String key = String.IsNullOrEmpty(newPet.name) ? "" : newPet.name;
            _petsInTheStore.TryAdd(key, newPet);
        }
    }
}