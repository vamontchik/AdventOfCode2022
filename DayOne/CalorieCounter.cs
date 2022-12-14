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
        if (_caloriesForAllElves.Count == 0)
            throw new Exception("Unable to find max due to empty state. Read calories from file first!");

        return _caloriesForAllElves
            .Select(caloriesPerElf => caloriesPerElf
                .Aggregate<uint, uint>(0, (current, calories) => current + calories))
            .Max();
    }
}