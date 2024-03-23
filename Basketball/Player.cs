using System;

namespace Basketball
{
    public class Player
    {
		//    •	Name: string
		//•	Position: string
		//•	Rating: double
		//•	Games: int
		//•	Retired: boolean – false by default

		private string name;
		private string position;
		private double rating ;
		private int games;
		private bool retired;

        public Player(string name, string position, double rating, int games)
        {
            Name = name;
            Position = position;
            Rating = rating;
            Games = games;
			Retired = false;

        }

        public string Name { get { return this.name; } set { this.name = value; } }
		public string Position { get { return this.position; } set { this.position = value; } }
		public double Rating { get { return this.rating; } set { this.rating = value; } }
		public int Games { get { return this.games; } set { this.games = value; } }
		public bool Retired { get { return this.retired; } set { this.retired = value; } }

        public override string ToString()
        {
            return $"-Player: {this.Name}" +
                $"{Environment.NewLine}--Position: {this.Position}" +
                $"{Environment.NewLine}--Rating: {this.Rating}" +
                $"{Environment.NewLine}--Games played: {this.Games}";
        }

    }
}
