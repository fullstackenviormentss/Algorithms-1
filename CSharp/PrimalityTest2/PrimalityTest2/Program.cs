using System;

namespace PrimalityTest2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Which number would you like to test for primality? Enter it here: ");
            var s = Console.ReadLine();
            int n = 0;
            var bNum = int.TryParse(s, out n);

            if (bNum)
            {
                do
                {
                    var bPrime = n.IsPrime();
                    Console.WriteLine($"{n} {(bPrime ? "is a" : "is not a")} prime number.");

                    Console.Write("Enter another number to test (or any non-numeric key to exit): ");
                    s = Console.ReadLine();
                    if (s.Equals("q", StringComparison.InvariantCultureIgnoreCase)) return;
                    bNum = int.TryParse(s, out n);

                } while (bNum);
            }
        }
    }
}
