using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;
using System.IO;


//<ImplicitUsings>enable</ImplicitUsings>
namespace BaristaContest
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> coffeeDictionary = new Dictionary<string, int>();

            coffeeDictionary["Cortado"] = 50;
            coffeeDictionary["Espresso"] = 75;
            coffeeDictionary["Capuccino"] = 100;
            coffeeDictionary["Americano"] = 150;
            coffeeDictionary["Latte"] = 200;


            Dictionary<string, int> cofeeCount = new Dictionary<string, int>();


            int[] coffeeArgs = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Queue<int> coffeeNums = new Queue<int>();
            for (int i = 0; i < coffeeArgs.Length; i++)
            {
                coffeeNums.Enqueue(coffeeArgs[i]);
            }
            int[] milkArgs = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Stack<int> milkNums = new Stack<int>();

            for (int i = 0; i < milkArgs.Length; i++)
            {
                milkNums.Push(milkArgs[i]);
            }

            while (coffeeNums.Count > 0 && milkNums.Count > 0)
            {
                int sum = coffeeNums.Peek() + milkNums.Peek();
                if (coffeeDictionary.ContainsValue(sum))
                {

                    foreach (var (modelCof, num) in coffeeDictionary.Where(x => x.Value == sum))
                    {

                        if (!cofeeCount.ContainsKey(modelCof))
                        {
                            cofeeCount[modelCof] = 0;
                        }
                        cofeeCount[modelCof] += 1;
                    }
                    coffeeNums.Dequeue();
                    milkNums.Pop();
                }
                else 
                {
                    coffeeNums.Dequeue();
                    int milk = milkNums.Peek() - 5;
                    milkNums.Pop();
                    milkNums.Push(milk);


                }
            }
            if (coffeeNums.Count == 0 && milkNums.Count == 0)
            {
                Console.WriteLine("Nina is going to win! She used all the coffee and milk!");
            }
            else 
            {
                Console.WriteLine("Nina needs to exercise more! She didn't use all the coffee and milk!");
            }

            if (coffeeNums.Count == 0)
            {
                Console.WriteLine("Coffee left: none");
            }
            else 
            {
                Console.Write("Coffee left: ");
                Console.Write(String.Join(", ", coffeeNums));
                Console.WriteLine();
            }
            if (milkNums.Count == 0) 
            {
                Console.WriteLine("Milk left: none");
            }
            else
            {
                Console.Write("Milk left: ");
                Console.Write(String.Join(", ", milkNums));
                Console.WriteLine();
            }

            Dictionary<string, int> sortedCount = cofeeCount.OrderBy(x => x.Value).ThenByDescending(x => x.Key).ToDictionary(x=> x.Key, x => x.Value);

            foreach (var (name, count) in sortedCount) 
            {
                Console.WriteLine($"{name}: {count}");
            }

        }
    }
}