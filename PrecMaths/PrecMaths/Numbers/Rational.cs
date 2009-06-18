/*
 * Copyright Sam Phippen 2009
 */
 
using System;
using System.Collections.Generic;
using System.Text;
using Mono.Math;

namespace PrecMaths.Numbers
{
    /// <summary>
    /// This defines a class that represents rational numbers
    /// </summary>
    public class Rational
    {
        /// <summary>
        /// this represents the numerator of the number
        /// </summary>
        public SignedBigInteger Numerator;
        /// <summary>
        /// this represents the denominator of the number
        /// </summary>
        public SignedBigInteger Denominator;
        /// <summary>
        /// this initialises the rational number
        /// </summary>
        /// <param name="Numerator">the numerator of the number</param>
        /// <param name="Denominator">the denominator of the number, cannot be zero</param>
        public Rational(SignedBigInteger Numerator, SignedBigInteger Denominator)
        {
            this.Numerator = Numerator.Clone();
            this.Denominator = Denominator.Clone();
            if (this.Denominator == 0)
            {
                throw new ArgumentOutOfRangeException("denominators of rationals cannot be zero");
            }
        }
        /// <summary>
        /// this initialises the rational number, with a denominator of one
        /// </summary>
        /// <param name="Numerator">The numerator</param>
        public Rational(SignedBigInteger Numerator)
        {
            this.Numerator = Numerator.Clone();
            this.Denominator = 1;
        }
        public Rational Clone()
        {
            return new Rational(this.Numerator, this.Denominator);
        }
        
        /// <summary>
        /// evaluates the rational as a double
        /// </summary>
        /// <returns>a double approximation of the rational</returns>
        public double EvaluateDouble()
        {
            if ((Numerator / Denominator).Number > new BigInteger(ulong.MaxValue))
            {
                throw new InvalidOperationException("evaluation cannot be done on huge values");
            }
            else
            {
                this.Reduce();
                bool negative = Numerator.Negative;
                BigInteger p1 = Numerator.Number;
                BigInteger p2 = Denominator.Number;
                byte[] beforepoint = (p1 / p2).GetBytes();
                double result = 0;
                for (int i = 0; i < beforepoint.Length; i++)
                {
                    result += beforepoint[i] << (8 * i);
                }
                BigInteger remainder = p1 % p2;
                int shifts = 0;
                for (int i = 0; i < 24; i++)
                {
                    remainder *= 10;
                    shifts += 1;
                    byte[] some_more_juice = (remainder/p2).GetBytes();
                    for (int j = 0; j < some_more_juice.Length; j++)
                    {
                        result += (double)some_more_juice[j] / (double)(Math.Pow(10,shifts));
                    }
                    remainder = remainder % p2;
                }
                if (negative)
                {
                    return -1 * result;
                }
                else
                {
                    return result;
                }
            }

        }

        public string EvaluateString(int precision)
        {
        
            this.Reduce();
            bool negative = Numerator.Negative;
            BigInteger p1 = Numerator.Number;
            BigInteger p2 = Denominator.Number;
            byte[] beforepoint = (p1 / p2).GetBytes();
            string result = "";
            int build = 0;
            for (int i = 0; i < beforepoint.Length; i++)
            {
                build += beforepoint[i] << (8 * i);
            }
            result += build.ToString() + ".";
            BigInteger remainder = p1 % p2;
            int shifts = 0;
            for (int i = 0; i < precision+1; i++)
            {
                remainder *= 10;
                shifts += 1;
                byte[] some_more_juice = (remainder / p2).GetBytes();
                for (int j = 0; j < some_more_juice.Length; j++)
                {
                    result += some_more_juice[j];
                }
                remainder = remainder % p2;
            }
            char[] win = result.ToCharArray();
            if (int.Parse(result[result.Length - 1].ToString()) >= 5 && result.Length > 3)
            {
                int b = int.Parse(result[result.Length - 2].ToString());
                b += 1;
                win[win.Length - 2] = (char)(b+48);
                
                
            }
            result = "";
            for (int i = 0; i < win.Length - 1; i++)
            {
                result += win[i];
            }
            if (negative)
            {
                return "-" + result;
            }
            else
            {
                return result;
            }
        
        }
        /// <summary>
        /// evaluates the rational to a decimal
        /// </summary>
        /// <returns>a decimal approximation of the number</returns>
        public Decimal EvaluateDecimal()
        {
            if ((Numerator / Denominator).Number > new BigInteger(ulong.MaxValue))
            {
                throw new InvalidOperationException("evaluation cannot be done on huge values");
            }
            else
            {
                this.Reduce();
                bool negative = Numerator.Negative;
                BigInteger p1 = Numerator.Number;
                BigInteger p2 = Denominator.Number;
                byte[] beforepoint = (p1 / p2).GetBytes();
                decimal result = 0;
                for (int i = 0; i < beforepoint.Length; i++)
                {
                    result += beforepoint[i] << (8 * i);
                }
                BigInteger remainder = p1 % p2;
                int shifts = 0;
                for (int i = 0; i < 20; i++)
                {
                    remainder *= 10;
                    shifts += 1;
                    byte[] some_more_juice = (remainder/p2).GetBytes();
                    for (int j = 0; j < some_more_juice.Length; j++)
                    {
                        result += (decimal)some_more_juice[j] / (decimal)(Math.Pow(10,shifts));
                    }
                    remainder = remainder % p2;
                }
                if (negative)
                {
                    return -1 * result;
                }
                else
                {
                    return result;
                }
            }

        }
        /// <summary>
        /// this reduces the rational number such that gcd(Numerator,Denominator) == 1
        /// </summary>
        public Rational Reduce()
        {
            SignedBigInteger a = this.Numerator;
            SignedBigInteger b = this.Denominator;
            while (b != 0)
            {
                SignedBigInteger t = b;
                b = a % b;
                a = t;
            }
            this.Numerator /= a;
            this.Denominator /= a;
            if (this.Denominator.Negative)
            {
                this.Numerator *= -1;
                this.Denominator *= -1;
            }
            return this;
        }
        public static Rational operator *(Rational a, Rational b)
        {
            Rational r = new Rational(a.Numerator * b.Numerator, b.Denominator * a.Denominator);
            r.Reduce();
            return r;
        }
        public static Rational operator /(Rational a, Rational b)
        {
            Rational r = new Rational(a.Numerator * b.Denominator, a.Denominator * b.Numerator);
            r.Reduce();
            return r;
        }
        public static Rational operator +(Rational a, Rational b)
        {
            SignedBigInteger commonbase = a.Denominator * b.Denominator;
            SignedBigInteger atop = a.Numerator * b.Denominator;
            SignedBigInteger btop = b.Numerator * a.Denominator;
            Rational r = new Rational(atop + btop, commonbase);
            r.Reduce();
            return r;
        }
        public static Rational operator -(Rational a, Rational b)
        {
            SignedBigInteger commonbase = a.Denominator * b.Denominator;
            SignedBigInteger atop = a.Numerator * b.Denominator;
            SignedBigInteger btop = b.Numerator * a.Denominator;
            Rational r = new Rational(atop - btop, commonbase);
            r.Reduce();
            return r;
        }
        public static bool operator ==(Rational a, Rational b)
        {
            SignedBigInteger lhs = a.Numerator * b.Denominator;
            SignedBigInteger rhs = b.Numerator * a.Denominator;
            return lhs == rhs;
        }
        public static bool operator !=(Rational a, Rational b)
        {
            return !(a == b);
        }
        public static bool operator <(Rational a, Rational b)
        {
            SignedBigInteger lhs = a.Numerator * b.Denominator;
            SignedBigInteger rhs = b.Numerator * a.Denominator;
            return lhs < rhs;
        }
        public static bool operator >(Rational a, Rational b)
        {
            SignedBigInteger lhs = a.Numerator * b.Denominator;
            SignedBigInteger rhs = b.Numerator * a.Denominator;
            return lhs > rhs;
        }
        public static bool operator >=(Rational a, Rational b)
        {
            SignedBigInteger lhs = a.Numerator * b.Denominator;
            SignedBigInteger rhs = b.Numerator * a.Denominator;
            return lhs >= rhs;
        }
        public static bool operator <=(Rational a, Rational b)
        {
            SignedBigInteger lhs = a.Numerator * b.Denominator;
            SignedBigInteger rhs = b.Numerator * a.Denominator;
            return lhs <= rhs;
        }
        public override bool Equals(object obj)
        {
            if (obj.GetType() == this.GetType())
            {
                return (Rational)obj == this;
            }
            if (obj.GetType() == 1.GetType())
            {
                return (int)obj == this;
            }
            if (obj.GetType() == 1L.GetType())
            {
                return (long)obj == this;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return Numerator.Number.GetBytes()[0];
        }
        public static implicit operator Rational(int a)
        {
            return new Rational(a);
        }
        public static implicit operator Rational(long a)
        {
            return new Rational(a);
        }
    }
}
