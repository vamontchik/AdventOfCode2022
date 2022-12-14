namespace DayTwo;

public sealed class PlayerGameMove
{
    public const string Rock = "X";
    public const string Paper = "Y";
    public const string Scissors = "Z";

    public readonly Dictionary<string, string> MoveToWinningAgainst = new()
    {
        { Rock, Scissors },
        { Scissors, Paper },
        { Paper, Rock }
    };
    
    public readonly Dictionary<string, uint> MoveToChoiceScore = new()
    {
        { Rock, 1 },
        { Paper, 2 },
        { Scissors, 3 }
    };
}

public sealed class OpponentGameMove
{
    private const string Rock = "A";
    private const string Paper = "B";
    private const string Scissors = "C";

    public readonly Dictionary<string, string> OpponentMoveToPlayerMove = new()
    {
        { Rock, PlayerGameMove.Rock },
        { Scissors, PlayerGameMove.Scissors },
        { Paper, PlayerGameMove.Paper }
    };
}