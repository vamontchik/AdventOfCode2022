namespace DayFour;

public sealed class SectionsReader
{
    private readonly List<(SectionRange, SectionRange)> _sectionRanges;
    
    public SectionsReader(string inputFilePath)
    {
        _sectionRanges = new List<(SectionRange, SectionRange)>();

        foreach (var pair in File.ReadLines(inputFilePath))
        {
            var bothElves = pair.Split(',');
            
            var firstElfRange = ExtractRanges(bothElves[0]);
            var secondElfRange = ExtractRanges(bothElves[1]);
            
            _sectionRanges.Add((firstElfRange, secondElfRange));
        }
    }

    private static SectionRange ExtractRanges(string elfPairing)
    {
        var elfRange = elfPairing.Split('-');
        return ConvertRangesToUint(elfRange);
    }

    private static SectionRange ConvertRangesToUint(string[] elfRange)
    {
        var min = Convert.ToUInt32(elfRange[0]);
        var max = Convert.ToUInt32(elfRange[1]);
        return new SectionRange(min, max);
    }

    public uint CalculateFullyContainedRanges()
    {
        var total = 0U;
        
        foreach (var (firstElfRange, secondElfRange) in _sectionRanges)
        {
            var doesFirstFullyContainSecond = firstElfRange.FullyContains(secondElfRange);
            var doesSecondFullyContainFirst = secondElfRange.FullyContains(firstElfRange);

            total += doesFirstFullyContainSecond || doesSecondFullyContainFirst
                ? 1
                : 0U;
        }

        return total;
    }

    public uint CalculateAnyOverlappedRanges()
    {
        var total = 0U;

        foreach (var (firstElfRange, secondElfRange) in _sectionRanges)
        {
            var firstOverlapWithSecond = firstElfRange.OverlapsWith(secondElfRange);

            total += firstOverlapWithSecond
                ? 1
                : 0U;
        }
        
        return total;
    }
}