namespace DayTwo;

public sealed class GameHandler
{
    // (player move, opponent move)
    private readonly List<(string, string)> _gameMoves;
    private readonly PlayerGameMove _playerGameMovesUtility;
    private readonly OpponentGameMove _opponentGameMovesUtility;
    private readonly PlayerDecisionMove _playerDecisionMoveUtility;

    public GameHandler()
    {
        _gameMoves = new List<(string, string)>();
        _playerGameMovesUtility = new PlayerGameMove();
        _opponentGameMovesUtility = new OpponentGameMove();
        _playerDecisionMoveUtility = new PlayerDecisionMove();
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

            var opponent = splitContents[0];
            var player = splitContents[1];

            _gameMoves.Add((player, opponent));
        }
    }

    public uint CalculatePlayerScoreForMoveScheme()
    {
        var score = uint.MinValue;

        foreach (var (playerMove, opponentMove) in _gameMoves)
        {
            score += ScoreRound(playerMove, opponentMove);
        }

        return score;
    }

    public uint CalculatePlayerScoreForDecisionScheme()
    {
        var score = uint.MinValue;

        foreach (var (playerDecision, opponentMove) in _gameMoves)
        {
            var playerMove = _playerDecisionMoveUtility
                .DecisionWithOpponentMoveToPlayerMove[(playerDecision, opponentMove)];
            score += ScoreRound(playerMove, opponentMove);
        }

        return score;
    }

    private uint ScoreRound(string playerMove, string opponentMove)
    {
        var comparisonScore = DecideRound(playerMove, opponentMove);
        var playerChoiceScore = _playerGameMovesUtility.MoveToChoiceScore[playerMove];
        return comparisonScore + playerChoiceScore;
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