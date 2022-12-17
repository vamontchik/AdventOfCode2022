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
        for (var i = 0; i < _signal.Length; ++i)
        {
            if (MarkerFound(i))
            {
                return i + 1; // (+1) since answer is 1-based
            }
        }

        throw new Exception("No signal found!");
    }

    private bool MarkerFound(int i)
    {
        if (i < 3)
        {
            return false;
        }

        var charactersToCompare = new List<char> { _signal[i], _signal[i - 1], _signal[i - 2], _signal[i - 3] };
        var hashSet = new HashSet<char>(charactersToCompare);
        return hashSet.Count == 4;
    }
}