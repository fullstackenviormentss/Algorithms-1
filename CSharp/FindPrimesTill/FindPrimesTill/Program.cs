using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace FindPrimesTill
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 0;

            Console.WriteLine("This program prints all prime numbers till a number you specify.\n");
            Console.Write("Find primes till which number? ");

            var b = int.TryParse(Console.ReadLine(), out n);
            if (!b) return;

            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var primesTillN = FindPrimesTill(n);
            stopwatch.Stop();
            var millisecondsToFind = stopwatch.ElapsedMilliseconds;
            var numFound = primesTillN.Count();

            Console.WriteLine($"\n{numFound} primes between 1 and {n}. Time taken to find primes: {millisecondsToFind} milliseconds");
            Console.WriteLine("Printing...\n");

            stopwatch.Reset();
            stopwatch.Start();
            primesTillN.Print();
            stopwatch.Stop();
            var millisecondsToPrint = stopwatch.ElapsedMilliseconds;

            Console.WriteLine($"\n\nSTATS:\nTime to find {numFound} primes between 1 to {n}: {millisecondsToFind} milliseconds.");
            Console.WriteLine($"Time taken to print: {millisecondsToFind} milliseconds.\n");
            
            Console.ReadKey();
        }

        private static IEnumerable<int> FindPrimesTill(int n)
        {
            if (n < 0) throw new ArgumentException("The argument must be a positive integer.");

            var primesTillTwenty = new List<int> { 2, 3, 5, 7, 11, 13, 17, 19 };

            if (n <= 20) return primesTillTwenty.Where(p => p <= n);

            return primesTillTwenty.Concat(Enumerable.Range(21, n - 21)
                .Where(num =>
                {
                    var sqrRoot = (int)Math.Sqrt(num);

                    if (sqrRoot <= 20)
                    {
                        // If it is divisible by any of the primes 
                        // till twenty, then it is not prime
                        // If it is not divisible by any of the primes
                        // till twenty, then it is a prime, because
                        // it won't be divisible by any of the multiples 
                        // of those primes either
                        // For e.g., if it is not divisible by 2, then it won't
                        // be divisible by 4, 6, 8, etc. anyway
                        return !primesTillTwenty.Any(p => num % p == 0);
                    }
                    else
                    {
                        var divisible = primesTillTwenty.Any(p => num % p == 0);

                        if (divisible) return false;

                        // If it is not divisible by any prime till twenty, 
                        // then don't bother trying to divide it by any of 
                        // the multiples of those primes, because it won't divide.
                        // Divide it only by the numbers from 21 to the 
                        // square root of the number except the multiples 
                        // of the primes till twenty
                        var multiplesOfAllPrimesFromTwentyOneTillSquareRoot =
                            GetMultiplesOf(primesTillTwenty, 21, sqrRoot);

                        var b = Enumerable.Range(21, sqrRoot - 21)
                        .Except(primesTillTwenty)
                        .Except(multiplesOfAllPrimesFromTwentyOneTillSquareRoot)
                        .Any(p => num % p == 0);

                        return !b;
                    }
                }));
        }

        private static IEnumerable<int> GetMultiplesOf(IEnumerable<int> primesTillTwenty, int from, int till)
        {
            if (from > till)
                throw new ArgumentException("The argument 'from' must be lesser than or equal to the argument 'till'.");

            for (int i = from; i <= till; i++)
                foreach (var num in primesTillTwenty)
                    if (i % num == 0)
                        yield return num;
        }
    }
}