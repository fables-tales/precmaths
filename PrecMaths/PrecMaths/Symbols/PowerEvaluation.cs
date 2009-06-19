using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PrecMaths.Numbers;

namespace PrecMaths
{
    public static class PowerEvaluation
    {
        public static Rational EvaluateRationalPower(Rational a, Rational power,int precision)
        {
            if (a < 0)
            {
                throw new NotImplementedException("exponentation of negative numbers not yet supported");
            }
            SignedBigInteger normalexponentiations = power.Numerator / power.Denominator;
            SignedBigInteger funkyexponentiation = power.Numerator % power.Denominator;
            Rational result;
            if (normalexponentiations > 0)
            {
                result = a.Clone();
                for (int i = 1; i < normalexponentiations; i++)
                {
                    result *= a;
                }
            }
            else
            {
                result = 1;
            }
            Rational upperbound;
            if (a > 1)
            {
                upperbound = a.Clone();
            }
            else
            {
                upperbound = new Rational(a.Denominator, a.Numerator);
            }
            SignedBigInteger flippedtarget = power.Denominator;
            Rational lowerbound = 0;
            Rational target = upperbound.Clone();
            for (long i = 0; i < precision * 5; i++)
            {
                Rational error = (upperbound - lowerbound) / 2;
                Rational guess = lowerbound + error;
                Rational bound = guess.Clone();
                for (int j = 1; j < flippedtarget; j++)
                {
                    guess *= bound;
                }
                if (guess > target)
                {
                    upperbound = bound;
                }
                if (guess < target)
                {
                    lowerbound = bound;
                }

            }
            for (int i = 0; i < funkyexponentiation; i++)
            {
                result *= lowerbound;
            }
            return result;
           

        }
    }
}
