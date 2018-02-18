using System;
using System.Collections.Generic;
using System.Linq;

namespace relativityChartProblemConsoleApplication.Challenges
{
    public class ChartChallenge : IChartChallenge
    {
        public void WriteChart(int[] input)
        {
            //ordering input to take highest number first
            var orderedInput = input.OrderByDescending(s => s);
            var highestNumber = orderedInput.First();
            var lowestNumber = orderedInput.Last();
            Dictionary<int, int> dictNumberPosition = new Dictionary<int, int>();

            //dictionary to add numbers and their position
            foreach (var i in input)
            {
                dictNumberPosition.Add(i, Array.IndexOf(input, i));
            }

            //if highest number is negative then chart should start from 0
            if (highestNumber < 0) highestNumber = 0;

            // traversing from highest to lowest to have rows
            for (int i = highestNumber; i >= lowestNumber; i--)
            {
                var positionOfCurrentNumber = dictNumberPosition.Keys.Any(s => s == i) ? dictNumberPosition[i] : -1;

                //handling positive number
                if (i > 0)
                {
                    Dictionary<int, int> numbersGreaterThanCurrent =
                        dictNumberPosition.Where(s => s.Key > i).ToDictionary(s => s.Key, k => k.Value);

                    for (int j = 0; j < input.Count(s => s > 0); j++)
                    {
                        PrintRequiredDisplay(j, positionOfCurrentNumber, numbersGreaterThanCurrent);

                    }
                    Console.WriteLine("");

                }
                //handling the case when number is 0 for -
                if (i == 0)
                {
                    Add0Line(orderedInput);
                }

                //handling negative number
                if (i < 0)
                {
                    Dictionary<int, int> numberslessThanCurrent =
                        dictNumberPosition.Where(s => s.Key < i).ToDictionary(s => s.Key, k => k.Value);

                    for (int j = 0; j < input.Length; j++)
                    {
                        PrintRequiredDisplay(j, positionOfCurrentNumber, numberslessThanCurrent);

                    }
                    Console.WriteLine("");
                }
            }
            //if there aer no negative number then adding - in the end
            if (!orderedInput.Any(s => s < 0))
            {
                Add0Line(orderedInput);
            }
        }
        //Refactored function to avoid duplicate code
        private static void Add0Line(IOrderedEnumerable<int> orderedInput)
        {
            for (int j = 0; j < orderedInput.Count(); j++)
            {
                Console.Write("-");
            }
            Console.WriteLine("");
        }

        //Refactored function to avoid duplicate code
        private static void PrintRequiredDisplay(int j, int positionOfCurrentNumber, Dictionary<int, int> numbersGreaterThanCurrent)
        {
            if (j == positionOfCurrentNumber)
                Console.Write("X");
            else if (numbersGreaterThanCurrent.Any() && numbersGreaterThanCurrent.Values.Contains(j))
            {
                Console.Write("X");
            }
            else if (j < positionOfCurrentNumber)
                Console.Write(" ");
            else if (j > positionOfCurrentNumber)
                Console.Write(" ");
        }
    }
}
