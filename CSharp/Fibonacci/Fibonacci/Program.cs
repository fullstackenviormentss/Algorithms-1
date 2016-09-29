using System;
using System.Collections.Generic;
using System.Linq;
using Extensions;

namespace Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            var max = GetUserInput();

            if (max == -1) return;

            UsingLoop(max);

            UsingRecursionWithSideEffects(max);

            UsingRecursionWithoutSideEffects(max);

            UsingLINQ(max);

            Console.ReadKey();
        }

        private static int GetUserInput()
        {
            Console.WriteLine("This program prints a Fibonacci series till a number you specify.");
            Console.Write("Print Fibonacci series till: ");

            var n = -1;
            var b = int.TryParse(Console.ReadLine(), out n);
            return n;
        }

        private static void VerifySeries(IEnumerable<int> series)
        {
            Console.WriteLine("\nVerifying:");

            var count = series.Count();

            for (int i = 1; i <  count - 1; i++)
            {
                var middleTerm = series.ElementAt(i);
                var tuple = Find.SurroundingTerms(middleTerm);
                Console.WriteLine($"[{tuple.Item1}, {middleTerm}, {tuple.Item2}]");
            }
        }

        static void UsingLoop(int max)
        {
            Console.WriteLine("\nGenerating Fibonacci series using a loop...");
            var series = Loop.Till(max);

            series.Print();

            VerifySeries(series);
        }

        static void UsingRecursionWithSideEffects(int max)
        {
            Console.WriteLine("\nGenerating Fibonacci series using a recursion (with side-effects)...");
            Recurse.TillWithSideEffect(max);
        }

        static void UsingRecursionWithoutSideEffects(int max)
        {
            Console.WriteLine("\nGenerating Fibonacci series using a recursion (WITHOUT side-effects)...");
            var series = Recurse.Till(max);

            series.Print();

            VerifySeries(series);
        }

        private static void UsingLINQ(int max)
        {
            Console.WriteLine("\nGenerating Fibonacci series using LINQ...");
            var series = LINQ.Till(max);

            series.Print();

            VerifySeries(series);
        }
    }
}