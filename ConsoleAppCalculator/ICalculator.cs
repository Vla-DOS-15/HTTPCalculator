using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCalculatorHttp
{
    public interface ICalculator
    {
        public Task<CalculatorResult> Operation(string opp, decimal a, decimal b);
    }
}
