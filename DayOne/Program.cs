using DayOne;

// Part One

var calorieCounter = new CalorieCounter();
calorieCounter.ReadCaloriesFromFile(@"full.txt");
var caloriesOfElfWithMostFood = calorieCounter.FindElfWithMostFood();
Console.WriteLine(caloriesOfElfWithMostFood);

// Part Two

var caloriesOfTopThreeElves = calorieCounter.FindTopThreeElvesWithMostFood();
var total = caloriesOfTopThreeElves.Aggregate<uint, uint>(0, (current, sum) => current + sum);
Console.WriteLine(total);