using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PrecMaths.Numbers;

namespace PrecMaths.Symbols
{
    public class SymbolicCalculation
    {
        private List<Symbol> symbollist;
        private Stack<Symbol> calculationstack;
        public SymbolicCalculation(SymbolTree s)
        {
            this.symbollist = s.PostOrderTraverse();
            this.calculationstack = new Stack<Symbol>();
        }
        public SymbolicCalculation(List<Symbol> ReversePolishNotation)
        {
            this.symbollist = new List<Symbol>();
            this.symbollist.AddRange(ReversePolishNotation);
            this.calculationstack = new Stack<Symbol>();
        }
        public string EvaluateString(int Precision)
        {
            foreach (Symbol s in this.symbollist){
                if (s is NumberSymbol)
                {
                    this.calculationstack.Push(s);
                }
                if (s is OperatorSymbol)
                {
                    NumberSymbol b = (NumberSymbol)this.calculationstack.Pop();
                    NumberSymbol a = (NumberSymbol)this.calculationstack.Pop();
                    OperatorSymbol so = (OperatorSymbol)s;
                    Rational result = new Rational(1);
                    if (so.ContainedOperator == MathOperator.Plus){
                        result = a.EvaluateRational(2 * Precision) + b.EvaluateRational(2 * Precision);
                    }
                    else if (so.ContainedOperator == MathOperator.Minus)
                    {
                        result = a.EvaluateRational(2 * Precision) - b.EvaluateRational(2 * Precision);
                    }
                    else if (so.ContainedOperator == MathOperator.Multiply)
                    {
                        result = a.EvaluateRational(2 * Precision) * b.EvaluateRational(2 * Precision);
                    }
                    else if (so.ContainedOperator == MathOperator.Divide)
                    {
                        result = a.EvaluateRational(2 * Precision) / b.EvaluateRational(2 * Precision);
                    }
                    else if (so.ContainedOperator == MathOperator.Power)
                    {
                        a.power *= b.EvaluateRational(Precision * 2);
                        result = a.EvaluateRational(Precision * 2);
                    }
                    else
                    {
                        throw new NotImplementedException();
                    }
                    this.calculationstack.Push(new RationalSymbol(result,1));
                }
            }
            
            
            NumberSymbol epic = (NumberSymbol)this.calculationstack.Pop();
            return epic.EvaluateRational(2 * Precision).EvaluateString(Precision);
            
        }
    }
}
