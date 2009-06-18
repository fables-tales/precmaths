using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrecMaths
{
    public abstract class NumberSymbol:Symbol
    {
        internal Rational power;
        public abstract string EvaluteString(int precision);
        public abstract double EvaluateDouble();
        public abstract decimal EvaluateDecimal();
    }
}
