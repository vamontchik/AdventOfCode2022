using DayFive;

var cargoReader = new CargoReader();
cargoReader.ReadInitialCargoSetup("full.txt");
cargoReader.PerformMoves();
cargoReader.PrintTopOfEachStack();