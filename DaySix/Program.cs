using DaySix;

// Part One

var signalReader = new SignalReader();
signalReader.ReadSignal("full.txt");
var markerLocation = signalReader.FindMarker();
Console.WriteLine(markerLocation);

// Part Two

var startOfMessageLocation = signalReader.FindStartOfMessage();
Console.WriteLine(startOfMessageLocation);