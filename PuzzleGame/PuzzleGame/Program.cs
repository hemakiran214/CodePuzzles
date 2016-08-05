using System;
using System.Collections.Generic;

namespace PuzzleGame
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("----------------- Code Challenge --------------------");
            Console.WriteLine("Please enter an array of numbers seperated by comma");
            var input = Console.ReadLine().Split(',');
            var array = Array.ConvertAll(input, int.Parse);
            var len = array.Length;
            var lhsPrevSum = 0;
            var rhsPrevSum = 0;
            var lhs = new List<int>();
            var rhs = new Stack<int>();
            if (len > 2)
            {
                bool elementFound = false;
                for (int i = 0, j = len; i < len - 2 && j > 2; i++, j--)
                {
                    lhs.Add(lhsPrevSum + array[i]);
                    lhsPrevSum = lhs[i];
                    rhs.Push(rhsPrevSum + array[j - 1]);
                    rhsPrevSum = rhs.Peek();
                }
                if (lhs.Count == rhs.Count)
                {
                    foreach (int val in lhs)
                    {
                        if (val == rhs.Pop())
                        {
                            elementFound = true;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Some thing went wrong in calculations...Check ur code...");
                }
                Console.WriteLine("TEST CASE {0}", elementFound ? "PASSED" : "FAILED");
            }
            else
            {
                Console.WriteLine("The Input needs to be greater than two elements.");
            }
            Console.ReadKey();
        }

    }
}