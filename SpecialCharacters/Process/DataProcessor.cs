using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpecialCharacters.Calculation;
using SpecialCharacters.Models;

namespace SpecialCharacters.Process
{
    public class DataProcessor
    {
        public OutputModel Process(InputModel input)
        {
            var futureRides = input.Rides.OrderBy(x => x.LatestStart).ToList();
            var currentRides = new List<Ride>();
            var scheduledRides = new List<Ride>();

            var cars = new List<Car>();
            for (var i=0;i<input.CarCount;i++)
            {
                cars.Add(new Car()
                {
                    Index = i
                });
            }

            for (var t = 0; t <= input.SimulationSteps; t++)
            {
                futureRides.RemoveAll(x => x.LatestStart < t);

                foreach (var car in cars)
                {
                    if (car.RideEnd <= t)
                    {
                        if (car.Scheduled)
                        {
                            var ride = input.Rides[car.ScheduledRide.Value];
                            if (ride.EarliestStart <= t)
                            {
                                car.CurrentRide = car.ScheduledRide;
                                car.ScheduledRide = null;
                                car.RideEnd = ride.RideDuration + t;
                            }
                        }
                    }
                    if (car.RideEnd <= t)
                    {
                        if (car.Busy)
                        {
                            car.CompletedRides.Add(car.CurrentRide.Value);
                            car.CurrentRide = null;
                        }
                    }
                    if (!car.Busy && !car.Scheduled)
                    {
                        var chosenRide = futureRides.Where(ride =>
                            CalculationHelper.CalculateTimeDifference(car.Row, car.Column, ride.StartRow,
                                ride.StartColumn) + t <= ride.LatestStart).OrderBy(x => x.EarliestStart).FirstOrDefault();

                        if (chosenRide != null)
                        {
                            chosenRide.Car = car.Index;
                            car.ScheduledRide = chosenRide.Index;
                            car.RideEnd = CalculationHelper.CalculateTimeDifference(car.Row, car.Column, chosenRide.StartRow,
                                chosenRide.StartColumn) + t;
                            futureRides.Remove(chosenRide);
                        }
                    }
                    
                }
                
            }

            var output = new OutputModel()
            {
                CarRides = cars.Select(x => new CarRide()
                {
                    Rides = x.CompletedRides.ToArray()
                }).ToArray()
            };
            return output;
        }
    }
}
