using System;
using System.Collections.Generic;

namespace InsertionSort2
{
    public class UI
    {
        public static void PrintGreeting()
        {
            Console.WriteLine("This program uses the insertion sort algorithm to sort the elements in an integer \narray.\n");
            Console.WriteLine("You will be asked to enter each integer element of the array. At any time, \nto stop entering the elements and perform the sort, press 'q' or 'Q'.\n");
            Console.WriteLine("Press ENTER to start entering the numbers. Press 'Q' or 'q' to exit \nthis program.");
        }

        public static int[] GetInputArrayFromUser()
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
