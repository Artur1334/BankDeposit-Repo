using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorService
{
    public class CalculatorResolver
    {
        private const string suffix = "DepositeCalculator";
        public static DepositeCalculator Get(string name)
        {
            var instanceName = string.Format("CalculatorService.{0}{1}, CalculatorService", name, suffix);
            var type = Type.GetType(instanceName);

            var calculator = Activator.CreateInstance(type) as DepositeCalculator;

            return calculator;

        }
    }
}
