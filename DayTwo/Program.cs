using DayTwo;

// Part One

var gameHandler = new GameHandler();
gameHandler.ReadStrategyGuide("full.txt");
var score = gameHandler.CalculatePlayerScoreForMoveScheme();
Console.WriteLine(score);

// Part Two

score = gameHandler.CalculatePlayerScoreForDecisionScheme();
Console.WriteLine(score);