using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Tests
{
    [TestClass()]
    public class PolynomialTests
    {
        [TestMethod()]
        public void ToStringTests()
        {
            Polynomial p = new Polynomial(new double[] { 0, 0, -1.0d });
            string str = p.ToString();
            string expected = "-x^2";
            Assert.AreEqual(expected, str);
        }

        [TestMethod()]
        public void EqualsTest_ArgumentIsNull_Returns_False()
        {
            Polynomial p = new Polynomial(1,2,3);
           
            Assert.IsFalse(p.Equals(null));
        }

        [TestMethod()]
        public void EqualsTest_ArgumentAreEqualAndUpcastedToObject_Returns_True()
        {
            Polynomial p = new Polynomial(1, 2, 3);
            object o = new Polynomial(1, 2, 3);

            Assert.IsTrue(p.Equals(o));
        }

        [TestMethod()]
        public void GetHashCodeTests_SamePolynomials_Returns_SameHashCodes()
        {
            Polynomial p1 = new Polynomial(new double[] { 1.0d, 1.0d, 1.0d });
            Polynomial p2 = new Polynomial(new double[] { 1.0d, 1.0d, 1.0d });

            Assert.IsTrue(p1.GetHashCode() == p2.GetHashCode());
        }

        [TestMethod()]
        public void GetHashCodeTests_DifferentPolynomials_Returns_DifferentHashCodes()
        {
            Polynomial p1 = new Polynomial(new double[] { -1.0d, 0, 1.0d });
            Polynomial p2 = new Polynomial(new double[] { 5.0d, 0, 1.0d, 5.0d });

            Assert.IsFalse(p1.GetHashCode() == p2.GetHashCode());
        }

        [TestMethod()]
        public void AddOperatorTests()
        {
            Polynomial left = new Polynomial(new double[] { 6, 7, 2, 4, 3 });
            Polynomial right = new Polynomial(new double[] { -6, -7, -2, -4, -3 });
            Polynomial result = left + right;

            double[] expected = new double[] { 0 };

            for (int i = 0; i <= result.Degree; i++)
            {
                Assert.AreEqual(expected[i],result[i]);
            }
        }

        [TestMethod()]
        public void SubtractOperatorTests()
        {
            Polynomial left = new Polynomial(new double[] { 5, 13, 1, -7.3, -3, 4 });
            Polynomial right = new Polynomial(new double[] { -5, 2, 3, 7.3 });
            Polynomial result = left - right;

            double[] expected = new double[] { 10, 11, -2, -14.6, -3, 4 };

            for (int i = 0; i <= result.Degree; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
        }

        [TestMethod()]
        public void MultiplyOperatorTests()
        {
            Polynomial left = new Polynomial(new double[] { 5.0d, 2.0d, 8.0d });
            Polynomial right = new Polynomial(new double[] { -7.0d, -4.0d });
            Polynomial result = left * right;

            double[] expected = new double[] { -35.0d, -34.0d, -64.0d, -32.0d };

            for (int i = 0; i <= result.Degree; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
        }

        [TestMethod()]
        public void EqualsOperatorTest_BothOperandsIsNull_Return_True()
        {
            Polynomial left = null;
            Polynomial right = null;

            Assert.IsTrue(left == right);
        }

        [TestMethod()]
        public void EqualsOperatorTest_LeftOperandsIsNull_Return_False()
        {
            Polynomial left = null;
            Polynomial right = new Polynomial(1);

            Assert.IsFalse(left == right);
        }

        [TestMethod()]
        public void NotEqualsOperatorTests()
        {
            Polynomial p1 = new Polynomial(-1, -2, -3, -4, -5);
            Polynomial p2 = new Polynomial(-1, -2, -3, -4, -5);

            Assert.IsFalse(p1 != p2);
        }
    }
}