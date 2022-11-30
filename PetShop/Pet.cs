using System;

namespace Training.DomainClasses {
    public class Pet : IEquatable<Pet> {
        public bool Equals(Pet other) {
            if(ReferenceEquals(null, other)) return false;
            if(ReferenceEquals(this, other)) return true;
            return name == other.name;
        }

        public override bool Equals(object obj) {
            if(ReferenceEquals(null, obj)) return false;
            if(ReferenceEquals(this, obj)) return true;
            if(obj.GetType() != this.GetType()) return false;
            return Equals((Pet)obj);
        }

        public override int GetHashCode() {
            return (name != null ? name.GetHashCode() : 0);
        }

        public override string ToString() {
            return $"Pet: {this.name};";
        }

        public static bool operator ==(Pet left, Pet right) {
            return Equals(left, right);
        }

        public static bool operator !=(Pet left, Pet right) {
            return !Equals(left, right);
        }

        public Sex sex;
        public string name { get; set; }
        public int yearOfBirth { get; set; }
        public float price { get; set; }
        public Species species { get; set; }

        public static ICriteria<Pet> IsSpeciesOf(Species species) {
            return new SpeciesCriteria(species);
        }

        public static ICriteria<Pet> IsSexOf(Sex sex) {
            return new SexCriteria(sex);
        }

        public static ICriteria<Pet> IsFemale() {
            return new SexCriteria(Sex.Female);
        }

        public static Predicate<Pet> IsNotSpeciesOf(Species species) {
            return pet => pet.species != species;
        }

        public static ICriteria<Pet> IsBornAfter(int year) {
            return new BornAfterCriteria(year);
        }

        public class BornAfterCriteria : ICriteria<Pet> {
            private readonly int year;

            public BornAfterCriteria(int year) {
                this.year = year;
            }

            public bool IsSatisfiedBy(Pet pet) {
                return pet.yearOfBirth > year;
            }
        }

        public class SexCriteria : ICriteria<Pet> {
            private readonly Sex sex;

            public SexCriteria(Sex sex) {
                this.sex = sex;
            }


            public bool IsSatisfiedBy(Pet pet) {
                return pet.sex == sex;
            }
        }

        public class SpeciesCriteria : ICriteria<Pet> {
            private readonly Species species;

            public SpeciesCriteria(Species species) {
                this.species = species;
            }

            public bool IsSatisfiedBy(Pet pet) {
                return pet.species == species;
            }
        }

        public static ICriteria<Pet> IsMale() {
            return new SexCriteria(Sex.Male);
        }
    }
}