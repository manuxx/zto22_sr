using System;

namespace Training.DomainClasses
{
    public class Pet : IEquatable<Pet>
    {
        public bool Equals(Pet other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return name == other.name;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Pet) obj);
        }

        public override int GetHashCode()
        {
            return (name != null ? name.GetHashCode() : 0);
        }

        public override string ToString()
        {
            return $"Pet: {this.name};";
        }

        public static bool operator ==(Pet left, Pet right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Pet left, Pet right)
        {
            return !Equals(left, right);
        }

        public Sex sex;
        public string name { get; set; }
        public int yearOfBirth { get; set; }
        public float price { get; set; }
        public Species species { get; set; }
    }

    public class SpeciesEqualityCriteria : ICriteria<Pet>
    {
        private Species _species;

        public SpeciesEqualityCriteria(Species species)
        {
            this._species = species;
        }
        
        public bool IsSatisfiedBy(Pet pet)
        {
            return pet.species == _species;
        }
    }

    public class YearOfBirthCriteria : ICriteria<Pet>
    {
        private int _minYear, _maxYear;

        public YearOfBirthCriteria(int minYear, int maxYear = Int32.MaxValue)
        {
            _minYear = minYear;
            _maxYear = maxYear;
        }

        public bool IsSatisfiedBy(Pet pet)
        {
            return pet.yearOfBirth >= _minYear && pet.yearOfBirth <= _maxYear;
        }
    }
}