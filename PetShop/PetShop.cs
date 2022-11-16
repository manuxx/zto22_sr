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

        public IEnumerable<Pet> AllCats() => SelectAllThatSatisfy(pet => pet.species == Species.Cat);

        public IEnumerable<Pet> AllPetsSortedByName()
        {
            var ret = new List<Pet>(_petsInTheStore);
            ret.Sort((p1,p2)=>p1.name.CompareTo(p2.name));
            return ret;
        }

        public IEnumerable<Pet> AllPetsBornAfter2011OrRabbits() =>
            SelectAllThatSatisfy(pet => pet.species == Species.Rabbit || pet.yearOfBirth > 2011);


        public IEnumerable<Pet> AllMice() => SelectAllThatSatisfy(pet => pet.species == Species.Mouse);


        public IEnumerable<Pet> AllFemalePets() => SelectAllThatSatisfy(pet => pet.sex == Sex.Female);


        public IEnumerable<Pet> AllCatsOrDogs() =>
            SelectAllThatSatisfy(pet => pet.species == Species.Cat || pet.species == Species.Dog);


        public IEnumerable<Pet> AllPetsButNotMice() => SelectAllThatSatisfy(x => x.species != Species.Mouse);


        public IEnumerable<Pet> AllPetsBornAfter2010() => SelectAllThatSatisfy(pet => pet.yearOfBirth > 2010);


        public IEnumerable<Pet> AllDogsBornAfter2010() =>
            SelectAllThatSatisfy(pet => pet.species == Species.Dog && pet.yearOfBirth > 2010);


        public IEnumerable<Pet> AllMaleDogs() =>
            SelectAllThatSatisfy(pet => pet.species == Species.Dog && pet.sex == Sex.Male);


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
    }
}