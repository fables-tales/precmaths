using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrecMaths
{
    public enum MathOperator
    {
        Plus,
        Minus,
        Multiply,
        Divide,
        
        Power,
        OpenBracket,
        CloseBracket
        
    }
    public class OperatorSymbol:Symbol
    {
        public override string ToString()
        {
            if (this.ContainedOperator == MathOperator.CloseBracket)
            {
                return ")";
            }
            else if (this.ContainedOperator == MathOperator.Divide)
            {
                return "/";
            }
            else if (this.ContainedOperator == MathOperator.Minus)
            {
                return "-";
            }
            else if (this.ContainedOperator == MathOperator.Multiply)
            {
                return "*";
            }
            else if (this.ContainedOperator == MathOperator.OpenBracket)
            {
                return "(";
            }
            else if (this.ContainedOperator == MathOperator.Plus){
                return "+";
            }
            else if (this.ContainedOperator == MathOperator.Power)
            {
                return "^";
            }
            else
            {
                return "";
            }
        }
        public OperatorSymbol(MathOperator o)
        {
            this.ContainedOperator = o;
            if (o == MathOperator.CloseBracket)
            {
                this.precedence = -2;
            }
            else if (o == MathOperator.Divide)
            {
                this.precedence = 8;
            }
            else if (o == MathOperator.Minus)
            {
                this.precedence = 6;
            }
            else if (o == MathOperator.Multiply)
            {
                this.precedence = 8;
            }
            else if (o == MathOperator.OpenBracket)
            {
                this.precedence = -1;
            }
            else if (o == MathOperator.Plus)
            {
                this.precedence = 6;
            }
            else if (o == MathOperator.Power)
            {
                this.precedence = 9;
            }
            else
            {
                this.precedence = -62345;
            }

        }
        public MathOperator ContainedOperator;
        private int precedence;
        public int Precedence
        {
            get
            {
                return this.precedence;
            }
        }
    }
}
