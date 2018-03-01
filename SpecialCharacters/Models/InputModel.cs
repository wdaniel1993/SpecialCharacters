using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecialCharacters.Models
{
    public struct InputModel
    {
        public int Rows { get; set; }
        public int Columns { get; set; }
        public int VehicleCount { get; set; }
        public int RideCount { get; set; }
        public int Bonus { get; set; }
        public int SimulationSteps { get; set; }
        public Ride[] Rides { get; set; }
    }
}
