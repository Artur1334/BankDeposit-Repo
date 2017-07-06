using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorService
{
    public class AccumulativeDepositeCalculator : DepositeCalculator
    {
        private const int RATE = 12;
        public override decimal Rate
        {
            get
            {
                return RATE;
            }
            
        }
        
    }
}
