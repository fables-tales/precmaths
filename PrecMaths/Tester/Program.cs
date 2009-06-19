using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PrecMaths;
using PrecMaths.Symbols;
using PrecMaths.Numbers;


namespace Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            string result = Evaluator.EvaluateInFixMaths("(3+4)*3", 3);
            result = Evaluator.EvaluateInFixMaths("3*(5*1-2)", 3);
            result = Evaluator.EvaluateInFixMaths("2^(1/2)",3);
            result = Evaluator.EvaluateInFixMaths("3*(4+1*2)-7", 3);
            Console.WriteLine(result);
            Console.ReadLine();

        }
    }
}
