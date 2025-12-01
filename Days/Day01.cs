namespace aoc_2025.Days;

public class Day01 : BaseDay
{
    private readonly string[] _lines;
    public Day01() => _lines = File.ReadAllLines(InputFilePath);

    public override ValueTask<string> Solve_1()
    {
        int dial = 50;
        int zeroes = 0;

        foreach (string line in _lines)
        {
            int clicks = int.Parse(line.AsSpan(1));
            int operation = line[0] == 'L' ? -clicks : clicks;

            dial = (dial + operation) % 100;
        
            if (dial < 0) 
                dial += 100;

            if (dial == 0)
                zeroes++;
        }
        return new(zeroes.ToString());
    }

    public override ValueTask<string> Solve_2()
    {
        int dial = 50;
        int zeroes = 0;

        foreach (string line in _lines)
        {
            char dir = line[0];
            int clicks = int.Parse(line.AsSpan(1));
            int start = dial;
            int first;

            if (dir == 'R')
            {
                first = (100 - start) % 100;
                if (first == 0) 
                    first = 100;
                dial = (start + clicks) % 100;
            }
            else
            {
                first = start % 100;
                if (first == 0) 
                    first = 100;
                dial = (start - clicks) % 100;
                if (dial < 0) 
                    dial += 100;
            }

            if (clicks >= first)
                zeroes += 1 + (clicks - first) / 100;
        }
        return new(zeroes.ToString());
    }
}


