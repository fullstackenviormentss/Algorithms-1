using System;
using System.Collections.Generic;
using System.Linq;

namespace PrimalityTest
{
    public static class Extensions
    {
        private static IEnumerable<int> primesTillTwenty = new [] { 2, 3, 5, 7, 11, 13, 17, 19 };

        public static PrimalityTestReport IsPrime(this int n)
        {
            IEnumerable<int> divisors = null;

            if (n.IsAPrimeNumberTillTwenty()) return PrimalityTestReport.Yes;

            var squareRoot = (int)Math.Ceiling(Math.Sqrt(n));

            var factors = n.GetFactors(primesTillTwenty).ToList();
            List<int> multiples = null;
            
            if (factors != null && factors.Count() > 0)
            {
                // It is not a prime number, just get its factors
                factors = GetAllMultiplesOf(factors, 2, squareRoot).ToList();
                
                divisors = Enumerable.Range(2, squareRoot - 2)
                    .Except(factors);

                foreach(var divisor in divisors)
                {
                    if (n % divisor == 0)
                        factors.Add(divisor);
                }

                return new PrimalityTestReport(false, factors);
            }
            else
            {
                // It may or may not be a prime, keep testing with larger divisors
                multiples = GetAllMultiplesOf(primesTillTwenty, 20, squareRoot).ToList();
                divisors = Enumerable.Range(20, squareRoot - 20)
                    .Except(multiples);

                if (factors == null) factors = new List<int>();

                foreach(var divisor in divisors)
                {
                    if (n % divisor == 0)
                    {
                        factors.Add(divisor);
                    }
                }

                if (factors.Count() == 0) return PrimalityTestReport.Yes;

                return new PrimalityTestReport(false, factors);
            }
        }

        public static bool IsDivisibleBy(this int n, int divisor)
        {
            return n % divisor == 0;
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
