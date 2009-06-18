using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PrecMaths.Numbers;
namespace PrecMaths
{
    public class RationalSymbol:NumberSymbol
    {
        internal Rational containedvalue;
        public RationalSymbol(Rational ContainedValue, Rational Power)
        {
            this.containedvalue = ContainedValue;
            this.power = Power;
        }
        public override Rational EvaluateRational(int Precision)
        {
            return PowerEvaluation.EvaluateRationalPower(this.containedvalue, this.power, Precision);
        }
        public override decimal EvaluateDecimal()
        {
            return this.EvaluateRational(64).EvaluateDecimal();
        }
        public override string EvaluteString(int precision)
        {
            return this.EvaluateRational(precision).EvaluateString(precision);
        }
        public override double EvaluateDouble()
        {
            return this.EvaluateRational(64).EvaluateDouble();
        }
    }
}
