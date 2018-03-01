using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpecialCharacters.Models;

namespace SpecialCharacters.Output
{
    public class OutputWriter
    {
        public void Write(OutputModel model, string path)
        {
            var lines = model.CarRides.Select(x =>
                $"{x.Rides.Length} " + string.Join(" ", x.Rides.Select(ride => ride.Index.ToString())));
            File.WriteAllLines(path, lines);
        }
    }
}
