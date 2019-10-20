using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class Polynomial : ICloneable, IEquatable<Polynomial>
    {
        private readonly double[] coefficients;

        public Polynomial()
        {
            coefficients = new double[] { 0.0d };
        }

        public Polynomial(double c0)
        {
            ThrowArgumentExceptionIfCoefficientIsNaN(c0);

            coefficients = new double[] { c0 };
        }

        public Polynomial(params double[] coefficients)
        {
            ThrowArgumentNullExceptionIfArgumentIsNull(coefficients);
            ThrowArgumentExceptionIfArrayIsEmpty(coefficients);

            int degree = DefineDegree(ref coefficients);

            this.coefficients = new double[degree + 1];

            CreatePolynomial(ref coefficients, ref degree);
        }

        public int Degree => coefficients.Length - 1;

        private int? HashCode { get; set; }

        public double this[int order]
        {
            get
            {
                if (order > coefficients.Length - 1 || order < 0)
                {
                    throw new ArgumentOutOfRangeException($"Order {order} out of range");
                }

                return coefficients[order];
            }

            private set
            {
            }
        }

        public static Polynomial operator +(Polynomial left, Polynomial right)
        {
            ThrowArgumentNullExceptionIfArgumentIsNull(left);
            ThrowArgumentNullExceptionIfArgumentIsNull(right);

            return left.Degree > right.Degree ? Sum(left, right) : Sum(right, left);
        }

        public static Polynomial operator -(Polynomial left, Polynomial right)
        {
            ThrowArgumentNullExceptionIfArgumentIsNull(left);
            ThrowArgumentNullExceptionIfArgumentIsNull(right);

            return left + (right * -1);
        }

        public static Polynomial operator *(Polynomial left, Polynomial right)
        {
            ThrowArgumentNullExceptionIfArgumentIsNull(left);
            ThrowArgumentNullExceptionIfArgumentIsNull(right);

            double[] resultCoefficients = new double[left.Degree + right.Degree + 1];

            for (int i = 0; i <= left.Degree; i++)
            {
                for (int j = 0; j <= right.Degree; j++)
                {
                    resultCoefficients[i + j] += left[i] * right[j];
                }
            }

            return new Polynomial(resultCoefficients);
        }

        public static implicit operator Polynomial(double value) => new Polynomial(value);

        public static bool operator ==(Polynomial left, Polynomial right)
        {
            return left is null ? right is null : left.Equals(right);
        }

        public static bool operator !=(Polynomial left, Polynomial right)
        {
            return !(left == right);
        }

        public object Clone()
        {
            return new Polynomial(coefficients);
        }

        public bool Equals(Polynomial other)
        {
            if (other is null)
            {
                return false;
            }

            if (Degree != other.Degree)
            {
                return false;
            }

            if (GetHashCode() != other.GetHashCode())
            {
                return false;
            }

            for (int i = 0; i <= Degree; i++)
            {
                if (coefficients[i] != other[i] || double.IsInfinity(coefficients[i]))
                {
                    return false;
                }
            }

            return true;
        }

        public override bool Equals(object other)
        {
            if (other is null)
            {
                return false;
            }

            if (GetType() != other.GetType())
            {
                return false;
            }

            return this.Equals(other as Polynomial);
        }

        public override int GetHashCode()
        {
            if (HashCode == null)
            {
                HashCode = 0;

                for (int i = 0; i < coefficients.Length; i++)
                {
                    HashCode += coefficients[i].GetHashCode() ^ (coefficients[i].GetHashCode() << (i % 16));
                }
            }

            return (int)HashCode;
        }

        public override string ToString()
        {
            if (Degree == 0)
            {
                return coefficients[0].ToString(CultureInfo.InvariantCulture);
            }

            string[][] signCoefficientDegree = new string[Degree + 1][];

            for (int i = Degree; i >= 0; i--)
            {
                signCoefficientDegree[i] = new string[3];
                signCoefficientDegree[i][0] = coefficients[i] < 0 ? " - " : " + ";
                signCoefficientDegree[i][1] = Math.Abs(coefficients[i]).ToString(CultureInfo.InvariantCulture);

                if (signCoefficientDegree[i][1] == "1")
                {
                    signCoefficientDegree[i][1] = string.Empty;
                }

                if (signCoefficientDegree[i][1].Contains("E"))
                {
                    signCoefficientDegree[i][1] = $"({signCoefficientDegree[i][1]})";
                }

                signCoefficientDegree[i][2] = $"x^{i}";
            }

            signCoefficientDegree[0][2] = string.Empty;
            signCoefficientDegree[Degree][0] = signCoefficientDegree[Degree][0] == " - " ? "-" : string.Empty;

            if (Degree > 0)
            {
                signCoefficientDegree[1][2] = "x";
            }

            if (signCoefficientDegree[0][1] == string.Empty)
            {
                signCoefficientDegree[0][1] = "1";
            }

            StringBuilder sb = new StringBuilder();

            for (int i = Degree; i >= 0; i--)
            {
                if (signCoefficientDegree[i][1] != "0")
                {
                    sb.Append(signCoefficientDegree[i][0]);
                    sb.Append(signCoefficientDegree[i][1]);
                    sb.Append(signCoefficientDegree[i][2]);
                }
            }

            return sb.ToString();
        }

        private static Polynomial Sum(Polynomial hasGreaterDegree, Polynomial hasLessOrEqualDegree)
        {
            double[] resultCoefficients = new double[hasGreaterDegree.Degree + 1];
            int i = 0;

            while (i <= hasLessOrEqualDegree.Degree)
            {
                resultCoefficients[i] = hasGreaterDegree[i] + hasLessOrEqualDegree[i];
                i++;
            }

            while (i <= hasGreaterDegree.Degree)
            {
                resultCoefficients[i] = hasGreaterDegree[i];
                i++;
            }

            return new Polynomial(resultCoefficients);
        }

        private static void ThrowArgumentNullExceptionIfArgumentIsNull(Polynomial value)
        {
            if (value is null)
            {
                throw new ArgumentNullException(nameof(value));
            }
        }

        private int DefineDegree(ref double[] coefficients)
        {
            int firstNotZero = coefficients.Length - 1;

            while (coefficients[firstNotZero] == 0 && firstNotZero > 0)
            {
                firstNotZero--;
            }

            return firstNotZero;
        }

        private void CreatePolynomial(ref double[] coefficients, ref int degree)
        {
            for (int i = degree; i >= 0; i--)
            {
                ThrowArgumentExceptionIfCoefficientIsNaN(coefficients[i]);
                this.coefficients[i] = coefficients[i];
            }
        }

        private void ThrowArgumentNullExceptionIfArgumentIsNull(object value)
        {
            if (value is null)
            {
                throw new ArgumentNullException(nameof(value));
            }
        }

        private void ThrowArgumentExceptionIfArrayIsEmpty(double[] array)
        {
            if (array.Length < 1)
            {
                throw new ArgumentException("Array is empty", nameof(array));
            }
        }

        private void ThrowArgumentExceptionIfCoefficientIsNaN(double value)
        {
            if (double.IsNaN(value))
            {
                throw new ArgumentException("Coefficients in polinomial cannot be NaN");
            }
        }
    }
}
