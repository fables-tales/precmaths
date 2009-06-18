using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using PrecMaths;
using PrecMaths.Numbers;
using Mono.Math;


namespace PrecMathsTests
{
    [TestFixture]
    public class PrecSignedBigIntegerTests
    {
        [Test]
        public void InitialiseTest()
        {
            SignedBigInteger a = new SignedBigInteger(-3);
            Assert.AreEqual(true, a.Negative);
            Assert.AreEqual(new BigInteger(3), a.Number);
            a = new SignedBigInteger(324812348123433218);
            Assert.AreEqual(new BigInteger(324812348123433218), a.Number);
            Assert.AreEqual(false, a.Negative);
            a = new SignedBigInteger(new BigInteger(213412341324), true);
            Assert.AreEqual(true, a.Negative);
            Assert.AreEqual(new BigInteger(213412341324), a.Number);
        }
        [Test]
        public void MultiplyTest()
        {
            SignedBigInteger a, b, c;
            a = new SignedBigInteger(3);
            b = new SignedBigInteger(-3);
            c = a * b;
            Assert.AreEqual(true,c.Negative);
            Assert.AreEqual(new BigInteger(9), c.Number);
            //test for commutativity in multiplication
            Assert.AreEqual(c, b * a);
            a = new SignedBigInteger(-3);
            b = new SignedBigInteger(-7);
            c = a * b;
            Assert.AreEqual(false, c.Negative);
            Assert.AreEqual(new BigInteger(21), c.Number);
            Assert.AreEqual(c, b * a);
            a = new SignedBigInteger(-1329048120948);
            b = new SignedBigInteger(471723838228);
            c = a * b;
            Assert.AreEqual(true, c.Negative);
            Assert.AreEqual(new BigInteger(471723838228) * new BigInteger(1329048120948), c.Number);
            Assert.AreEqual(c, b * a);
        }
        [Test]
        public void AddTest()
        {
            SignedBigInteger a, b, c;
            a = new SignedBigInteger(-3);
            b = new SignedBigInteger(6);
            c = a + b;
            Assert.AreEqual(false, c.Negative);
            Assert.AreEqual(new BigInteger(3), c.Number);
            //test for commutativity in addition
            Assert.AreEqual(c, b + a);
            a = new SignedBigInteger(-21);
            b = new SignedBigInteger(7);
            c = a + b;
            Assert.AreEqual(true, c.Negative);
            Assert.AreEqual(new BigInteger(14), c.Number);
            Assert.AreEqual(c, b + a);
            a = new SignedBigInteger(-1239480123908);
            b = new SignedBigInteger(-1238485585748);
            c = a + b;
            Assert.AreEqual(true, c.Negative);
            Assert.AreEqual(new BigInteger(2477965709656), c.Number);
            Assert.AreEqual(c, b + a);
        }
        [Test]
        public void SubtractTest()
        {
            SignedBigInteger a, b, c;
            a = new SignedBigInteger(145);
            b = new SignedBigInteger(13);
            c = a - b;
            Assert.AreEqual(false, c.Negative);
            Assert.AreEqual(new BigInteger(132), c.Number);
            Assert.AreNotEqual(c, b - a);
            a = new SignedBigInteger(-12);
            b = new SignedBigInteger(13);
            c = a - b;
            Assert.AreEqual(true, c.Negative);
            Assert.AreEqual(new BigInteger(25), c.Number);
            b = new SignedBigInteger(13);
            a = new SignedBigInteger(1);
            c = a - b;
            Assert.AreEqual(true, c.Negative);
            Assert.AreEqual(new BigInteger(12), c.Number);
            a = new SignedBigInteger(-13);
            b = new SignedBigInteger(-16);
            c = a - b;
            Assert.AreEqual(false, c.Negative);
            Assert.AreEqual(new BigInteger(3), c.Number);
            

        }
        [Test]
        public void DivModTest()
        {
            SignedBigInteger a, b, c, d;
            a = new SignedBigInteger(8);
            b = new SignedBigInteger(3);
            c = a / b;
            d = a % b;
            Assert.AreEqual(false, c.Negative);
            Assert.AreEqual(new BigInteger(2), c.Number);
            Assert.AreEqual(false, d.Negative);
            
            Assert.AreEqual(new BigInteger(2), d.Number);
            a = new SignedBigInteger(-22);
            b = new SignedBigInteger(7);
            c = a / b;
            d = a % b;
            Assert.AreEqual(true, c.Negative);
            Assert.AreEqual(new BigInteger(3), c.Number);
            Assert.AreEqual(new BigInteger(1), d.Number);
            Assert.AreEqual(false, d.Negative);
            a = new SignedBigInteger(-8);
            b = new SignedBigInteger(-3);
            c = a / b;
            Assert.AreEqual(false, c.Negative);
            Assert.AreEqual(new BigInteger(2), c.Number);
            
            
        }
        [Test]
        public void AssignTest()
        {
            SignedBigInteger a, b, c, d;
            a = -3;
            b = new BigInteger(12341234);
            c = 12341513241234;
            d = new BigInteger(123123823);
            d *= -1;
            Assert.AreEqual(true, a.Negative);
            Assert.AreEqual(new BigInteger(3), a.Number);
            Assert.AreEqual(new BigInteger(12341234), b.Number);
            Assert.AreEqual(false, b.Negative);
            Assert.AreEqual(new BigInteger(12341513241234), c.Number);
            Assert.AreEqual(false, c.Negative);
            Assert.AreEqual(true, d.Negative);
            Assert.AreEqual(new BigInteger(123123823), d.Number);
        }
    }
    [TestFixture]
    public class RationalTests{
        [Test]
        public void InitialiseTest()
        {
            Rational r = new Rational(12);
            Assert.That(12 == r);
            r = new Rational(-12);
            Assert.That(-12 == r);
            r = new Rational(120L);
            Assert.That(120 == r);
        }
        [Test]
        public void MultiplyTest()
        {
            Rational r = new Rational(2);
            r = r * 4;
            Assert.That(8 == r);
            r *= -1;
            Assert.That(-8 == r);
            r = new Rational(1, 4);
            r = r * 6;
            Assert.AreEqual(new Rational(3, 2), r);
        }
        [Test]
        public void DivideTest()
        {
            Rational r = new Rational(1, 2);
            r /= 2;
            Assert.AreEqual(new Rational(1, 4), r);
            r = new Rational(-1, 2);
            r /= 2;
            Assert.AreEqual(new Rational(-1, 4), r);
        }
        [Test]
        public void AddTest()
        {
            Rational r = new Rational(1, 3);
            r += new Rational(1, 4);
            Assert.AreEqual(new Rational(7, 12), r);
            r += new Rational(-3, 4);
            Assert.AreEqual(new Rational(-2, 12), r);
        }
        [Test]
        public void SubtractTest()
        {
            Rational r = new Rational(1, 3);
            r -= new Rational(5, 6);
            Assert.AreEqual(new Rational(-1, 2), r);
            r -= new Rational(-4, 6);
            Assert.AreEqual(new Rational(1, 6), r);
        }
        [Test]
        public void ReduceTest()
        {
            Rational r = new Rational(-1, -6);
            r.Reduce();
            Assert.AreEqual(r.Numerator.Negative, false);
            Assert.AreEqual(r.Denominator.Negative, false);
            Assert.AreEqual(new BigInteger(1), r.Numerator.Number);
            Assert.AreEqual(new BigInteger(6), r.Denominator.Number);
            r = new Rational(3, 6);
            r.Reduce();
            Assert.AreEqual(r.Numerator.Negative, false);
            Assert.AreEqual(r.Denominator.Negative, false);
            Assert.AreEqual(new BigInteger(1), r.Numerator.Number);
            Assert.AreEqual(new BigInteger(2), r.Denominator.Number);
            r = new Rational(1, -6);
            r.Reduce();
            Assert.AreEqual(r.Numerator.Negative, true);
            Assert.AreEqual(r.Denominator.Negative, false);
            Assert.AreEqual(new BigInteger(1), r.Numerator.Number);
            Assert.AreEqual(new BigInteger(6), r.Denominator.Number);
        }
        [Test]
        public void EvaluateTest()
        {
            Rational e = new Rational(1, 2);
            Assert.AreEqual(0.5, e.EvaluateDecimal());
            e = new Rational(1, 3);
            Assert.AreEqual(Math.Round(1.0 / 3.0, 15), Math.Round(e.EvaluateDecimal(), 15));
            e = new Rational(3, 2);
            Assert.AreEqual(1.5, e.EvaluateDecimal());
            e = new Rational(-3, 2);
            Assert.AreEqual(-1.5, e.EvaluateDecimal());

            Assert.AreEqual("0.500", new Rational(1, 2).EvaluateString(3));
            Assert.AreEqual("1.500", new Rational(3, 2).EvaluateString(3));
            Assert.AreEqual("-158.883", new Rational(-158883, 1000).EvaluateString(3));
            Assert.AreEqual(-158.883m, new Rational(-158883, 1000).EvaluateDecimal());

        }
    }
    [TestFixture]
    public class SymbolTests
    {
        [Test]
        public void PiSymbolTest()
        {
            PiSymbol s = new PiSymbol(1);
            Assert.AreEqual("3.1415926536", s.EvaluteString(10));
            
        }
        [Test]
        public void PiSymbolTest2()
        {
            PiSymbol s = new PiSymbol(2);
            Assert.AreEqual("9.86960440108935861883449099987615113531369940724079", s.EvaluteString(50));
        }
        
    }
}
