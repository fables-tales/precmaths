using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrecMaths.Symbols
{
    public static class Evaluator
    {
        public static string EvaluateInFixMaths(string maths,int precision)
        {
            List<Symbol> infix = ShuntingYardAlgorithm.MathsTextToInFixSymbolList(maths);
            List<Symbol> rpn = ShuntingYardAlgorithm.InFixToReversePolish(infix);
            SymbolicCalculation e = new SymbolicCalculation(rpn);
            return e.EvaluateString(precision);
            
        }
    }
}
