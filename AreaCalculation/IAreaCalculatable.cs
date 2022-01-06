using System;

namespace Troshkin.AreaCalculation
{
    /// <summary>
    /// Basic interface for area calculation
    /// </summary>
    public interface IAreaCalculatable
    {
        bool IsFigureCorrect();
        double CalculateArea(int decimals = 2);
    }
}
