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

            return SelectAllThatSatisfy(pet => pet.species == Species.Cat);

        }

        public IEnumerable<Pet> AllPetsSortedByName()
        {
            var ret = new List<Pet>(_petsInTheStore);
            ret.Sort((p1,p2)=>p1.name.CompareTo(p2.name));
            return ret;
        }

        public IEnumerable<Pet> AllMice()
        {
            return SelectAllThatSatisfy(pet => pet.species == Species.Mouse);
        }

        public IEnumerable<Pet> AllFemalePets()
        {
            return SelectAllThatSatisfy(pet => pet.sex == Sex.Female);
        }

        private IEnumerable<Pet> SelectAllThatSatisfy(Func<Pet, bool> condition)
        {
            foreach (var pet in _petsInTheStore)
            {
                if (condition(pet))
                {
                    yield return pet;
                }
            }
        }

        public IEnumerable<Pet> AllCatsOrDogs()
        {
            return SelectAllThatSatisfy(pet => pet.species == Species.Cat || pet.species==Species.Dog);
        }

        public IEnumerable<Pet> AllPetsButNotMice()
        {
            return SelectAllThatSatisfy(pet => pet.species != Species.Mouse);
        }

        public IEnumerable<Pet> AllPetsBornAfter2010()
        {
            return SelectAllThatSatisfy(pet => pet.yearOfBirth > 2010);
        }

        public IEnumerable<Pet> AllDogsBornAfter2010()
        {
            return SelectAllThatSatisfy(pet => pet.species == Species.Dog && pet.yearOfBirth>2010);
        }

        public IEnumerable<Pet> AllMaleDogs()
        {
            return SelectAllThatSatisfy(pet => pet.sex == Sex.Male && pet.species==Species.Dog);
        }

        public IEnumerable<Pet> AllPetsBornAfter2011OrRabbits()
        {
            return SelectAllThatSatisfy(pet => pet.yearOfBirth>2011 || pet.species==Species.Rabbit);
        }
    }
}