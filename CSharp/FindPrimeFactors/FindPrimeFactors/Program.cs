using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace FindPrimeFactors
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 0;

            Console.WriteLine("This program finds all prime factors of any number you wish.");
            Console.Write("Find prime factors of which number? ");

            var b = int.TryParse(Console.ReadLine(), out n);
            if (!b) return;

            var w = new Stopwatch();
            w.Start();
            var primeFactors = FindPrimeFactorsOf(n).ToList();
            w.Stop();
            var millisecondsToFind = w.ElapsedMilliseconds;
            var count = primeFactors.Count;
            Console.WriteLine($"Time taken to find {count} prime factors of {n}: {millisecondsToFind} milliseconds.");

            w.Reset();
            w.Start();
            primeFactors.Print(throwOnEmptySource: false);
            w.Stop();
            var millisecondsToPrint = w.ElapsedMilliseconds;
            Console.WriteLine($"Time taken to print {count} prime factors of {n}: {millisecondsToPrint} milliseconds.");

            Console.WriteLine($"\n\nSTATS:\nTime to find {count} primes between 1 to {n}: {millisecondsToFind} milliseconds.");
            Console.WriteLine($"Time taken to print: {millisecondsToPrint} milliseconds.\n");

            Console.ReadKey();
        }

        static IEnumerable<int> FindPrimeFactorsOf(int n)
        {
            var primesTillTwenty = new List<int> { 2, 3, 5, 7, 11, 13, 17, 19 };

            if (n < 20)
                return primesTillTwenty.Where(p => (p < n) && (n % p == 0));

            var primeFactorsTillTwenty = primesTillTwenty.Where(p => n % p == 0);

            var sqrRoot = (int)Math.Sqrt(n);

            if (sqrRoot <= 20) return primeFactorsTillTwenty;

            var multiplesOfPrimesTillTwenty = GetMultiplesOf(primesTillTwenty, 21, sqrRoot);

            var primeFactorsLargerThanTwenty = Enumerable.Range(21, sqrRoot - 21)
                .Except(multiplesOfPrimesTillTwenty)
                .Where(num =>
                {
                    var sroot = (int)Math.Sqrt(num);

                    if (sroot <= 20) return n % num == 0;

                    var isPrime = !(Enumerable.Range(21, sroot - 21)
                    .Except(multiplesOfPrimesTillTwenty)
                    .Any(x => num % x == 0));

                    return isPrime && (n % num == 0);
                });
            
            return primeFactorsTillTwenty.Concat(primeFactorsLargerThanTwenty);
        }

        private static IEnumerable<int> GetMultiplesOf(IEnumerable<int> primesTillTwenty, int from, int to)
        {
            if (from > to)
                throw new ArgumentException("The argument 'from' must be less than or equal to the argument 'to'.");

            for(int i = from; i <= to; i++)
                foreach (var prime in primesTillTwenty)
                    if (i % prime == 0)
                        yield return i;
        }
    }
}