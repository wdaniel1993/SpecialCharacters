using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecialCharacters.Calculation
{
    public class CalculationHelper
    {
        public static int CalculateTimeDifference(int row1, int column1, int row2, int column2)
        {
            return Math.Abs(row1 - row2) + Math.Abs(column1 - column2);
        }
    }
}
