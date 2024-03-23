using System;
using System.Collections.Generic;
using System.Linq;

namespace Drones
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            
            Queue<int> steel = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).Where(x=> x>=0 && x<= 130).ToArray());
            Stack<int> carbon = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).Where(x => x >= 0 && x <= 130).ToArray());
            Dictionary<string,int> resourceNeeded= new Dictionary<string, int>();

            resourceNeeded.Add("Gladius", 70);
            resourceNeeded.Add("Shamshir", 80);
            resourceNeeded.Add("Katana", 90);
            resourceNeeded.Add("Sabre", 110);
            resourceNeeded.Add("Broadsword", 150);


            Dictionary<string, int> swordsList = new Dictionary<string, int>();
            Predicate<Queue<int>> steelGotElemets = x => x.Count > 0;
            Predicate<Stack<int>> carbonGotElements = x => x.Count > 0;

            while (steelGotElemets(steel) && carbonGotElements(carbon))
            {
                int currSteel = steel.Dequeue();
                int curCarbon = carbon.Pop();
                if (resourceNeeded.ContainsValue(curCarbon + currSteel))
                {
                    foreach (var kvp in resourceNeeded.Where(x => x.Value == curCarbon + currSteel))
                    {
                        string name = kvp.Key;
                        if (!swordsList.ContainsKey(name))
                        {
                            swordsList.Add(name, 1);
                        }
                        else 
                        {
                            swordsList[name] += 1;
                        }
                    }
                }
                else 
                {
                    curCarbon += 5;
                    carbon.Push(curCarbon);
                }
            }
            if (swordsList.Count > 0)
            {
                Console.WriteLine($"You have forged {swordsList.Sum(x => x.Value)} swords.");
                CheckSteelCarbon(steel, carbon);
                foreach (var kvp in swordsList.OrderBy(x => x.Key)) 
                {
                    Console.WriteLine($"{kvp.Key}: {kvp.Value}");
                }
            }
            else 
            {
                Console.WriteLine($"You did not have enough resources to forge a sword.");
                CheckSteelCarbon( steel, carbon);
            }
        }
        public static void CheckSteelCarbon( Queue<int> steel, Stack<int> carbon) 
        {
            if (steel.Count <= 0)
            {
                Console.WriteLine("Steel left: none");
            }
            else
            {
                Console.WriteLine($"Steel left: {String.Join(", ", steel)}");
            }
            if (carbon.Count <= 0)
            {
                Console.WriteLine("Carbon left: none");
            }
            else
            {
                Console.WriteLine($"Carbon left: {String.Join(", ",carbon)}");
            }
        }
    }
}