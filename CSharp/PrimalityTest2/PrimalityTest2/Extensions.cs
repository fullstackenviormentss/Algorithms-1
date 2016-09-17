using System;
using System.Collections.Generic;
using System.Linq;

namespace PrimalityTest2
{
    public static class Extensions
    {
        private static IEnumerable<int> primesTillTwenty = new[] { 2, 3, 5, 7, 11, 13, 17, 19 };

        public static bool IsPrime(this int n)
        {
            IEnumerable<int> divisors = null;

            if (n.IsAPrimeNumberTillTwenty()) return true;

            var squareRoot = (int)Math.Ceiling(Math.Sqrt(n));

            if (n.GetFactors(primesTillTwenty)?.Count() > 0) return false;

            if (squareRoot < 20) return true;

            // It may or may not be a prime, keep testing with larger divisors
            var multiples = GetAllMultiplesOf(primesTillTwenty, 20, squareRoot);

            divisors = Enumerable.Range(20, squareRoot - 20)
                .Except(multiples);

            return !divisors.Any(divisor => n % divisor == 0);
        }

        public static IEnumerable<int> GetFactors(this int n, IEnumerable<int> divisors)
        {
            return divisors.Where(divisor => n % divisor == 0);
        }

        public static bool IsAPrimeNumberTillTwenty(this int n)
        {
            return primesTillTwenty.Contains(n);
        }

        public static IEnumerable<int> GetAllMultiplesOf(IEnumerable<int> numbers, int from, int till)
        {
            if (from > till)
                throw new ArgumentOutOfRangeException("The argument 'from' must be smaller than or equal to the argument 'till'.");

            for (int i = from; i <= till; i++)
                foreach (var number in numbers)
                    if (i % number == 0)
                        yield return i;
        }
    }
}
