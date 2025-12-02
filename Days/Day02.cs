namespace aoc_2025.Days;

public sealed class Day02 : BaseDay
{
    private readonly IEnumerable<string[]> _lines;

    public Day02()
    {
        _lines = File.ReadAllText(InputFilePath).Split(',').Select(x => x.Split('-'));
    }

    public override ValueTask<string> Solve_1()
    {
        long sum = 0;

        foreach (var line in _lines)
        {
            var lo = long.Parse(line[0]);
            var hi = long.Parse(line[1]);

            for (long i = lo; i <= hi; i++)
            {
                var id = i.ToString();
                if (id.Length % 2 == 0)
                {
                    int mid  = id.Length / 2;
                    if (id[0..mid] == id[mid..])
                        sum += i;
                }
            }
        }
        return new(sum.ToString());
    }

    public override ValueTask<string> Solve_2()
    {
        long sum = 0;

        foreach (var line in _lines)
        {
            var lo = long.Parse(line[0]);
            var hi = long.Parse(line[1]);

            for (long i = lo; i <= hi; i++)
            {
                var id = i.ToString();

                for (int j = 1; j <= id.Length / 2; j++)
                {
                    var chunks = Enumerable.Range(0, id.Length / j).Select(c => id.Substring(c * j, j)).ToList();
                    if (chunks.All(x => x == chunks.First()) && id.Length == chunks.Count * chunks.First().Length)
                    {
                        sum += i;
                        break;
                    }
                }
            }
        }
        return new(sum.ToString());
    }
}
