using DayFive;

// Part One

var cargoReader = new CargoReader();
cargoReader.ReadInitialCargoSetup("full.txt");
cargoReader.PerformMovesFor9000Series();
cargoReader.PrintTopOfEachStack();

// Part Two

cargoReader.ReadInitialCargoSetup("full.txt");
cargoReader.PerformMovesFor9001Series();
cargoReader.PrintTopOfEachStack();