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
        Mod,
        Power,
        
    }
    public class OperatorSymbol:Symbol
    {
        public MathOperator ContainedOperator; 
    }
}
