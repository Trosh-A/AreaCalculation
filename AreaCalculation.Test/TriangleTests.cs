using System;
using Xunit;
using static System.Math;

namespace Troshkin.AreaCalculation.Test
{
    public class TriangleTests
    {
        [Fact]
        public void CalculateArea_rightValues_555()
        {
            //Arrange
            var t = new Triangle(2.5, 4.5, 5.5);

            //Act
            var area = t.CalculateArea();

            //Assert
            Assert.Equal<double>(5.55, area);
        }

        [Fact]
        public void CalculateArea_rightValues_5463()
        {
            //Arrange
            var t = new Triangle(2.5, 4.5, 5.5);

            //Act
            var area = t.CalculateArea(4);

            //Assert
            Assert.Equal<double>(5.5463, area);
        }

        [Fact]
        public void IsRectangular_rightValues_true()
        {
            //Arrange
            var t = new Triangle(3, 4, 5);

            //Act
            var isRectangular = t.IsRectangular();

            //Assert
            Assert.True(isRectangular);
        }

        [Fact]
        public void IsRectangular_rightValues_false()
        {
            //Arrange
            var t = new Triangle(3, 4, 4);

            //Act
            var isRectangular = t.IsRectangular();

            //Assert
            Assert.False(isRectangular);
        }

        [Theory]
        [InlineData(0, 1.5, 2.5)]
        [InlineData(2, 0, 3.5)]
        [InlineData(5, 4.5, 0)]
        [InlineData(2.5, 0, 3)]
        [InlineData(2, Double.NegativeInfinity, 3.5)]
        [InlineData(Double.MinValue, Double.MinValue, Double.MinValue)]
        public void CalculateArea_ArgumentException(double a, double b, double c)
        {
            //Assert
            var ex = Assert.Throws<ArgumentException>(() => new Triangle(a, b, c));
            Assert.Equal("Invalid arguments", ex.Message);
        }

        [Theory]
        [InlineData(Double.PositiveInfinity, 1.5, 2.5)]
        [InlineData(5, 4.5, Double.NaN)]
        [InlineData(Double.MaxValue, Double.MaxValue - 1, Double.MaxValue - 1)]
        public void CalculateArea_OverflowException(double a, double b, double c)
        {
            //Assert
            var ex = Assert.Throws<OverflowException>(() => new Triangle(a, b, c));
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(16)]
        public void CalculateArea_ArgumentOutOfRangeException(int digits)
        {
            var c = new Triangle(2, 4, 5);

            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => c.CalculateArea(digits));
        }
    }
}