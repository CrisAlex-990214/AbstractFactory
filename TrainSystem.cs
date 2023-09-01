using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    internal interface TrainSystem
    {
        TrainRoute TrainRoute { get; }
        TrainRestrictions TrainRestrictions { get; }
    }

    interface TrainRoute
    {
        string Name { get; }
        int NoOfStops { get; }
    }

    interface TrainRestrictions
    {
        int SpeedMPH { get; }
        int DistanceCoveredMiles { get; }
    }

    class HighSpeedRail : TrainSystem
    {
        public TrainRoute TrainRoute => new HighSpeedTrainRoute();

        public TrainRestrictions TrainRestrictions => new HighSpeedTrainRestrictions();
    }

    internal class HighSpeedTrainRestrictions : TrainRestrictions
    {
        public int SpeedMPH => 150;

        public int DistanceCoveredMiles => 2000;
    }

    internal class HighSpeedTrainRoute : TrainRoute
    {
        public string Name => "Mumbai";

        public int NoOfStops => 4;
    }

    class InterCityRail : TrainSystem
    {
        public TrainRoute TrainRoute => new InterCityTrainRoute();

        public TrainRestrictions TrainRestrictions => new InterCityTrainRestrictions();
    }

    internal class InterCityTrainRestrictions : TrainRestrictions
    {
        public int SpeedMPH => 100;

        public int DistanceCoveredMiles => 1000;
    }

    internal class InterCityTrainRoute : TrainRoute
    {
        public string Name => "Boston";

        public int NoOfStops => 10;
    }

    class TrainPassenger
    {
        private readonly TrainRoute route;
        private readonly TrainRestrictions restrictions;

        public TrainPassenger(TrainSystem trainSystem)
        {
            route = trainSystem.TrainRoute;
            restrictions = trainSystem.TrainRestrictions;
        }

        public void PrintEstimatedCost()
        {
            var totalCost = restrictions.DistanceCoveredMiles + restrictions.SpeedMPH - route.NoOfStops;
            Console.WriteLine($"The total cost for the route {route.GetType().Name} is: ${totalCost}");
        }
    }
}
