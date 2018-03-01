using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecialCharacters.Models
{
    public class Ride
    {
        public int Index { get; set; }
        public int StartRow { get; set; }
        public int StartColumn { get; set; }
        public int EndRow { get; set; }
        public int EndColumn { get; set; }
        public int EarliestStart { get; set; }
        public int LatestFinish { get; set; }
        public int LatestStart { get; set; }
        public int RideDuration { get; set; }
        public int? Car { get; set; }
    }
}
