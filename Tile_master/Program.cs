using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;
using System.IO;


//<ImplicitUsings>enable</ImplicitUsings>
namespace TileMaster
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<int, string> tilesNeeded = new Dictionary<int,string>();

            tilesNeeded[40] = "Sink";
            tilesNeeded[50] = "Oven";
            tilesNeeded[60] = "Countertop";
            tilesNeeded[70] = "Wall";
            tilesNeeded[0] = "Floor";


            Dictionary<string, int> elementsCount = new Dictionary<string, int>();


            int[] whiteTilesArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Stack<int> whiteTiles = new Stack<int>();
            for (int i =0; i < whiteTilesArgs.Length; i++) 
            {
                whiteTiles.Push(whiteTilesArgs[i]);
            }
            int[] greyTilesArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Queue<int> greyTiles = new Queue<int>();

            for (int i = 0; i < greyTilesArgs.Length; i++)
            {
                greyTiles.Enqueue(greyTilesArgs[i]);
            }

            while (greyTiles.Count > 0 && whiteTiles.Count > 0) 
            {
                int currGreyTile = greyTiles.Peek();
                int currWhiteTile = whiteTiles.Peek();
                if (currGreyTile == currWhiteTile)
                {
                    int sum = currGreyTile + currWhiteTile;

                    if (tilesNeeded.ContainsKey(sum))
                    {
                        foreach (var kvp in tilesNeeded.Where(x=> x.Key == sum)) 
                        {
                            if (!elementsCount.ContainsKey(kvp.Value))
                            {
                                elementsCount.Add(kvp.Value, 0);
                            }
                            elementsCount[kvp.Value]++;
                        }
                    }
                    else
                    {
                        if (!elementsCount.ContainsKey("Floor"))
                        {
                            elementsCount.Add("Floor", 0);
                        }
                        elementsCount["Floor"]++;
                    }
                    greyTiles.Dequeue();
                    whiteTiles.Pop();
                }
                else 
                {
                    whiteTiles.Pop();
                    currWhiteTile = currWhiteTile / 2;
                    whiteTiles.Push(currWhiteTile);
                    greyTiles.Dequeue();
                    greyTiles.Enqueue(currGreyTile);
                }
            }

            if (whiteTiles.Count > 0)
            {
                Console.Write("White tiles left:");
                Console.Write(String.Join(", ", whiteTiles));
                Console.WriteLine(); 
            }
            else 
            {
                Console.WriteLine("White tiles left: none");
            }
            if (greyTiles.Count > 0)
            {
                Console.Write("Grey tiles left: ");
                Console.Write(String.Join(", ", greyTiles));
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Grey tiles left: none");
            }

            var sortDic = elementsCount.OrderByDescending(x => x.Value).ThenBy(x=>x.Key).ToDictionary(x=> x.Key, x=> x.Value);
            foreach (var kvp in sortDic) 
            {
                if (kvp.Value > 0)
                {
                    Console.WriteLine($"{kvp.Key}: {kvp.Value}");
                }
            }

        }
    }
}