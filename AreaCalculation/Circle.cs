using System;
using System.Collections.Generic;
using System.Text;
using static System.Math;

namespace Troshkin.AreaCalculation
{
    public class Circle : IAreaCalculatable
    {
        private readonly double _r;

        /// <summary>
        /// Create the Circle object
        /// </summary>
        /// <param name="r">Radius</param>
        /// <exception cref="ArgumentException">Throw if radius is less or equals 0</exception>
        public Circle(double r)
        {
            _r = r;
            if (!IsFigureCorrect())
            {
                throw new ArgumentException("Invalid argument");
            }
        }
        /// <summary>
        /// Calculate area of the circle
        /// </summary>
        /// <param name="digits">The number of fractional digits in the return value.</param>
        /// <returns>Area</returns>
        /// <exception cref="OverflowException">Result is out of Double</exception>
        public double CalculateArea(int digits = 2)
        {
            var square = PI * Pow(_r, 2);
            if (Double.IsPositiveInfinity(square))
            {
                throw new OverflowException();
            }
            return Round(square, digits, MidpointRounding.AwayFromZero);

        }
        public bool IsFigureCorrect() =>
                !Double.IsPositiveInfinity(_r) &&
                !Double.IsNegativeInfinity(_r) &&
                !Double.IsNaN(_r) &&
                _r > 0 + Double.Epsilon;
    }
}
