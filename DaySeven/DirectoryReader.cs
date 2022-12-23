namespace DaySeven;

public static class DirectoryReader
{
    public static void PopulateFromLines(IReadOnlyList<string> lines, DirectoryStructure directoryStructure)
    {
        for (var i = 0; i < lines.Count;)
        {
            var contents = lines[i].Split(' ');

            var command = contents[1];

            switch (command)
            {
                case "cd":
                    var argument = contents[2];
                    HandleCdCommand(directoryStructure, argument);
                    i += 1;
                    break;
                case "ls":
                    var lsLines = FindLinesForLsCommand(lines, i + 1);
                    HandleLsCommand(directoryStructure, lsLines);
                    i += (lsLines.Count + 1);
                    break;
                default:
                    throw new Exception("Unknown command!");
            }
        }
    }

    private static void HandleCdCommand(DirectoryStructure directoryStructure, string argument)
    {
        switch (argument)
        {
            case "..":
                directoryStructure.MoveUpOneDirectory();
                break;
            case "/":
                directoryStructure.MoveToRootDirectory();
                break;
            default:
                directoryStructure.MoveToNewDirectory(argument);
                break;
        }
    }

    private static void HandleLsCommand(DirectoryStructure directoryStructure, IEnumerable<string> lines)
    {
        foreach (var line in lines)
        {
            var contents = line.Split(' ');

            var dirOrSize = contents[0];

            if (dirOrSize.Equals("dir"))
            {
                var directoryName = contents[1];
                directoryStructure.AddDirectoryAtCurrentLevel(directoryName);
            }
            else // found a file with a size
            {
                var fileSize = Convert.ToInt32(contents[0]);
                var fileName = contents[1];
                directoryStructure.AddFileAtCurrentLevel(fileName, fileSize);
            }
        }
    }

    private static List<string> FindLinesForLsCommand(IReadOnlyList<string> lines, int startIndex)
    {
        var lsLines = new List<string>();

        for (var curr = startIndex; curr < lines.Count; ++curr)
        {
            var currLine = lines[curr];

            if (currLine.StartsWith('$'))
                break;

            lsLines.Add(currLine);
        }

        return lsLines;
    }
}