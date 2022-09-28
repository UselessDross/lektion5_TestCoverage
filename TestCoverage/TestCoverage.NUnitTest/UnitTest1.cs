using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TestCoverage.NUnitTest
{
    public class UnitTest1
    {
        Calculator uut;

        private const double _precision = 1e-4;

        [SetUp]
        public void Setup()
        {
            uut = new Calculator();
        }

        [Test]
        public void Accumalator_InitialValue()
        {
            Assert.That(uut.Accumulator, Is.EqualTo(0));
        }

        [Test]
        public void Clear_AccumulatorCorrect()
        {
            uut.Add(1, 1);
            uut.Clear();

            Assert.That(uut.Accumulator, Is.EqualTo(0));
        }
        [Test]
        public void ClearTwice_AccumulatorCorrect()
        {
            uut.Add(1, 1);
            uut.Clear();
            uut.Clear();

            Assert.That(uut.Accumulator, Is.EqualTo(0));
        }
        [Test]
        public void ClearFirst_AccumulatorCorrect()
        {
            uut.Clear();

            Assert.That(uut.Accumulator, Is.EqualTo(0));
        }

       

        [TestCase(1, 2, 3)]
        [TestCase(3, 3, 6)]
        [TestCase(9, 1, 10)]
        public void Add_ResultCorrect(double a, double b, double result)
        {
            Assert.That(uut.Add(a, b), Is.EqualTo(result));
        }

        [TestCase(1, 2, 3)]
        [TestCase(3, 3, 6)]
        [TestCase(9, 1, 10)]
        public void Add_AccumulatorCorrect(double a, double b, double result)
        {
            uut.Add(b, a);

            Assert.That(uut.Accumulator, Is.EqualTo(result));
        }

        [TestCase(1, 1, 1, 3)]
        [TestCase(1, 1, 2, 4)]
        [TestCase(1, 1, 3, 5)]
        public void AddWithAccumulator(double a, double b, double c, double result)
        {
            uut.Add(a, b);

            Assert.That(uut.Add(c), Is.EqualTo(result));
            Assert.That(uut.Accumulator, Is.EqualTo(result));
        }

        [TestCase(9, 6, 3)]
        [TestCase(10, 3, 7)]
        [TestCase(9, 1, 8)]
        public void Subtract_ResultCorrect(double a, double b, double result)
        {
            Assert.That(uut.Subtract(a, b), Is.EqualTo(result));
        }
        [TestCase(9, 6, 3)]
        [TestCase(10, 3, 7)]
        [TestCase(9, 1, 8)]
        public void Subtract_AccumulatorCorrect(double a, double b, double result)
        {
            uut.Subtract(a, b);

            Assert.That(uut.Accumulator, Is.EqualTo(result));
        }
        [TestCase(8, 1, 1, 6)]
        [TestCase(10, 1, 2, 7)]
        [TestCase(3, 1, 2, 0)]
        public void SubtractWithAccumulator(double a, double b, double c, double result)
        {
            uut.Subtract(a, b);

            Assert.That(uut.Subtract(c), Is.EqualTo(result));
            Assert.That(uut.Accumulator, Is.EqualTo(result));
        }

        [TestCase(9, 5.5f, 49.5)]
        [TestCase(9, 0, 0)]
        [TestCase(6, -3, -18)]
        public void Multiply_ResultCorrect(double a, double b, double result)
        {
            Assert.That(uut.Multiply(a, b), Is.EqualTo(result).Within(_precision));
        }
        [TestCase(9, 5.5f, 49.5)]
        [TestCase(9, 0, 0)]
        [TestCase(6, -3, -18)]
        public void Multiply_AccumulatorCorrect(double a, double b, double result)
        {
            uut.Multiply(a, b);

            Assert.That(uut.Accumulator, Is.EqualTo(result).Within(_precision));
        }
        [TestCase(9, 5.5f, 2, 99)]
        [TestCase(9, 0, 2, 0)]
        [TestCase(6, -3, 4, -72)]
        public void MultiplyWithAccumulator(double a, double b, double c, double result)
        {
            uut.Multiply(a, b);

            Assert.That(uut.Multiply(c), Is.EqualTo(result).Within(_precision));
            Assert.That(uut.Accumulator, Is.EqualTo(result).Within(_precision));
        }

        [TestCase(9, 5, 59049)]
        [TestCase(2, -2, 0.25)]
        [TestCase(2, 0, 1)]
        [TestCase(10.3f, 2, 106.09)]
        public void Power_ResultCorrect(double a, double b, double result)
        {
            Assert.That(uut.Power(a, b), Is.EqualTo(result).Within(_precision));
        }
        [TestCase(9, 5, 59049)]
        [TestCase(2, -2, 0.25)]
        [TestCase(2, 0, 1)]
        [TestCase(10.3f, 2, 106.09)]
        public void Power_AccumulatorCorrect(double a, double b, double result)
        {
            uut.Power(a, b);

            Assert.That(uut.Accumulator, Is.EqualTo(result).Within(_precision));
        }
        [TestCase(2, 4, 3, 4096)]
        [TestCase(2, -2, 2, 0.0625)]
        [TestCase(1e+1, 2, 3, 1e+6)]
        public void PowerWithAccumulator(double a, double b, double c, double result)
        {
            uut.Power(a, b);

            Assert.That(uut.Power(c), Is.EqualTo(result).Within(_precision));
            Assert.That(uut.Accumulator, Is.EqualTo(result).Within(_precision));
        }

        [TestCase(20, 10, 2)]
        [TestCase(18, 9, 2)]
        [TestCase(20, 5, 4)]
        public void Divier_ResultCorrect(double a, double b, double result)
        {
            Assert.That(uut.Divide(a,b), Is.EqualTo(result));
        }


    }
}