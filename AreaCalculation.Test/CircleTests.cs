using System;
using Xunit;
using static System.Math;

namespace Troshkin.AreaCalculation.Test
{
    public class CircleTests
    {
        [Fact]
        public void CalculateArea_1_314()
        {
            //Arrange
            double r = 1.5;
            var c = new Circle(r);

            //Act
            var area = c.CalculateArea();

            //Assert
            Assert.Equal<double>(Round(PI * Pow(r, 2), 2), area);
        }
        [Fact]
        public void CalculateArea_1_31415()
        {
            //Arrange
            double r = 2.5;
            var c = new Circle(r);

            //Act
            var area = c.CalculateArea(4);

            //Assert
            Assert.Equal<double>(Round(PI * Pow(r, 2), 4), area);
        }
        [Theory]
        [InlineData(0)]
        [InlineData(-50.5)]
        public void CalculateArea_ArgumentException(double r)
        {
            //Assert
            var ex = Assert.Throws<ArgumentException>(() => new Circle(r));
            Assert.Equal("Invalid argument", ex.Message);
        }

        [Fact]
        public void CalculateArea_DoubleMax_OverflowExc()
        {
            //Arrange
            double r = Double.MaxValue;
            var c = new Circle(r);

            //Assert
            Assert.Throws<OverflowException>(() => c.CalculateArea());
        }

        [Theory]
        [InlineData(-1.5)]
        [InlineData(16.5)]
        public void CalculateArea_ArgumentOutOfRangeException(int digits)
        {
            double r = 1;
            var c = new Circle(r);

            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => c.CalculateArea(digits));
        }
    }
}
