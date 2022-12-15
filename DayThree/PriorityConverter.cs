namespace DayThree;

public static class PriorityConverter
{
    private static readonly Dictionary<char, uint> Priorities;

    static PriorityConverter()
    {
        Priorities = new Dictionary<char, uint>();

        var character = 'a';
        var priority = 1U;
        while (character != 'z')
        {
            Priorities.Add(character, priority);
            character++;
            priority++;
        }
        Priorities.Add('z', 26);

        character = 'A';
        priority = 27;
        while (character != 'Z')
        {
            Priorities.Add(character, priority);
            character++;
            priority++;
        }
        Priorities.Add('Z', 52);
    }

    public static uint ConvertCharacterToPriority(char character) => Priorities[character];
}