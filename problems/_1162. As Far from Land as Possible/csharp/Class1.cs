using FluentAssertions;
using NUnit.Framework;

public class Program
{
    public static void Main() {}
}

//first attempt (spied) 90 min [O(r*c), O(r*c)]
public class FirstSolution
{
    public int MaxDistance(int[][] grid)
    {
        var rows = grid.GetLength(0);
        var cols = grid[0].GetLength(0);

        var maxDist = rows + cols + 1;
        var dp = new int[rows, cols];
        for (var r = 0; r < rows; r++)
            for (var c = 0; c < cols; c++)
                dp[r, c] = maxDist;

        for (var r = 0; r < rows; r++)
            for (var c = 0; c < cols; c++)
                if (grid[r][c] == 1) //if land
                    dp[r, c] = 0;
                else
                    dp[r, c] = Math.Min(
                        dp[r, c],
                        Math.Min(r > 0 ? dp[r - 1, c] + 1 : maxDist, c > 0 ? dp[r, c - 1] + 1 : maxDist)
                    );

        var res = int.MinValue;

        for (var r = rows - 1; r >= 0; r--)
            for (var c = cols - 1; c >= 0; c--)
            {
                dp[r, c] = Math.Min(
                    dp[r, c],
                    Math.Min(r < rows - 1 ? dp[r + 1, c] + 1 : maxDist, c < cols - 1 ? dp[r, c + 1] + 1 : maxDist)
                );

                res = Math.Max(res, dp[r, c]);
            }

        return res == 0 || res == maxDist ? -1 : res;
    }
}

//first attempt in-place DP (spied) 10 min [O(r*c), O(1)]
public class SecondSolution
{
    public int MaxDistance(int[][] grid)
    {
        var rows = grid.GetLength(0);
        var cols = grid[0].GetLength(0);

        var maxDist = rows + cols + 1;

        for (var r = 0; r < rows; r++)
            for (var c = 0; c < cols; c++)
                if (grid[r][c] == 1) //if land
                {
                    grid[r][c] = 0;
                }
                else
                {
                    grid[r][c] = maxDist;
                    grid[r][c] = Math.Min(
                        grid[r][c],
                        Math.Min(r > 0 ? grid[r - 1][c] + 1 : maxDist, c > 0 ? grid[r][c - 1] + 1 : maxDist)
                    );
                }

        var res = int.MinValue;

        for (var r = rows - 1; r >= 0; r--)
            for (var c = cols - 1; c >= 0; c--)
            {
                grid[r][c] = Math.Min(
                    grid[r][c],
                    Math.Min(r < rows - 1 ? grid[r + 1][c] + 1 : maxDist, c < cols - 1 ? grid[r][c + 1] + 1 : maxDist)
                );

                res = Math.Max(res, grid[r][c]);
            }

        return res == 0 || res == maxDist ? -1 : res;
    }
}

//first attempt Multi-source BFS (spied) 20 min [o(r*c), O(r*c)]
public class Solution
{
    public int MaxDistance(int[][] grid)
    {
        var rows = grid.GetLength(0);
        var cols = grid[0].GetLength(0);
        var q = new Queue<(int R, int C)>();
        var visited = new HashSet<(int R, int C)>();

        for (var r = 0; r < rows; r++)
            for (var c = 0; c < cols; c++)
                if (grid[r][c] == 1)
                    q.Enqueue((r, c));

        if (q.Count == 0 || q.Count == rows * cols)
            return -1;

        var res = 0;
        while (q.Count > 0)
        {
            if (visited.Count == rows * cols)
                break;

            var curCount = q.Count;
            while (curCount > 0)
            {
                var cur = q.Dequeue();
                visited.Add(cur);
                foreach (var neighbor in GetNeighbors(cur, grid))
                    if (!visited.Contains(neighbor))
                    {
                        q.Enqueue(neighbor);
                        visited.Add(neighbor);
                    }

                curCount--;
            }

            res++;
        }

        return res;
    }

    private IEnumerable<(int R, int C)> GetNeighbors((int R, int C) cur, int[][] grid)
    {
        var d = new[] { -1, 0, 1 };
        return d.SelectMany(r => d.Select(c => (R: cur.R - r, C: cur.C - c)))
                .Where(t => t != cur)
                .Where(t => t.R == cur.R || t.C == cur.C)
                .Where(t => t.R >= 0 && t.R <= grid.GetLength(0) - 1)
                .Where(t => t.C >= 0 && t.C <= grid[0].GetLength(0) - 1);
    }
}

[TestFixture]
public class Tests
{
    private static Solution s = new();

    [Test]
    public static void Example0()
    {
        var grid = new[]
        {
            new[] { 1, 0 },
            new[] { 0, 0 },
        };
        var result = s.MaxDistance(grid);
        result.Should().Be(2);
    }

    [Test]
    public static void Example()
    {
        var grid = new[]
        {
            new[] { 1, 0, 1 },
            new[] { 0, 0, 0 },
            new[] { 1, 0, 1 },
        };
        var result = s.MaxDistance(grid);
        result.Should().Be(2);
    }

    [Test]
    public static void Example1()
    {
        var grid = new[]
        {
            new[] { 0, 0, 0 },
            new[] { 0, 0, 0 },
            new[] { 0, 0, 1 },
        };
        var result = s.MaxDistance(grid);
        result.Should().Be(4);
    }

    [Test]
    public static void Example2()
    {
        var grid = new[]
        {
            new[] { 1, 0, 0 },
            new[] { 0, 0, 0 },
            new[] { 0, 0, 0 },
        };
        var result = s.MaxDistance(grid);
        result.Should().Be(4);
    }

    [Test]
    public static void Example3()
    {
        var grid = new[]
        {
            new[] { 0, 0, 0, 0 },
            new[] { 0, 0, 0, 0 },
            new[] { 0, 0, 0, 0 },
            new[] { 0, 0, 0, 0 },
        };
        var result = s.MaxDistance(grid);
        result.Should().Be(-1);
    }

    [Test]
    public static void Example4()
    {
        var grid = new[]
        {
            new[] { 0, 0 },
            new[] { 0, 0 },
        };
        var result = s.MaxDistance(grid);
        result.Should().Be(-1);
    }
}