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
        private Rational internalevaluate(int precision)
        {
            return PowerEvaluation.EvaluateRationalPower(this.containedvalue, this.power, precision);
        }
        public override decimal EvaluateDecimal()
        {
            return this.internalevaluate(64).EvaluateDecimal();
        }
        public override string EvaluteString(int precision)
        {
            return this.internalevaluate(precision).EvaluateString(precision);
        }
        public override double EvaluateDouble()
        {
            return this.internalevaluate(64).EvaluateDouble();
        }
    }
}
