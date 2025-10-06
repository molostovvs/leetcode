using FluentAssertions;
using NUnit.Framework;

public class Program
{
    public static void Main() {}
}

//first attempt 35 min [O(n), O(n)]
public class Solution
{
    public int MaxAreaOfIsland(int[][] grid)
    {
        var res = 0;

        var visited = new HashSet<(int R, int C)>();

        for (var r = 0; r < grid.GetLength(0); r++)
            for (var c = 0; c < grid[0].GetLength(0); c++)
                if (grid[r][c] == 1 && visited.Contains((r, c)) == false)
                {
                    Console.WriteLine($"started search from ${(r, c)}");
                    var area = GetAreaOfIsland((r, c), grid, visited);
                    res = area > res ? area : res;
                }

        return res;
    }

    private int GetAreaOfIsland((int R, int C) start, int[][] grid, HashSet<(int R, int C)> visited)
    {
        var area = 0;
        var q = new Queue<(int R, int C)>();
        q.Enqueue(start);

        while (q.Count > 0)
        {
            var cur = q.Dequeue();
            if (visited.Contains(cur))
                continue;
            visited.Add(cur);
            area++;

            foreach (var neighbor in GetNeighbors(cur, grid))
                if (!visited.Contains(neighbor))
                    q.Enqueue(neighbor);
        }

        return area;
    }

    private IEnumerable<(int R, int C)> GetNeighbors((int R, int C) start, int[][] grid)
    {
        var d = new[] { -1, 0, 1 };
        return d.SelectMany(r => d.Select(c => (start.R - r, start.C - c)))
                .Where(t => t.Item1 == start.R || t.Item2 == start.C)
                .Where(t => t.Item1 >= 0 && t.Item1 < grid.GetLength(0))
                .Where(t => t.Item2 >= 0 && t.Item2 < grid[0].GetLength(0))
                .Where(t => grid[t.Item1][t.Item2] == 1)
                .Where(t => t != start);
    }
}

//NEXT ATTEMPT SHOULD BE RECURSIVE

[TestFixture]
public class Tests
{
    private static Solution s = new();

    [Test]
    public static void SmallMap()
    {
        var island = new int[3][];
        island[0] = new[] { 0, 0, 0 };
        island[1] = new[] { 0, 1, 1 };
        island[2] = new[] { 0, 0, 1 };

        var result = s.MaxAreaOfIsland(island);
        result.Should().Be(3);
    }

    [Test]
    public static void BigMap()
    {
        var island = new int[8][];
        island[0] = new[] { 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 };
        island[1] = new[] { 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0 };
        island[2] = new[] { 0, 1, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0 };
        island[3] = new[] { 0, 1, 0, 0, 1, 1, 0, 0, 1, 0, 1, 0, 0 };
        island[4] = new[] { 0, 1, 0, 0, 1, 1, 0, 0, 1, 1, 1, 0, 0 };
        island[5] = new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0 };
        island[6] = new[] { 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0 };
        island[7] = new[] { 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0 };
        var result = s.MaxAreaOfIsland(island);
        result.Should().Be(6);
    }
}