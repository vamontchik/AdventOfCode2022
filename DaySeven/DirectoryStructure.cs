namespace DaySeven;

public sealed class DirectoryStructure
{
    // path -> (filename -> size)
    // OR
    // path -> (name-of-inner-directory -> -1)
    private Dictionary<string, Dictionary<string, int>> Directories { get; }
    private string CurrentDirectory { get; set; }

    public DirectoryStructure()
    {
        Directories = new Dictionary<string, Dictionary<string, int>>();
        CurrentDirectory = string.Empty;
    }

    #region State Manipulation

    public void MoveToNewDirectory(string newDirectory)
    {
        if (CurrentDirectory.Equals("/"))
        {
            CurrentDirectory += newDirectory;
        }
        else
        {
            CurrentDirectory += '/' + newDirectory;
        }
    }

    public void MoveToRootDirectory()
    {
        CurrentDirectory = "/";
    }

    public void MoveUpOneDirectory()
    {
        var lastIndexOfSlash = CurrentDirectory.LastIndexOf('/');
        var newDirectory = CurrentDirectory[..lastIndexOfSlash];
        if (newDirectory.Equals(string.Empty))
        {
            MoveToRootDirectory();
        }
        else
        {
            CurrentDirectory = newDirectory;
        }
    }

    public void AddFileAtCurrentLevel(string fileName, int fileSize)
    {
        var success = Directories.TryGetValue(CurrentDirectory, out _);
        if (!success)
        {
            Directories[CurrentDirectory] = new Dictionary<string, int>();
        }

        Directories[CurrentDirectory][fileName] = fileSize;
    }

    public void AddDirectoryAtCurrentLevel(string directoryName)
    {
        var success = Directories.TryGetValue(CurrentDirectory, out _);
        if (!success)
        {
            Directories[CurrentDirectory] = new Dictionary<string, int>();
        }

        Directories[CurrentDirectory][directoryName] = -1;
    }

    #endregion

    #region Size Calculation

    public uint CalculateSizeAtDirectory(string directoryName)
    {
        var filesAndDirectories = Directories[directoryName];

        var total = 0U;

        foreach (var (fileOrDir, size) in filesAndDirectories)
        {
            total += size switch
            {
                -1 when directoryName.Equals("/") => CalculateSizeAtDirectory(directoryName + fileOrDir),
                -1 when !directoryName.Equals("/") => CalculateSizeAtDirectory(directoryName + '/' + fileOrDir),
                _ => Convert.ToUInt32(size)
            };
        }

        return total;
    }

    #endregion

    #region Helper Methods

    public IEnumerable<string> GetDirectories() => Directories.Keys;

    #endregion
}