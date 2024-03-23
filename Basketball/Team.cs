using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Basketball
{
    public class Team:IEnumerable<Player>
    {

        //       	•	Name: string
        //•	OpenPositions: int
        //•	Group: char

        private string name;
        private int openPositions;
        private char group;
        private List<Player> players;
        private int count;

        public Team(string name, int openPositions, char group)
        {
            Name = name;
            OpenPositions = openPositions;
            Group = group;
            Players = new List<Player>();

   
        }

        public string Name { get { return this.name; } set { this.name = value; } }
        public int OpenPositions { get { return this.openPositions; } set { this.openPositions = value; } }
        public char Group { get { return this.group; } set { this.group = value; } }
        public int Count { get { return this.players.Count; } }

        public List<Player> Players { get { return this.players; } set { this.players = value; } }

        public IEnumerator<Player> GetEnumerator()
        {
            for (int i = 0; i < this.Players.Count; i++) 
            {
                yield return this.Players[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();


        // string AddPlayer(Player player) –
        // adds a player to the team's collection, if there are open positions. Before adding a player, check:

        //      If the name or position is null or empty, return "Invalid player's information.".

        //      If there are no more open positions, return "There are no more open positions.". 

        //      If the rating is under 80, return "Invalid player's rating.".
        //Otherwise, return: "Successfully added {playerName} to the team. Remaining open positions: {openPositions}."
        //and decrease the OpenPositions property of the team.

        public string AddPlayer(Player player) 
        {
            if (this.OpenPositions > 0)
            {
                if (player.Name == null || player.Name == " " || player.Position == null || player.Position == " ")
                {
                    return "Invalid player's information.";
                }
                else if (player.Rating < 80)
                {
                    return "Invalid player's rating.";
                }
                else
                {
                    this.players.Add(player);
                    this.OpenPositions -= 1;
                    return $"Successfully added {player.Name} to the team. Remaining open positions: {this.OpenPositions}.";
                    

                }

            }
            else 
            {
                return "There are no more open positions.";
            }
        }
        public bool RemovePlayer(string name) 
        {
            bool returnValue = false;

            if (Players.Any(x => x.Name == name))
            {
                Player player = Players.First(x => x.Name == name);
                
                    returnValue = true;
                    this.Players.Remove(player);
                    this.OpenPositions++;
                                
            }
            
            return returnValue;
            
        }

        public int RemovePlayerByPosition(string position)
        {
            int count = 0;
            if (Players.Any(x => x.Position == position))
            {
                foreach (var kvp in this.Players.Where(x => x.Position == position))
                {
                    count++;
                }

                Players.RemoveAll(x => x.Position == position);
                OpenPositions += count;
                return count;
            }
            return count;
        }

        //Player RetirePlayer(string name) method – 
        //   retire(set his Retired property to true, without removing him from the collection) 
        //   the player with the given name, if he exists.As a result, return the player, or null, if he don't exist.
        public Player RetirePlayer(string name) 
        {
            if (Players.Any(x => x.Name == name))
            {

                    Player player = Players.First(x => x.Name == name);
                    int num = 0;
                    num = Players.IndexOf(player);
                    Players.RemoveAt(num);
                    player.Retired = true;
                    Players.Insert(num, player);
                    return player;
                
            }
            return null;
        }

        //List<Player> AwardPlayers(int games) method – return a list with all players
        //   that have participated in games games or more.

        public List<Player> AwardPlayers(int games) 
        {
            List<Player> list = new List<Player>();
            foreach (var kvp in Players.Where(x => x.Games >= games)) 
            {
                list.Add(kvp);
            }
            return list;
        }
        public string Report() 
        {
            bool exist = Players.Any(x => x.Retired == false);
            if (exist)
            {
                string output = $"Active players competing for Team {this.Name} from Group {this.Group}:";
                foreach (var kvp in Players.Where(x=>x.Retired == false)) 
                {
                    output = output + $"{Environment.NewLine}{kvp.ToString()}";
                }
                return output;

            }
            return null;
        }



    }
}
