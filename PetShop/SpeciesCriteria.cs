namespace Training.DomainClasses
{
    public class SpeciesCriteria : ICriteria<Pet>
    {
        private readonly Species _species;
        
        public SpeciesCriteria(Species species)
        {
            _species = species;
        }

        public bool IsSatisfiedBy(Pet item)
        {
            return item.species == _species;
        }
    }
}