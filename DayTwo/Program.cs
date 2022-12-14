using DayTwo;

// Part One

var gameHandler = new GameHandler();
gameHandler.ReadStrategyGuide("full.txt");
var score = gameHandler.CalculatePlayerScore();
Console.WriteLine(score);