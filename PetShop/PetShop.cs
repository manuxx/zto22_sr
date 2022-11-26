using System;
using System.Collections.Generic;

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
            return new ReadOnlySet<Pet>(_petsInTheStore);
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
            var ret = new List<Pet>(_petsInTheStore);
            ret.Sort((p1,p2)=>p1.name.CompareTo(p2.name));
            return ret;
        }

        public IEnumerable<Pet> AllMice() => 
            _petsInTheStore.SelectAllThatSatisfy(pet => pet.species == Species.Mouse);
        public IEnumerable<Pet> AllFemalePets() => 
            _petsInTheStore.SelectAllThatSatisfy(pet => pet.sex == Sex.Female);
        public IEnumerable<Pet> AllCatsOrDogs() => 
            _petsInTheStore.SelectAllThatSatisfy(pet => pet.species == Species.Cat || pet.species == Species.Dog);
        public IEnumerable<Pet> AllPetsButNotMice() => 
            _petsInTheStore.SelectAllThatSatisfy(pet => pet.species != Species.Mouse);
        public IEnumerable<Pet> AllPetsBornAfter2010() => 
            _petsInTheStore.SelectAllThatSatisfy(pet => pet.yearOfBirth > 2010);
        public IEnumerable<Pet> AllDogsBornAfter2010() => 
            _petsInTheStore.SelectAllThatSatisfy(pet => pet.species == Species.Dog && pet.yearOfBirth > 2010);
        public IEnumerable<Pet> AllMaleDogs() => 
            _petsInTheStore.SelectAllThatSatisfy(pet => pet.sex == Sex.Male && pet.species == Species.Dog);
        public IEnumerable<Pet> AllPetsBornAfter2011OrRabbits() => 
            _petsInTheStore.SelectAllThatSatisfy(pet => pet.yearOfBirth > 2011 || pet.species == Species.Rabbit);
    }
}