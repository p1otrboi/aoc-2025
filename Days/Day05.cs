namespace aoc_2025.Days;

public sealed class Day05 : BaseDay
{
    private readonly List<(long, long)> _ranges = [];
    private readonly List<long> _idList = [];

    public Day05()
    {
        bool isRange = true;

        foreach (var line in File.ReadLines(InputFilePath))
        {
            if (string.IsNullOrEmpty(line))
            {
                isRange = false;
                continue;
            }
            if (isRange)
            {
                var parts = line.Split('-');
                _ranges.Add((long.Parse(parts[0]), long.Parse(parts[1])));
                continue;
            }
            _idList.Add(long.Parse(line));
        }
    }

    public override ValueTask<string> Solve_1()
    {
        int freshIds = 0;

        foreach (var id in _idList)
        {
            foreach (var range in _ranges)
            {
                if (id >= range.Item1 && id <= range.Item2)
                {
                    freshIds++;
                    break;
                }
            }
        }
        return new(freshIds.ToString());
    }


    public override ValueTask<string> Solve_2()
    {
        long uniqueIds = 0;

        var ranges = _ranges
            .Select(r => (Start: r.Item1, End: r.Item2))
            .OrderBy(r => r.Start)
            .ToList();

        long currentStart = ranges[0].Start;
        long currentEnd = ranges[0].End;

        for (int i = 1; i < ranges.Count; i++)
        {
            var (start, end) = ranges[i];
            if (start <= currentEnd + 1)
            {
                if (end > currentEnd)
                    currentEnd = end;
            }
            else
            {
                uniqueIds += (currentEnd - currentStart + 1);
                currentStart = start;
                currentEnd = end;
            }
        }
        uniqueIds += (currentEnd - currentStart + 1);

        return new(uniqueIds.ToString());
    }
}
