// Part One

using DayThree;

var rucksackReader = new RucksackReader();
rucksackReader.ReadRucksackFile("full.txt");
var sumOfPrioritiesOfErrors = rucksackReader.CalculatePrioritySumOfErrors();
Console.WriteLine(sumOfPrioritiesOfErrors);

// Part Two

var sumOfPartitionPriorities = rucksackReader.CalculateSumOfPartitions();
Console.WriteLine(sumOfPartitionPriorities);