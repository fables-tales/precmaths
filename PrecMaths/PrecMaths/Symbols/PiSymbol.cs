using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PrecMaths.Numbers;

namespace PrecMaths
{
    public class PiSymbol:NumberSymbol
    {
        public PiSymbol(Rational Power)
        {
            this.power = Power;
        }
        private Rational PiSeries(int Precision)
        {
            Rational pi = new Rational(0);
            int moreprecision = Precision;
            Rational sixteentothek = new Rational(1);
            for (int i = 0; i < moreprecision; i++)
            {
                Rational a = new Rational(-2, 8 * i + 4);
                Rational b = new Rational(-1, 8 * i + 5);
                Rational c = new Rational(-1, 8 * i + 6);
                Rational d = new Rational(4, 8 * i + 1);
                pi += sixteentothek * (a + b + c + d);
                sixteentothek /= 16;
            }
            return pi;

        }
        private Rational internalevaluate(int precision)
        {
            if (this.power == 0)
            {
                return 1;
            }
            else if (this.power == 1)
            {
                return this.PiSeries(precision);
            }
            else if (this.power == -1)
            {
                return 1 / this.PiSeries(precision);
            }
            else if (this.power < -1)
            {
                Rational newpower = new Rational(this.power.Numerator.Number, this.power.Denominator.Number);
                Rational flippedpiseries = 1 / this.PiSeries(precision);
                return PowerEvaluation.EvaluateRationalPower(flippedpiseries, newpower, precision);
            }
            else
            {
                return PowerEvaluation.EvaluateRationalPower(this.PiSeries(precision), this.power, precision);
            }
            

        }
        public override string EvaluteString(int precision)
        {
            return this.internalevaluate(precision).EvaluateString(precision);
        }
        public override decimal EvaluateDecimal()
        {
            return this.internalevaluate(64).EvaluateDecimal();
        }
        public override double EvaluateDouble()
        {
            return this.internalevaluate(64).EvaluateDouble();
        }
    }
}
