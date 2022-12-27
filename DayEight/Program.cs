using DayEight;

var lines = File
    .ReadLines("full.txt")
    .ToList();

var trees = new Trees(lines);
var visibleTrees = trees.CalculateAmountOfVisibleTrees();
Console.WriteLine(visibleTrees);
