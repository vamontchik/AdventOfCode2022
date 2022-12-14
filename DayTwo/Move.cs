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
    public const string Rock = "A";
    public const string Paper = "B";
    public const string Scissors = "C";

    public readonly Dictionary<string, string> OpponentMoveToPlayerMove = new()
    {
        { Rock, PlayerGameMove.Rock },
        { Scissors, PlayerGameMove.Scissors },
        { Paper, PlayerGameMove.Paper }
    };
}

public sealed class PlayerDecisionMove
{
    private const string Lose = "X";
    private const string Draw = "Y";
    private const string Win = "Z";

    public readonly Dictionary<(string, string), string> DecisionWithOpponentMoveToPlayerMove = new()
    {
        { (Lose, OpponentGameMove.Rock), PlayerGameMove.Scissors },
        { (Lose, OpponentGameMove.Paper), PlayerGameMove.Rock },
        { (Lose, OpponentGameMove.Scissors), PlayerGameMove.Paper },
        { (Draw, OpponentGameMove.Rock), PlayerGameMove.Rock },
        { (Draw, OpponentGameMove.Paper), PlayerGameMove.Paper },
        { (Draw, OpponentGameMove.Scissors), PlayerGameMove.Scissors },
        { (Win, OpponentGameMove.Rock), PlayerGameMove.Paper },
        { (Win, OpponentGameMove.Paper), PlayerGameMove.Scissors },
        { (Win, OpponentGameMove.Scissors), PlayerGameMove.Rock }
    };
}