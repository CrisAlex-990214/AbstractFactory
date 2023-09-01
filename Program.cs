using AbstractFactory;

var list = new List<TrainPassenger>() { new(new HighSpeedRail()), new(new InterCityRail()) };
list.ForEach(t => t.PrintEstimatedCost());

Console.ReadKey();
