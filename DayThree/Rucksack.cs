namespace DayThree;

public sealed class Rucksack
{
    private readonly HashSet<char> _firstCompartment;
    private readonly HashSet<char> _secondCompartment;
    
    public Rucksack(string contents)
    {
        var compartmentLength = contents.Length / 2;
        
        var firstHalf = contents[..compartmentLength];
        var secondHalf = contents[compartmentLength..];
        
        _firstCompartment = new HashSet<char>(firstHalf);
        _secondCompartment = new HashSet<char>(secondHalf);
    }

    public char FindError() => _firstCompartment.Intersect(_secondCompartment).First();

    public HashSet<char> GetAllCharacters() => _firstCompartment.Union(_secondCompartment).ToHashSet();
}