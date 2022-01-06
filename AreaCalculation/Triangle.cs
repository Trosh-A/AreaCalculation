using System;
using static System.Math;
namespace Troshkin.AreaCalculation
{
    public class Triangle : IAreaCalculatable
    {
        private readonly double _a;
        private readonly double _b;
        private readonly double _c;
        /// <summary>
        /// Create the Triangle object
        /// </summary>
        /// <param name="a">Side 1</param>
        /// <param name="b">Side 2</param>
        /// <param name="c">Side 3</param>
        /// <exception cref="ArgumentException">Throw if arguments is invalid</exception>
        public Triangle(double a, double b, double c)
        {
            _a = a;
            _b = b;
            _c = c;
            if (!IsFigureCorrect())
            {
                throw new ArgumentException("Invalid arguments");
            }
        }
        /// <summary>
        /// Calculate area of the triangle
        /// </summary>
        /// <param name="digits">The number of fractional digits in the return value.</param>
        /// <returns>Area</returns>
        public double CalculateArea(int digits = 2)
        {
            var halfP = (_a + _b + _c) / 2;
            var square = Sqrt(halfP * (halfP - _a) * (halfP - _b) * (halfP - _c));
            ThrowOverflowExceptionIfIncorrectDouble(halfP, square);
            return Round(square, digits, MidpointRounding.AwayFromZero);

        }
        /// <summary>
        /// Check if the triangle is rectangular
        /// </summary>
        /// <returns>True, if the triangle is rectangular. Otherwise false.</returns>
        public bool IsRectangular()
        {
            var kathetVariant1 = SumSquaredKathets(_a, _b);
            var hypotenuseVariant1 = SquaredHypotenuse(_c);
            if (kathetVariant1 - hypotenuseVariant1 <= Double.Epsilon) return true;

            var kathetVariant2 = SumSquaredKathets(_a, _c);
            var hypotenuseVariant2 = SquaredHypotenuse(_b);
            if (kathetVariant2 - hypotenuseVariant2 <= Double.Epsilon) return true;

            var kathetVariant3 = SumSquaredKathets(_c, _b);
            var hypotenuseVariant3 = SquaredHypotenuse(_a);
            if (kathetVariant3 - hypotenuseVariant3 <= Double.Epsilon) return true;

            return false;
        }
        public bool IsFigureCorrect()
        {
            if (_a <= 0 + Double.Epsilon || _b <= 0 + Double.Epsilon || _c <= 0 + Double.Epsilon) return false;
            ThrowOverflowExceptionIfIncorrectDouble(_a, _b, _c);

            var sum1 = _a + _b;
            var sum2 = _a + _c;
            var sum3 = _b + _c;
            ThrowOverflowExceptionIfIncorrectDouble(sum1, sum2, sum3);
            if (sum1 < _c - Double.Epsilon ||
                sum2 < _b - Double.Epsilon ||
                sum3 < _a - Double.Epsilon)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// Sum kathets squares with overflow check
        /// </summary>
        /// <param name="k1">Kathet 1</param>
        /// <param name="k2">Kathet 2</param>
        /// <returns>Sum of kathets squares</returns>
        private double SumSquaredKathets(double k1, double k2)
        {
            var sumSquared = Pow(k1, 2) + Pow(k2, 2);
            ThrowOverflowExceptionIfIncorrectDouble(sumSquared);
            return sumSquared;
        }
        /// <summary>
        /// Square the hypotenuse with overflow check
        /// </summary>
        /// <param name="h1">Hypotenuse</param>
        /// <returns>Square of the hypotenuse</returns>
        private double SquaredHypotenuse(double h1)
        {
            var squared = Pow(h1, 2);
            ThrowOverflowExceptionIfIncorrectDouble(squared);
            return squared;
        }
        /// <summary>
        /// Service method for checking overflow the double range
        /// </summary>
        /// <param name="values">double values, you want to check</param>
        /// <exception cref="OverflowException">throw if at least one value is not valid for task</exception>
        private void ThrowOverflowExceptionIfIncorrectDouble(params double[] values)
        {
            foreach (var value in values)
            {
                if (Double.IsPositiveInfinity(value) ||
                Double.IsNegativeInfinity(value) ||
                Double.IsNaN(value))
                {
                    throw new OverflowException();
                }
            }
        }
    }
}
