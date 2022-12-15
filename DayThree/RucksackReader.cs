namespace DayThree;

public sealed class RucksackReader
{
    private List<Rucksack> _rucksacks;

    public RucksackReader()
    {
        _rucksacks = new List<Rucksack>();
    }

    public void ReadRucksackFile(string inputFilePath)
    {
        var lines = File
            .ReadLines(inputFilePath);

        _rucksacks.Clear();

        foreach (var line in lines)
        {
            var rucksack = new Rucksack(line);
            _rucksacks.Add(rucksack);
        }
    }

    public uint CalculatePrioritySumOfErrors()
    {
        var total = 0U;

        foreach (var rucksack in _rucksacks)
        {
            var error = rucksack.FindError();
            var priority = PriorityConverter.ConvertCharacterToPriority(error);
            total += priority;
        }

        return total;
    }
}