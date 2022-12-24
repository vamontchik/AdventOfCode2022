using DaySeven;

var lines = File
    .ReadLines("full.txt")
    .ToList();

var directoryStructure = new DirectoryStructure();

DirectoryReader.PopulateFromLines(lines, directoryStructure);

const uint threshold = 100000U;
var sum = DirectorySizeCalculator.CalculateSumOfDirectorySizesUnderThreshold(directoryStructure, threshold);
Console.WriteLine(sum);

// Part Two

var sizeOfDirectoryNeededForDeletion = DirectoryDeleter
    .CalculateMinSizeOfDirectoryNeededForDeletion(directoryStructure);
Console.WriteLine(sizeOfDirectoryNeededForDeletion);