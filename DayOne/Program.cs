using DayOne;

// Part One

var calorieCounter = new CalorieCounter();
calorieCounter.ReadCaloriesFromFile(@"full.txt");
var caloriesOfElfWithMostFood = calorieCounter.FindElfWithMostFood();
Console.WriteLine(caloriesOfElfWithMostFood);
