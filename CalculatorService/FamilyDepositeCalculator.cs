using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorService
{
    class FamilyDepositeCalculator : DepositeCalculator
    {
        private const int RATE = 13;
        public override decimal Rate
        {
            get
            {
                return RATE;
            }

        }
    }
}
