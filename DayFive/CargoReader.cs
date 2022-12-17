namespace DayFive;

public sealed class CargoReader
{
    private readonly List<Stack<char>> _cargo;
    private readonly List<Move> _moves;

    private const int WidthOfCrate = 3;
    private const int WidthOfSeparator = 1;

    public CargoReader()
    {
        _cargo = new List<Stack<char>>();
        _moves = new List<Move>();
    }

    public void ReadInitialCargoSetup(string inputFilePath)
    {
        _cargo.Clear();
        _moves.Clear();
        
        PopulateStacksForFile(File.ReadLines(inputFilePath).First());
        ReadLines(File.ReadLines(inputFilePath));
        FixCrateOrientationInStacks();
    }

    private void PopulateStacksForFile(string line)
    {
        foreach (var _ in line.Chunk(WidthOfCrate + WidthOfSeparator))
        {
            _cargo.Add(new Stack<char>());
        }
    }

    private void ReadLines(IEnumerable<string> lines)
    {
        var readingStacks = true;

        foreach (var line in lines)
        {
            if (line.Equals(string.Empty))
            {
                readingStacks = false;
                continue;
            }

            if (readingStacks)
            {
                ReadLevelOfStack(line);
            }
            else // reading arrangement
            {
                ReadMove(line);
            }
        }
    }

    private void ReadLevelOfStack(string line)
    {
        var stackIndex = 0;
        foreach (var crateAndSeparator in line.Chunk(WidthOfCrate + WidthOfSeparator))
        {
            var crateLetter = crateAndSeparator[1];

            if (char.IsWhiteSpace(crateLetter))
            {
                stackIndex++;
                continue;
            }

            if (char.IsNumber(crateLetter))
            {
                stackIndex++;
                continue;
            }

            _cargo[stackIndex].Push(crateLetter);

            stackIndex++;
        }
    }

    private void ReadMove(string line)
    {
        var contents = line.Split(' ');

        var count = Convert.ToUInt32(contents[1]);
        var from = Convert.ToUInt32(contents[3]) - 1; // -1 b/c index in file starts at 1
        var to = Convert.ToUInt32(contents[5]) - 1; // -1 b/c index in file starts at 1

        var move = new Move(count, from, to);

        _moves.Add(move);
    }

    private void FixCrateOrientationInStacks()
    {
        var flippedStacks = _cargo
            .Select(stack => new Queue<char>(stack))
            .Select(queue => new Stack<char>(queue))
            .ToList();

        _cargo.Clear();

        _cargo.AddRange(flippedStacks);
    }

    public void PerformMovesFor9000Series()
    {
        foreach (var (count, from, to) in _moves)
        {
            var fromStack = _cargo[Convert.ToInt32(from)];
            var toStack = _cargo[Convert.ToInt32(to)];
            for (var i = 0; i < count; ++i)
            {
                toStack.Push(fromStack.Pop());
            }
        }
    }

    public void PerformMovesFor9001Series()
    {
        foreach (var (count, from, to) in _moves)
        {
            var fromStack = _cargo[Convert.ToInt32(from)];
            var toStack = _cargo[Convert.ToInt32(to)];
            var tempStack = new Stack<char>();
            
            for (var i = 0; i < count; ++i)
            {
                tempStack.Push(fromStack.Pop());
            }

            foreach (var item in tempStack)
            {
                toStack.Push(item);
            }
        }
    }

    public void PrintTopOfEachStack()
    {
        foreach (var stack in _cargo)
        {
            Console.Write(stack.Peek());
        }

        Console.WriteLine();
    }
}