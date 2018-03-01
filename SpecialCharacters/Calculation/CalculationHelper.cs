using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpecialCharacters.Models;

namespace SpecialCharacters.Calculation
{
    public class CalculationHelper
    {
        public static int CalculateTimeDifference(int row1, int column1, int row2, int column2)
        {
            return Math.Abs(row1 - row2) + Math.Abs(column1 - column2);
        }

        public static int CalculatePriority(Car car, Ride ride, InputModel input, int t)
        {
            var distance = CalculateTimeDifference(car.Row, car.Column, ride.StartRow,
                ride.StartColumn);
            var timeToStart = ride.EarliestStart - t;

            if (timeToStart >= distance)
            {
                return ride.RideDuration + input.Bonus - timeToStart;
            }
            else
            {
                return ride.RideDuration - distance;
            }
        }
    }
}
