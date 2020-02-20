using System;
using System.Collections.Generic;
using System.Linq;

namespace SugarHigh
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int[] firstArray = Console.ReadLine()
                    .Split(", ")
                    .Select(int.Parse)
                    .ToArray();

                int sugarHigh = Convert.ToInt32(Console.ReadLine());

                int[] copyArray = new int[firstArray.Length];
                firstArray.CopyTo(copyArray, 0);

                Array.Sort(copyArray);

                List<int> candies = new List<int>();
                int sum = copyArray[0];
                if (sum < sugarHigh)
                {
                    candies.Add(copyArray[0]);

                    for (int i = 1; i < copyArray.Length; i++)
                    {
                        sum += copyArray[i];
                        if (sum < sugarHigh)
                        {
                            candies.Add(copyArray[i]);
                        }
                        else
                        {
                            break;
                        }
                    }
                }

                List<int> indexOfCandies = new List<int>();
                if (candies.Count == 0)
                {
                    Console.WriteLine("[]");
                }
                else
                {
                    foreach (var candy in candies)
                    {
                        indexOfCandies.Add(Array.IndexOf(firstArray, candy));
                        indexOfCandies.Sort();
                    }

                    Console.Write("[" + string.Join(", ", indexOfCandies) + "]");
                }
            }
            catch (FormatException e)
            {
                Console.WriteLine("Invalid input!!!", e);
            }
        }

    }
}
