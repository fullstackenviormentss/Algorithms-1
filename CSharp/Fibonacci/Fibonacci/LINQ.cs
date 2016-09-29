using Extensions;
using System.Collections.Generic;

namespace Fibonacci
{
    public class LINQ
    {
        public static IEnumerable<int> Till(int max)
        {
            return EnumerableExtensions.Generate<int>(0, 1, (p1, p2) => p1 + p2, result => result > max);
        }
    }
}
