namespace DayThree;

public sealed class RucksackReader
{
    private readonly List<Rucksack> _rucksacks;

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

    public uint CalculateSumOfPartitions()
    {
        var total = 0U;

        foreach (var chunk in _rucksacks.Chunk(3))
        {
            var first = chunk[0];
            var second = chunk[1];
            var third = chunk[2];

            var charactersOfFirst = first.GetAllCharacters();
            var charactersOfSecond = second.GetAllCharacters();
            var charactersOfThird = third.GetAllCharacters();

            var commonCharacter = charactersOfFirst
                .Intersect(charactersOfSecond)
                .Intersect(charactersOfThird)
                .First();

            var priority = PriorityConverter.ConvertCharacterToPriority(commonCharacter);

            total += priority;
        }

        return total;
    }
}