using System;
using System.Diagnostics;

namespace Fibonacci
{
    public class Find
    {
        public static Tuple<int, int> SurroundingTerms(int middleTerm)
        {
            if (middleTerm == 0) throw new ArgumentException("A Fibonacci with the value provided for the argument 'middleTerm' does not exist. The middle term must be an integer greater than zero.");

            // But wait! Or, it could be [1, 1, 2]
            // if (middleTerm == 1) return new Tuple<int, int>(0, 1);

            // https://en.wikipedia.org/wiki/Golden_ratio
            // Since the terms of a Fibonacci series / sequence are in the golden ratio, the
            // following can be said about the relationship between the terms.
            // If (x, middleTerm, y) represents the series, then:
            // middleTerm : x = y : middleTerm
            // And we also know that (y = x + middleTerm)
            // Therefore:
            // (middleTerm : x) == ((x + middleTerm) : middleTerm)
            // Solving for x, we get:
            // x = Square root of (m(m - x))

            // This is a quadratic equation.
            // It looks like we may need another piece of information
            // before we can solve it

            // Aha! Eureka! The other piece of information is a known -- the golden ratio
            // If I am right, we know this ratio to be a constant
            // It could be an irrational but we know it with some precision, no matter how debatable

            const double goldenRatio = 1.6180339887;

            // We may now use either of the two pieces of information to solve for x:
            // m : x = goldenRatio; OR
            // (x + m) : m = goldenRatio

            var before = (int)Math.Round(middleTerm / goldenRatio);
            var after = before + middleTerm;

            Debug.Print((after / middleTerm).ToString());

            return new Tuple<int, int>(before, after);
        }
    }
}
