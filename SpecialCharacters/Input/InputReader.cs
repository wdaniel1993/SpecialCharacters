using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpecialCharacters.Calculation;
using SpecialCharacters.Models;
using SuccincT.Parsers;

namespace SpecialCharacters.Input
{
    public class InputReader
    {
        public InputModel Read(string filePath)
        {
            var lines = File.ReadAllLines(filePath);
            var inputParams = lines.First().Split().Select(x => x.TryParseInt().ValueOrDefault).ToList();

            var model = new InputModel()
            {
                Rows = inputParams[0],
                Columns = inputParams[1],
                CarCount = inputParams[2],
                RideCount = inputParams[3],
                Bonus = inputParams[4],
                SimulationSteps = inputParams[5],
                Rides = new Ride[inputParams[3]]
            };

            var rideLines = lines.Skip(1).ToList();
            for (var i = 0; i < model.RideCount; i++)
            {
                var rideParamns = rideLines[i].Split().Select(x => x.TryParseInt().ValueOrDefault).ToList();
                var ride = new Ride()
                {
                    Index = i,
                    StartRow = rideParamns[0],
                    StartColumn = rideParamns[1],
                    EndRow = rideParamns[2],
                    EndColumn = rideParamns[3],
                    EarliestStart = rideParamns[4],
                    LatestFinish = rideParamns[5]
                };
                ride.RideDuration =
                    CalculationHelper.CalculateTimeDifference(ride.StartRow, ride.StartColumn, ride.EndRow,
                        ride.EndColumn);
                ride.LatestStart = ride.LatestFinish - ride.RideDuration;
                model.Rides[i] = ride;
            }
            return model;
        }
    }
}
