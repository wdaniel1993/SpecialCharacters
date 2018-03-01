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

        public static double CalculateCentroidDifference(int row, int column, double centroidRow, double centroidColumn)
        {
            return Math.Abs(row - centroidRow) + Math.Abs(column - centroidColumn);
        }

        public static double CalculatePriority(Car car, Ride ride, InputModel input, int t, double centroidRow, double centroidColumn)
        {
            var distance = CalculateTimeDifference(car.Row, car.Column, ride.StartRow,
                ride.StartColumn);
            var timeToStart = ride.EarliestStart - t;

            var factor = 0;
            if (timeToStart >= distance)
            {
                factor = ride.RideDuration + input.Bonus - timeToStart;
            }
            else
            {
                factor = ride.RideDuration - distance;
            }

            return factor / (CalculateCentroidDifference(ride.EndRow,ride.EndColumn, centroidRow, centroidColumn)/(input.Rows*input.Columns));
        }

        public static void CalculateCentroid(List<Ride> inputRides, out double row, out double column)
        {
            if (inputRides.Any())
            {
                row = inputRides.Average(x => x.StartRow);
                column = inputRides.Average(x => x.StartColumn);
            }
            else
            {
                row = 0;
                column = 0;
            }
            
        }
    }
}
