using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorService
{
    public abstract class DepositeCalculator
    {
        public abstract decimal Rate { get; }

        public decimal Calculate(decimal total, int year)
        {
            var sum = total + (total * Rate / 100) * year;
            return sum;
        }
    }
}
