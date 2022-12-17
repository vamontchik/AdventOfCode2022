namespace DaySix;

public sealed class SignalReader
{
    private string _signal;

    public SignalReader()
    {
        _signal = string.Empty;
    }

    public void ReadSignal(string inputFilePath)
    {
        _signal = File.ReadAllText(inputFilePath);
    }

    public int FindMarker()
    {
        const int distinctCharacterCount = 4;
        for (var i = 0; i < _signal.Length; ++i)
        {
            if (MarkerFound(i, distinctCharacterCount))
            {
                return i + 1; // (+1) since answer is 1-based
            }
        }

        throw new Exception("No signal found!");
    }

    public int FindStartOfMessage()
    {
        const int distinctCharacterCount = 14;
        for (var i = 0; i < _signal.Length; ++i)
        {
            if (MarkerFound(i, distinctCharacterCount))
            {
                return i + 1; // (+1) since answer is 1-based
            }
        }

        throw new Exception("No signal found!");
    }

    private bool MarkerFound(int i, int distinctCharacterCount)
    {
        if (i < distinctCharacterCount - 1)
        {
            return false;
        }

        var charactersToCompare = _signal
            .Substring(i - (distinctCharacterCount - 1), distinctCharacterCount);

        var hashSet = new HashSet<char>(charactersToCompare);
        return hashSet.Count == distinctCharacterCount;
    }
}