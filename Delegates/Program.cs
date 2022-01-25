using System;
using System.Collections.Generic;
using System.Linq;

namespace Delegates
{
    internal class Program
    {
        // DRY
        // Don't
        // Repeat
        // Yourself


        public delegate string IntegerToString(int item);


        static void Main(string[] args)
        {
            List<int> values = new List<int> { 2, 4, 6, 8};


            PrintAll(values);
            DoubleAndPrintAll(values);
            PrependWordAndPrintAll(values);

            DoSomethingAndPrintAll(values, GetSelf);
            DoSomethingAndPrintAll(values, MultiplyByTwo);
            DoSomethingAndPrintAll(values, PrependWord);

            DoSomethingAndPrintAll(values, n => n.ToString());
            DoSomethingAndPrintAll(values, n => $"Number {n}");

            DoSomethingAndPrintAll(values, n => 
            { 
                int doubled = n * 2; 
                return doubled.ToString(); 
            });



            List<int> secondList = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            List<int> evenSquares = new List<int>();
            foreach (int value in secondList)
            {
                if (!(value % 2 == 0))
                {
                    continue;
                }

                evenSquares.Add(value * value);
            }

            // Preview of LINQ
            // We're not discussing LINQ yet, but this is the main
            // reason we need to know about lambdas.
            List<int> evenSquares2 = secondList
                .Where(x => x % 2 == 0)
                .Select(x => x * x)
                .ToList();
        }

        public static void DoSomethingAndPrintAll(List<int> list, Func<int, string> func)
        {
            foreach (int item in list)
            {
                string toPrint = func(item);
                Console.WriteLine(toPrint);
            }
        }


        public static void PrintAll(List<int> list)
        {
            foreach (int item in list)
            {
                string toPrint = item.ToString();
                Console.WriteLine(toPrint);
            }
        }

        public static void DoubleAndPrintAll(List<int> list)
        {
            foreach (int item in list)
            {
                int doubled = item * 2;
                string toPrint = doubled.ToString();
                Console.WriteLine(toPrint);
            }
        }

        public static void PrependWordAndPrintAll(List<int> list)
        {
            foreach (int item in list)
            {
                string toPrint = $"Number {item}";
                Console.WriteLine(toPrint);
            }
        }

        public static string GetSelf(int item)
        {
            return item.ToString();
        }

        public static string MultiplyByTwo(int item)
        {
            int doubled = item * 2;
            return doubled.ToString();
        }

        public static string PrependWord(int item)
        {
            return $"Number {item}";
        }

    }
    
}
