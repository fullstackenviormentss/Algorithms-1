using System.Collections.Generic;

namespace PrimalityTest
{
    public class PrimalityTestReport
    {
        public static PrimalityTestReport Yes = new PrimalityTestReport(true, null);

        public PrimalityTestReport(bool isPrime, IEnumerable<int> factors)
        {
            IsPrime = isPrime;
            Factors = factors;
        }

        public bool IsPrime { get; protected set; }
        public IEnumerable<int> Factors { get; protected set; }
    }
}
