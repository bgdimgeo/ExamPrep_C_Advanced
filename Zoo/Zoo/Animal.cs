namespace Zoo
{
    public class Animal
    {

 //       	•	Species – string
	//•	Diet – string
	//•	Weight – double
	//•	Length – double


        private string species;
        private string diet;
        private double weight;
        private double length;

        public Animal(string species, string diet, double weight, double length)
        {
            Species = species;
            Diet = diet;
            Weight = weight;
            Length = length;
        }


        public string Species { get { return this.species; } set { this.species = value; } }
        public string Diet { get { return this.diet; } set { this.diet = value; } }
        public double Weight { get { return this.weight; } set { this.weight = value; } }
        public double Length { get { return this.length; } set { this.length = value; } }

        public override string ToString()
        {
            return $"The {Species} is a {Diet} and weighs {Weight} kg.";
        }

    }
}
