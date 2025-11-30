namespace aoc_2025.Days;

public class Day01 : BaseDay
{
    private readonly string[] _lines;
    public Day01() => _lines = File.ReadAllLines(InputFilePath);

    public override ValueTask<string> Solve_1() => new($"Solution to {ClassPrefix} {CalculateIndex()}, part 1");

    public override ValueTask<string> Solve_2() => new($"Solution to {ClassPrefix} {CalculateIndex()}, part 2");
}