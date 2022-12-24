namespace DaySeven;

public static class DirectoryDeleter
{
    private static uint TotalSize => 70000000U; // 70 mil
    private static uint SizeNeededForUpdate => 30000000U; // 30 mil

    public static uint CalculateSizeOfDirectoryNeededForDeletion(DirectoryStructure directoryStructure)
    {
        var sizeNeededForDeletion = CalculateSizeNeededForDeletion(directoryStructure);
        var possibleDirectories = directoryStructure
            .GetDirectories()
            .Select(directoryStructure.CalculateSizeAtDirectory)
            .Where(directorySize => directorySize >= sizeNeededForDeletion)
            .ToList();
        return possibleDirectories.Min();
    }

    private static uint CalculateSizeNeededForDeletion(DirectoryStructure directoryStructure) =>
        SizeNeededForUpdate - (TotalSize - directoryStructure.CalculateSizeAtDirectory("/"));
}