using DaySix;

var signalReader = new SignalReader();
signalReader.ReadSignal("full.txt");
var markerLocation = signalReader.FindMarker();
Console.WriteLine(markerLocation);