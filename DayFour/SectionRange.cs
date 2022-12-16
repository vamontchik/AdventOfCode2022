namespace DayFour;

public sealed class SectionRange
{
    public uint Min { get; }
    public uint Max { get; }

    public SectionRange(uint min, uint max)
    {
        Min = min;
        Max = max;
    }

    public bool FullyContains(SectionRange other) => Min <= other.Min && Max >= other.Max;

    public bool OverlapsWith(SectionRange other)
    {
        var caseOne = Min <= other.Min && Max >= other.Min; // this.Min < other.Min, not contained
        var caseTwo = Min <= other.Max && Max >= other.Max; // this.Min > other.Min, not contained
        var caseThree = Min <= other.Min && Max >= other.Max; // this outside other, contained
        var caseFour = Min >= other.Min && Max <= other.Max; // this inside other, contained
        return caseOne || caseTwo || caseThree || caseFour;
    }
}