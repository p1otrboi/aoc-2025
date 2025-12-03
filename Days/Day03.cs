namespace aoc_2025.Days;

public sealed class Day03 : BaseDay
{
    private readonly string[] _lines;

    public Day03()
    {
        _lines = File.ReadAllLines(InputFilePath);
    }

    public override ValueTask<string> Solve_1()
    {
        int result = 0;

        foreach (var line in _lines)
            result += int.Parse(GetBest(line, 2));

        return new(result.ToString());
    }

    public override ValueTask<string> Solve_2()
    {
        long result = 0;

        foreach (var line in _lines)
            result += long.Parse(GetBest(line, 12));

        return new(result.ToString());
    }

    private static char[] GetBest(string line, int slots)
    {
        char[] arr = [.. line];
        var bestIndex = -1;
        List<char> best = [];
        while (slots-- > 0)
        {
            var length = arr.Length - slots;
            var subArr = arr[(bestIndex + 1)..length];
            var maxValue = subArr.Max();
            bestIndex = subArr.IndexOf(maxValue) + bestIndex + 1;
            best.Add(maxValue);
        }

        return [.. best];
    }
}
