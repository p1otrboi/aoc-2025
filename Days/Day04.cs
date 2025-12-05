namespace aoc_2025.Days;

public sealed class Day04 : BaseDay
{
    private readonly char[][] _matrix;

    public Day04()
    {
        _matrix = [.. File.ReadAllLines(InputFilePath).Select(l => l.ToCharArray())];
    }

    public override ValueTask<string> Solve_1()
    {
        int accessCount = 0;

        for (int i = 0; i < _matrix.Length; i++)
        {
            for (int j = 0; j < _matrix[i].Length; j++)
            {
                if (_matrix[i][j] == '@')
                    if (CheckAccess(i, j))
                        accessCount++;
            }
        }

        return new(accessCount.ToString());
    }


    public override ValueTask<string> Solve_2()
    {
        int totalRemoved = 0;

        for (int i = 0; i < _matrix.Length; i++)
        {
            for (int j = 0; j < _matrix[i].Length; j++)
            {
                if (_matrix[i][j] == '@')
                {
                    if (CheckAccess(i, j))
                    {
                        _matrix[i][j] = 'x';
                        j = 0;
                        i = 0;
                        totalRemoved++;
                    }
                }
            }
        }
        return new(totalRemoved.ToString());
    }

    public bool CheckAccess(int pointY, int pointX)
    {
        int neighbors = 0;

        // array bounds
        int left = Math.Max(pointX - 1, 0);
        int right = Math.Min(pointX + 1, _matrix[0].Length - 1);
        int top = Math.Max(pointY - 1, 0);
        int bottom = Math.Min(pointY + 1, _matrix.Length - 1);

        for (int y = top; y <= bottom; y++)
        {
            for (int x = left; x <= right; x++)
            {
                if (y == pointY && x == pointX)
                    continue;
                if (_matrix[y][x] == '@')
                    neighbors++;
            }
        }
        return neighbors < 4;
    }
}
