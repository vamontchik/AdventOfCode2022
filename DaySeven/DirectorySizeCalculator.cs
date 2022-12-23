namespace DaySeven;

public static class DirectorySizeCalculator
{
    public static uint CalculateSumOfDirectorySizesUnderThreshold(DirectoryStructure directoryStructure)
    {
        const uint threshold = 100000U;
        
        var acceptableDirectorySizes = directoryStructure
            .GetDirectories()
            .Select(directoryStructure.CalculateSizeAtDirectory)
            .Where(size => size <= threshold)
            .ToList();

        return Convert.ToUInt32(acceptableDirectorySizes.Sum(x => x));
    }
}