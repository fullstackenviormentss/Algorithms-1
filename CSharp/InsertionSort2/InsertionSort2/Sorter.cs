using System;

namespace InsertionSort2
{
    public class Sorter
    {
        public static void InsertionSort(int[] source)
        {
            // Since this is done in place, there is no need to return anything

            if (source == null) throw new ArgumentNullException("source");

            var len = source.Length;

            if (len <= 1) return;

            for(int counter = 1; counter < len; counter++)
            {
                var key = counter;

                for(int backward = key - 1; backward >= 0; backward--, key--)
                {
                    if (source[key] >= source[backward]) break;

                    Swap(source, backward, key);
                }
            }
        }

        private static void Swap(int[] source, int before, int after)
        {
            if (source == null) throw new ArgumentNullException("source");
            var len = source.Length;
            if (before < 0 || before > len) throw new IndexOutOfRangeException("Argument before is out of the range of indices for the source array.");
            if (after < 0 || after > len) throw new IndexOutOfRangeException("Argument after is out of the range of indices for the source array.");

            var temp = source[before];
            source[before] = source[after];
            source[after] = temp;
        }
    }
}