

using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Zoo
{
    public class Zoo: IEnumerable<Animal>
    {

        //        	•	Name: string
        //Capacity: int

        private string name;
        private int capacity;

        private List<Animal> animals;
        public Zoo(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Animals = new List<Animal>();

        }

        public string Name { get { return this.name; } set { this.name = value; } }
        public int Capacity { get { return this.capacity; } set { this.capacity = value; } }
        public List<Animal> Animals { get { return this.animals; } private set { this.animals = value; } }

        public IEnumerator<Animal> GetEnumerator()
        {
            for (int i = 0; i < Animals.Count; i++) 
            {
                yield return Animals[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public string AddAnimal(Animal animal) 
        {
            if (animal.Species == null || animal.Species == " ")
            {
                return "Invalid animal species.";
            }
            else if (animal.Diet != "herbivore" && animal.Diet != "carnivore")
            {
                return "Invalid animal diet.";
            }
            else if (Animals.Count == Capacity)
            {
                return "The zoo is full.";
            }
            else 
            {
                Animals.Add(animal);
                return $"Successfully added {animal.Species} to the zoo.";
            }
        }
        public int RemoveAnimals(string species) 
        {
            int count = 0;
            foreach (var kvp in Animals.Where(x => x.Species == species))
            {
                count++;
            }

            Animals.RemoveAll(x => x.Species == species);

            return count;
        }

       public List<Animal> GetAnimalsByDiet(string diet) 
        {
            List<Animal> filteredAnimals = new List<Animal>();
            foreach (var kvp in Animals.Where(x => x.Diet == diet))
            {
                filteredAnimals.Add(kvp);
            }
            return filteredAnimals;
        }

        public Animal GetAnimalByWeight(double weight) 
        {
            Animal animal = Animals.First(x => x.Weight == weight);
            return animal;
        }
        public string GetAnimalCountByLength(double minimumLength, double maximumLength) 
        {
            int count = 0;
            foreach (var kvp in Animals.Where(x => x.Length >= minimumLength && x.Length <= maximumLength)) 
            {
                count++;
            }
            return $"There are {count} animals with a length between {minimumLength} and {maximumLength} meters.";
        }

    }
}
