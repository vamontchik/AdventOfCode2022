using DaySeven;

var lines = File
    .ReadLines("full.txt")
    .ToList();

var directoryStructure = new DirectoryStructure();

DirectoryReader.PopulateFromLines(lines, directoryStructure);

var sum = DirectorySizeCalculator.CalculateSumOfDirectorySizesUnderThreshold(directoryStructure);

Console.WriteLine(sum);