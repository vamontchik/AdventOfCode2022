// Part One

using DayFour;

var sectionsReader = new SectionsReader("full.txt");
var fullyContainedTotal = sectionsReader.CalculateFullyContainedRanges();
Console.WriteLine(fullyContainedTotal);

// Part Two

var overlappingAtAllTotal = sectionsReader.CalculateAnyOverlappedRanges();
Console.WriteLine(overlappingAtAllTotal);