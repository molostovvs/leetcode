using FluentAssertions;
using NUnit.Framework;

public class Program
{
    public static void Main() {}
}

//first attempt 30 min [O(m*n), O(m*n)]
public class FirstSolution
{
    public int MinimumTotal(IList<IList<int>> triangle)
    {
        var list = new int[triangle.Count][];
        list[0] = new[] { triangle[0][0] };

        for (var row = 1; row < triangle.Count; row++)
        {
            list[row] = new int[row + 1];
            for (var col = 0; col < list[row].Length; col++)
                if (col == 0)
                    list[row][col] = list[row - 1][col] + triangle[row][col];
                else if (col == list[row].Length - 1)
                    list[row][col] = list[row - 1][col - 1] + triangle[row][col];
                else
                    list[row][col] = Math.Min(list[row - 1][col], list[row - 1][col - 1]) + triangle[row][col];
        }

        return list[^1].Min();
    }
}

//Top-down recursive solution [O(m*n), O(stack)] TLE
public class RecursiveSolution
{
    public int MinimumTotal(IList<IList<int>> triangle, int row = 0, int col = 0, int res = 0)
    {
        var cur = triangle[row][col];
        if (row == triangle.Count - 1)
            return res + cur;

        return Math.Min(
            MinimumTotal(triangle, row + 1, col, res + cur),
            MinimumTotal(triangle, row + 1, col + 1, res + cur)
        );
    }
}

//bottom-up solution (spied)
public class Solution
{
    public int MinimumTotal(IList<IList<int>> triangle)
    {
        for (var row = triangle.Count - 2; row >= 0; row--)
            for (var col = 0; col < row; col++)
                triangle[row][col] += Math.Min(triangle[row + 1][col], triangle[row][col + 1]);

        return triangle[0][0];
    }
}

[TestFixture]
public class Tests
{
    private static Solution s = new();

    [Test]
    public static void Example()
    {
        var inp = new List<IList<int>>
        {
            new List<int> { -10 },
        };

        var result = s.MinimumTotal(inp);
        result.Should().Be(-10);
    }

    [Test]
    public static void Example1()
    {
        var inp = new List<IList<int>>
        {
            new List<int> { 2 },
            new List<int> { 3, 4 },
            new List<int> { 6, 5, 7 },
            new List<int> { 4, 1, 8, 3 },
        };

        var result = s.MinimumTotal(inp);
        result.Should().Be(11);
    }

    [Test]
    public static void Example2()
    {
        var inp = new List<IList<int>>
        {
            new List<int> { -1 },
            new List<int> { 2, 3 },
            new List<int> { 1, -1, -3 },
        };

        var result = s.MinimumTotal(inp);
        result.Should().Be(-1);
    }
}