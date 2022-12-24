namespace DaySeven;

public static class DirectorySizeCalculator
{
    public static uint CalculateSumOfDirectorySizesUnderThreshold(DirectoryStructure directoryStructure, uint threshold)
    {
        var sum = directoryStructure
            .GetDirectories()
            .Select(directoryStructure.CalculateSizeAtDirectory)
            .Where(size => size <= threshold)
            .Sum(x => x);

        return Convert.ToUInt32(sum);
    }
}