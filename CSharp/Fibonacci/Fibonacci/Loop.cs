using System;
using System.Collections.Generic;

namespace Fibonacci
{
    public class Loop
    {
        public static IEnumerable<int> Till(int max)
        {
            if (max < 0) throw new ArgumentException("The argument 'max' must be greater than or equal to 0.");
            
            if (max == 0)
            {
                yield return 0;
                yield break;
            }

            int previous = 0, current = 1; int next = previous + current;
            yield return previous;
            yield return current;
            
            while((next = previous + current) <= max)
            {
                yield return next;

                previous = current;
                current = next;
            }

            yield break;
        }
    }
}
