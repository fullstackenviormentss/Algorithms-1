using System;
using System.Linq;

namespace PrimalityTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = null;

            do
            {
                Console.Write("Which number would you like to test for primality? Enter it here: ");

                var n = int.Parse(Console.ReadLine());

                var report = n.IsPrime();

                if (report.IsPrime)
                {
                    Console.WriteLine($"{n} is a prime number.");
                }
                else
                {
                    Console.WriteLine($"{n} is a composite number because it has the following {report.Factors.Count()} divisors / factors:");

                    foreach (var factor in report.Factors)
                        Console.WriteLine(factor);
                }

                Console.Write("Test another number (y/n): ");
                s = Console.ReadLine();

            } while (s.Equals("y", StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
