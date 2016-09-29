using System;
using System.Collections.Generic;
using System.Linq;

namespace Fibonacci
{
    public class Recurse
    {
        public static IEnumerable<int> Till(int max)
        {
            var series = GetFirstTwoTermsLazy();
            return series.Concat(Till(0, 1, max));
        }

        private static IEnumerable<int> GetFirstTwoTermsLazy()
        {
            yield return 0;
            yield return 1;
        }

        public static IEnumerable<int> Till(int previous, int current, int max)
        {
            int next = previous + current;

            if (next <= max)
            {
                var series = Enumerable.Repeat(next , 1);
                return series.Concat(Till(current, next, max));
            }

            return Enumerable.Empty<int>();
        }

        public static void TillWithSideEffect(int max)
        {
            Console.Write("[0, 1, ");
            TillWithSideEffect(0, 1, max);
            Console.Write("\b\b");
            Console.WriteLine("]");
        }

        public static void TillWithSideEffect(int previous, int current, int max)
        {
            int next = previous + current;

            if (next <= max)
            {
                Console.Write($"{next}, ");
                TillWithSideEffect(current, next, max);
            }
        }
    }
}
