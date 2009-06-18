using System;
using System.Collections.Generic;
using System.Text;
using Mono.Math;

namespace PrecMaths
{
    public class SignedBigInteger
    {
        public bool Negative;
        public BigInteger Number;
        public SignedBigInteger(int a)
        {
            if (a < 0)
            {
                this.Negative = true;
                a *= -1;
            }
            this.Number = new BigInteger(a);
        }
        public SignedBigInteger(long a)
        {
            if (a < 0)
            {
                this.Negative = true;
                a *= -1;
            }
            this.Number = new BigInteger((ulong)a);
        }
        public SignedBigInteger(BigInteger a)
        {
            this.Negative = false;
            this.Number = new BigInteger(a);
        }
        public SignedBigInteger(BigInteger a, bool neg)
        {
            this.Negative = neg;
            this.Number = new BigInteger(a);
        }
        public SignedBigInteger Clone()
        {
            return new SignedBigInteger(this.Number, this.Negative);
        }
        public static implicit operator SignedBigInteger(int a)
        {
            return new SignedBigInteger(a);
        }
        public static implicit operator SignedBigInteger(long a)
        {
            return new SignedBigInteger(a);
        }
        public static implicit operator SignedBigInteger(BigInteger a)
        {
            return new SignedBigInteger(a);
        }
        public static bool operator ==(SignedBigInteger a, SignedBigInteger b)
        {
            if (a.Number == 0 && b.Number == 0)
            {
                return true;
            }
            else if (a.Negative == b.Negative && b.Number == a.Number)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator !=(SignedBigInteger a, SignedBigInteger b)
        {
            return !(a == b);
        }
        public static bool operator <(SignedBigInteger a, SignedBigInteger b)
        {
            if (a.Number == 0 && b.Number == 0)
            {
                return false;
            }
            else if (!a.Negative && b.Negative)
            {
                return true;
            }
            else if (a.Negative && b.Negative)
            {
                return a.Number > b.Number;
            }
            else
            {
                return a.Number < b.Number;
            }
        }
        public static bool operator >(SignedBigInteger a, SignedBigInteger b)
        {
            if (a.Number == 0 && b.Number == 0)
            {
                return false;
            }
            else if (a.Negative && !b.Negative)
            {
                return true;
            }
            else if (a.Negative && b.Negative)
            {
                return a.Number < b.Number;
            }
            else
            {
                return a.Number > b.Number;
            }
        }
        public static bool operator >=(SignedBigInteger a, SignedBigInteger b)
        {
            if (a == b)
            {
                return true;
            }
            else if (a > b)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator <=(SignedBigInteger a, SignedBigInteger b)
        {
            if (a == b)
            {
                return true;
            }
            else if (a < b)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static SignedBigInteger operator *(SignedBigInteger a, SignedBigInteger b)
        {
            bool neg = a.Negative ^ b.Negative;
            BigInteger number = a.Number * b.Number;
            return new SignedBigInteger(number, neg);
        }
        public static SignedBigInteger operator /(SignedBigInteger a, SignedBigInteger b)
        {
            bool neg = a.Negative ^ b.Negative;
            BigInteger number = a.Number / b.Number;
            return new SignedBigInteger(number, neg);
        }
        public static SignedBigInteger operator +(SignedBigInteger a, SignedBigInteger b)
        {
            BigInteger number;
            bool neg;
            if (a.Negative == b.Negative)
            {
                neg = a.Negative;
                number = a.Number + b.Number;
            }
            else
            {
                if (a.Negative && !b.Negative)
                {
                    if (a.Number > b.Number)
                    {
                        neg = true;
                        number = a.Number - b.Number;
                    }
                    else
                    {
                        neg = false;
                        number = b.Number - a.Number;
                    }
                }
                else if (!a.Negative && b.Negative)
                {
                    if (b.Number > a.Number)
                    {
                        neg = true;
                        number = b.Number - a.Number;
                    }
                    else
                    {
                        neg = false;
                        number = a.Number - b.Number;
                    }
                }
                else
                {
                    throw new ArgumentException();
                }

            }
            return new SignedBigInteger(number, neg);
        }
        public static SignedBigInteger operator %(SignedBigInteger a, SignedBigInteger b)
        {
            if (b <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                if (a >= 0)
                {
                    return new SignedBigInteger(a.Number % b.Number);
                }
                else
                {
                    return b.Number - a.Number % b.Number;
                }
            }
            
        }
        public static SignedBigInteger operator -(SignedBigInteger a, SignedBigInteger b)
        {
            bool negative;
            BigInteger number;

            if (b.Negative)
            {
                SignedBigInteger c = b.Clone();
                c.Negative = false;
                return a + c;
            }
            else if (a.Negative)
            {

                if (a.Number > b.Number)
                {
                    negative = true;
                    number = a.Number - b.Number;
                }
                else
                {
                    negative = false;
                    number = b.Number - a.Number;
                }


            }
            else
            {
                //a is pos and b is pos;
                if (a.Number < b.Number)
                {
                    negative = true;
                    number = b.Number - a.Number;
                }
                else
                {
                    negative = false;
                    number = a.Number - b.Number;
                }
            }
            return new SignedBigInteger(number, negative);
            
        }
        public override bool Equals(object obj)
        {
            if (obj.GetType() == this.GetType())
            {
                return (SignedBigInteger)obj == this;
            }
            else if (obj.GetType() == 1.GetType())
            {
                return (int)obj == this;
            }
            else
            {
                return false;
            }
        }
        public override int GetHashCode()
        {
            return this.Number.GetBytes()[0];
        }
        
    }
}
