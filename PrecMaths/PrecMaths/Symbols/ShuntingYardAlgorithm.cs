using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrecMaths.Symbols
{
    
    
    public static class ShuntingYardAlgorithm
    {
        public static List<Symbol> InFixToReversePolish(List<Symbol> InFix)
        {
            List<Symbol> rpn = new List<Symbol>();
            Stack<Symbol> sstack = new Stack<Symbol>();
            foreach (Symbol s in InFix)
            {
                if (s is NumberSymbol)
                {
                    rpn.Add(s);
                }
                else if (s is OperatorSymbol)
                {
                    OperatorSymbol os = (OperatorSymbol)s;
                    if (os.ContainedOperator != MathOperator.OpenBracket && os.ContainedOperator != MathOperator.CloseBracket)
                    {
                        if (sstack.Count > 0)
                        {
                            while (os.Precedence <= ((OperatorSymbol)sstack.Peek()).Precedence)
                            {
                                rpn.Add(sstack.Pop());
                                if (sstack.Count == 0)
                                {
                                    break;
                                }
                            }
                        }
                        sstack.Push(s);
                    }
                    else if (os.ContainedOperator == MathOperator.OpenBracket)
                    {
                        sstack.Push(os);
                    }
                    else if (os.ContainedOperator == MathOperator.CloseBracket)
                    {
                        bool done = false;
                        while (!done)
                        {
                            
                            Symbol stacktop = sstack.Peek();
                            if (stacktop is OperatorSymbol)
                            {
                                if (((OperatorSymbol)stacktop).ContainedOperator == MathOperator.OpenBracket)
                                {
                                    done = true;
                                    sstack.Pop();
                                    break;
                                }
                            }
                            rpn.Add(sstack.Pop());
                        }
                        
                    }
                }
            }
            while (sstack.Count != 0)
            {
                rpn.Add(sstack.Pop());
            }
            return rpn;
        }
        public static List<Symbol> MathsTextToInFixSymbolList(string Maths)
        {
            List<Symbol> InFix = new List<Symbol>();
            string buffer = "";
            foreach (char c in Maths)
            {

                bool IsAnOperator = false;
                OperatorSymbol os = new OperatorSymbol(MathOperator.Minus);
                if (c == '+')
                {
                    IsAnOperator = true;
                    os = new OperatorSymbol(MathOperator.Plus);
                    
                }
                else if (c == '-')
                {
                    IsAnOperator = true;
                    os = new OperatorSymbol(MathOperator.Minus);
                }
                else if (c == '/')
                {
                    IsAnOperator = true;
                    os = new OperatorSymbol(MathOperator.Divide);
                }
                else if (c == '*')
                {
                    IsAnOperator = true;
                    os = new OperatorSymbol(MathOperator.Multiply);
                }
                else if (c == '(')
                {
                    IsAnOperator = true;
                    os = new OperatorSymbol(MathOperator.OpenBracket);
                    
                }
                else if (c == ')')
                {
                    IsAnOperator = true;
                    os = new OperatorSymbol(MathOperator.CloseBracket);
                }
                else if (c == '^')
                {
                    IsAnOperator = true;
                    os = new OperatorSymbol(MathOperator.Power);
                }
                else
                {
                    if (c == '0' || c == '1' || c == '2' || c == '3' || c == '4' ||
                        c == '5' || c == '6' || c == '7' || c == '8' || c == '9' || c == 'p' || c == 'i'
                       )
                    {
                        IsAnOperator = false;
                        buffer += c;
                    }
                    
                }
                if (IsAnOperator)
                {
                    if (buffer != "")
                    {
                        if (buffer == "pi")
                        {
                            PiSymbol ps = new PiSymbol(1);
                            InFix.Add(ps);
                            buffer = "";
                        }
                        else
                        {
                            long add = long.Parse(buffer);
                            RationalSymbol rs = new RationalSymbol(new PrecMaths.Numbers.Rational(add), 1);
                            InFix.Add(rs);
                        }
                        buffer = "";
                    }
                    InFix.Add(os);
                }
            }
            if (buffer != "")
            {
                long b = long.Parse(buffer);
                InFix.Add(new RationalSymbol(new Numbers.Rational(b), 1));
            }

            return InFix;
        }
    }
}
