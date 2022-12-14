namespace DayOne;

public class CalorieCounter
{
    private readonly List<List<uint>> _caloriesForAllElves;

    public CalorieCounter()
    {
        _caloriesForAllElves = new List<List<uint>>();
    }

    public void ReadCaloriesFromFile(string inputFilePath)
    {
        var lines = File
            .ReadAllLines(inputFilePath)
            .ToList();

        _caloriesForAllElves.Clear();

        PopulateCaloriesPerElf(lines);
    }

    private void PopulateCaloriesPerElf(List<string> lines)
    {
        var accumulator = new List<uint>();
        foreach (var line in lines)
        {
            if (line.Equals(string.Empty))
            {
                _caloriesForAllElves.Add(accumulator);
                accumulator = new List<uint>();
            }
            else
            {
                var calories = Convert.ToUInt32(line);
                accumulator.Add(calories);
            }
        }
    }

    public uint FindElfWithMostFood()
    {
        CheckForValidState();

        return _caloriesForAllElves
            .Select(ElfListAggregator)
            .Max();
    }

    public IEnumerable<uint> FindTopThreeElvesWithMostFood()
    {
        CheckForValidState();

        return _caloriesForAllElves
            .Select(ElfListAggregator)
            .OrderByDescending(x => x)
            .Take(3);
    }

    private void CheckForValidState()
    {
        if (_caloriesForAllElves.Count == 0)
            throw new Exception("Unable to find max due to empty state. Read calories from file first!");
    }
    
    private static uint ElfListAggregator(List<uint> caloriesPerElf) => caloriesPerElf
        .Aggregate<uint, uint>(0, (current, sum) => current + sum);
}