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

            return _petsInTheStore.ThatSatisfy(IsSpeciesOf(Species.Cat));

        }

        private static Predicate<Pet> IsSpeciesOf(Species species)
        {
            return pet => pet.species == species;
        }

        public IEnumerable<Pet> AllPetsSortedByName()
        {
            var ret = new List<Pet>(_petsInTheStore);
            ret.Sort((p1,p2)=>p1.name.CompareTo(p2.name));
            return ret;
        }

        public IEnumerable<Pet> AllMice()
        {
            return _petsInTheStore.ThatSatisfy(IsSpeciesOf(Species.Mouse));
        }

        public IEnumerable<Pet> AllFemalePets()
        {
            return _petsInTheStore.ThatSatisfy(IsFemale());
        }

        private static Predicate<Pet> IsFemale()
        {
            return pet => pet.sex == Sex.Female;
        }

        public IEnumerable<Pet> AllCatsOrDogs()
        {
            return _petsInTheStore.ThatSatisfy(pet => pet.species == Species.Cat || pet.species==Species.Dog);
        }

        public IEnumerable<Pet> AllPetsButNotMice()
        {
            return _petsInTheStore.ThatSatisfy(IsNotSpeciesOf(Species.Mouse));
        }

        private static Predicate<Pet> IsNotSpeciesOf(Species species)
        {
            return pet => pet.species != species;
        }

        public IEnumerable<Pet> AllPetsBornAfter2010()
        {
            return _petsInTheStore.ThatSatisfy(IsBornAfter(2010));
        }

        private static Predicate<Pet> IsBornAfter(int year)
        {
            return pet => pet.yearOfBirth > year;
        }

        public IEnumerable<Pet> AllDogsBornAfter2010()
        {
            return _petsInTheStore.ThatSatisfy(pet => pet.species == Species.Dog && pet.yearOfBirth>2010);
        }

        public IEnumerable<Pet> AllMaleDogs()
        {
            return _petsInTheStore.ThatSatisfy(pet => pet.sex == Sex.Male && pet.species==Species.Dog);
        }

        public IEnumerable<Pet> AllPetsBornAfter2011OrRabbits()
        {
            return _petsInTheStore.ThatSatisfy(pet => pet.yearOfBirth>2011 || pet.species==Species.Rabbit);
        }
    }
}