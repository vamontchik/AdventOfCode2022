namespace DayTwo;

public class GameHandler
{
    // (player move, opponent move)
    private readonly List<(string, string)> _gameMoves;
    private readonly PlayerGameMove _playerGameMovesUtility;
    private readonly OpponentGameMove _opponentGameMovesUtility;

    public GameHandler()
    {
        _gameMoves = new List<(string, string)>();
        _playerGameMovesUtility = new PlayerGameMove();
        _opponentGameMovesUtility = new OpponentGameMove();
    }

    public void ReadStrategyGuide(string inputFilePath)
    {
        var lines = File
            .ReadLines(inputFilePath);

        _gameMoves.Clear();

        PopulateMoves(lines);
    }

    private void PopulateMoves(IEnumerable<string> lines)
    {
        foreach (var line in lines)
        {
            var splitContents = line.Split(" ");

            var opponentMove = splitContents[0];
            var playerMove = splitContents[1];

            _gameMoves.Add((playerMove, opponentMove));
        }
    }

    public uint CalculatePlayerScore()
    {
        var score = uint.MinValue;

        foreach (var (playerMove, opponentMove) in _gameMoves)
        {
            var comparisonScore = DecideRound(playerMove, opponentMove);
            var playerChoiceScore = _playerGameMovesUtility.MoveToChoiceScore[playerMove];
            score += comparisonScore + playerChoiceScore;
        }

        return score;
    }

    private uint DecideRound(string playerMove, string opponentMove)
    {
        var translatedOpponentMove = _opponentGameMovesUtility.OpponentMoveToPlayerMove[opponentMove];
        
        if (playerMove == translatedOpponentMove)
        {
            return 3;
        }
        
        var winsAgainst = _playerGameMovesUtility.MoveToWinningAgainst[playerMove];
        if (translatedOpponentMove == winsAgainst)
        {
            return 6;
        }

        return 0;
    }
}