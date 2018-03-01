using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecialCharacters.Models
{
    public class Car
    {
        public int Index { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        public int RideEnd { get; set; }
        public bool Busy => CurrentRide.HasValue;
        public bool Scheduled => ScheduledRide.HasValue;
        public int? CurrentRide { get; set; }
        public List<int> CompletedRides { get; set; } = new List<int>();
        public int? ScheduledRide { get; set; }
    }
}
