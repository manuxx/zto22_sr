using System;
using System.Collections.Generic;

namespace Training.DomainClasses.PetCriteria
{
    
    
    public class YearOfBirthEqual : ICriteria<Pet>
    {
        private int _minYear, _maxYear;

        public YearOfBirthEqual(int minYear, int maxYear = Int32.MaxValue)
        {
            _minYear = minYear;
            _maxYear = maxYear;
        }

        public bool IsSatisfiedBy(Pet pet)
        {
            return pet.yearOfBirth >= _minYear && pet.yearOfBirth <= _maxYear;
        }
    }

    public class BornAfter : YearOfBirthEqual
    {
        public BornAfter(int year) : base(year + 1)
        {
            
        }
    }

    public class SexEqual : ICriteria<Pet>
    {
        private Sex _sex;

        public SexEqual(Sex sex)
        {
            _sex = sex;
        }

        public bool IsSatisfiedBy(Pet pet)
        {
            return pet.sex == _sex;
        }
    }

    public class InSpeciesGroup : ICriteria<Pet>
    {
        private HashSet<Species> _speciesSet;

        public InSpeciesGroup(IEnumerable<Species> speciesSet)
        {
            _speciesSet = new HashSet<Species>(speciesSet);
        }

        public bool IsSatisfiedBy(Pet pet)
        {
            return _speciesSet.Contains(pet.species);
        }
    }

    public class SpeciesEqual : InSpeciesGroup
    {
        public SpeciesEqual(Species species) : base(new[] { species })
        {
            
        }
    }
}