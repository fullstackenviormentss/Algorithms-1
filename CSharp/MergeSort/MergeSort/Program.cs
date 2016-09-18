using System;
using System.Collections.Generic;

namespace MergeSort
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintGreeting();

            var source = GetInputArrayFromUser();

            if (source == null) return;

            var sorted = MergeSort(source);

            source.Print(leadingMessage: "Source: ");
            sorted.Print(leadingMessage: "Sorted: ");

            Console.ReadKey();
        }

        static int[] MergeSort(int[] source)
        {
            if (source == null) throw new ArgumentNullException("source");

            // if the array has just one element, 
            // then it is already sorted
            if (source.Length <= 1) return source;

            // If the array has more than one element
            // halve the array
            // If it has an even length, halve it exactly
            // Otherwise, halve it approximately such that 
            // one of the halves, it doesn't matter which one,
            // has the extra element
            var midPoint = (int)(source.Length / 2);

            var lArray = new int[midPoint];
            Array.Copy(source, 0, lArray, 0, lArray.Length);

            var rArray = new int[source.Length - midPoint];
            Array.Copy(source, midPoint, rArray, 0, rArray.Length);

            lArray = MergeSort(lArray);
            rArray = MergeSort(rArray);
            
            return Merge(lArray, rArray);
        }

        static int[] Merge(int[] lArray, int[] rArray)
        {
            var l = 0; var r = 0;
            var llen = lArray.Length; var rlen = rArray.Length;
            var sorted = new int[llen + rlen];
            var counter = 0;

            while(l < llen || r < rlen)
            {
                if (l == llen && r == rlen) break;

                if (l == llen - 1 && r == rlen)
                {
                    sorted[counter++] = lArray[l++];
                }
                else if (l == llen && r == rlen - 1)
                {
                    sorted[counter++] = rArray[r++];
                }
                else if (l < llen && r < rlen)
                {
                    if (lArray[l] == rArray[r])
                    {
                        sorted[counter++] = lArray[l++];
                        sorted[counter++] = rArray[r++];
                    }
                    else if (lArray[l] < rArray[r])
                    {
                        sorted[counter++] = lArray[l++];
                    }
                    else
                    {
                        sorted[counter++] = rArray[r++];
                    }
                }
            }

            return sorted;
        }

        static void PrintGreeting()
        {
            Console.WriteLine("This program uses the merge sort algorithm to sort the elements in an integer \narray.\n");
            Console.WriteLine("You will be asked to enter each integer element of the array. At any time, \nto stop entering the elements and perform the sort, press 'q' or 'Q'.\n");
            Console.WriteLine("Press ENTER to start entering the numbers. Press 'Q' or 'q' to exit \nthis program.");
        }


        static int[] GetInputArrayFromUser()
        {
            var s = Console.ReadLine();
            if (s.Equals("q", StringComparison.InvariantCultureIgnoreCase)) return null;

            var list = new List<int>(100);
            while (!s.Equals("q", StringComparison.InvariantCultureIgnoreCase))
            {
                Console.Write("Enter a number: ");
                s = Console.ReadLine();
                
                int n = 0;
                var b = int.TryParse(s, out n);
                if (b) list.Add(n);
            }

            return list.ToArray();
        }
    }
}
