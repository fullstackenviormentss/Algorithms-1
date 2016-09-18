using System;

namespace SelectionSort
{
    public class Sorter
    {
        public static void SelectionSort(int[] source)
        {
            // Since this is done in place, there is no need to return anything

            if (source == null) throw new ArgumentNullException("source");

            var len = source.Length;

            if (len <= 1) return;

            // Find the minimum
            for(int unsortedStart = 0, sortedEnd = -1; unsortedStart < len - 1 ; unsortedStart++)
            {
                int minIndex = unsortedStart;

                for (int counter = unsortedStart; counter < len; counter++)
                {
                    if (source[counter] < source[minIndex])
                        minIndex = counter;
                }

                Swap(source, minIndex, ++sortedEnd);
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

        private class ArrayElement<T>
        {
            public ArrayElement(int index, T value) { Index = index; Value = value; }
            public int Index { get; set; }
            public T Value { get; set; }
        }
    }
}
