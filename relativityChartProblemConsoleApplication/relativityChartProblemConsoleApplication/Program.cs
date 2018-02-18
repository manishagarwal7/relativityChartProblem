using System;
using System.Collections.Generic;
using System.Linq;
using relativityChartProblemConsoleApplication.Challenges;

namespace relativityChartProblemConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            RunChartProblem();
        }

        static void RunChartProblem()
        {
            int _input_size = 0;
            _input_size = Convert.ToInt32(Console.ReadLine());
            int[] _input = new int[_input_size];
            int _input_item;
            for (int _input_i = 0; _input_i < _input_size; _input_i++)
            {
                _input_item = Convert.ToInt32(Console.ReadLine());
                _input[_input_i] = _input_item;
            }

            IChartChallenge challenge = new ChartChallenge();

            challenge.WriteChart(_input);
            Console.ReadLine();
        }
     
    }
}
