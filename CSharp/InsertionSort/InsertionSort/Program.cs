using System;
using System.Linq;

namespace InsertionSort
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] numbers = { 8, 29, 10, 59, 297, 409, 2 };

            InsertionSort(numbers);

            numbers.ToList().ForEach(n => { Console.WriteLine(n); });

            Console.ReadKey();
        }

        static void InsertionSort(int[] numbers)
        {
            if (numbers == null || numbers.Length == 0) throw new ArgumentException("No items in array or array null.");

            for (int startOfUnsortedArray = 1; startOfUnsortedArray < numbers.Length; startOfUnsortedArray++)
            {
                int currentIndexOfElementToCompare = startOfUnsortedArray;

                for (int indexOfElementToCompareWithInTheSortedArray = startOfUnsortedArray - 1;
                    indexOfElementToCompareWithInTheSortedArray >= 0;
                    indexOfElementToCompareWithInTheSortedArray--)
                {
                    if (numbers[currentIndexOfElementToCompare] < numbers[indexOfElementToCompareWithInTheSortedArray])
                    {
                        int temp = numbers[indexOfElementToCompareWithInTheSortedArray];
                        numbers[indexOfElementToCompareWithInTheSortedArray] = numbers[currentIndexOfElementToCompare];
                        numbers[currentIndexOfElementToCompare] = temp;

                        currentIndexOfElementToCompare = indexOfElementToCompareWithInTheSortedArray;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
    }
}