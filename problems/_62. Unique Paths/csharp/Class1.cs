using FluentAssertions;
using NUnit.Framework;

namespace _62._Unique_Paths;

public class Program
{
    public static void Main() {}
}

/*//slow solution [O(2^n?), O(h)]
public class Solution
{
    public int UniquePaths(int m, int n, (int x, int y) cur = default)
    {
        var paths = 0;
        if (cur.x == n - 1 && cur.y == m - 1)
            return 1;

        if (cur.x < n - 1)
            paths += UniquePaths(m, n, (cur.x + 1, cur.y));
        if (cur.y < m - 1)
            paths += UniquePaths(m, n, (cur.x, cur.y + 1));
        return paths;
    }
}*/

public class Solution
{
    public int UniquePaths(int m, int n)
    {
        var dp = new int[m + 1, n + 1];
        dp[0, 1] = 1;
        for (var r = 1; r < m + 1; r++)
        {
            for (var c = 1; c < n + 1; c++)
                dp[r, c] = dp[r - 1, c] + dp[r, c - 1];
        }

        return dp[m, n];
    }
}

[TestFixture]
public class Tests
{
    private static Solution s = new();

    [TestCase(1, 1, 1)]
    [TestCase(3, 2, 3)]
    [TestCase(2, 2, 2)]
    [TestCase(3, 7, 28)]
    public static void Example(int m, int n, int expected)
    {
        var result = s.UniquePaths(m, n);
        result.Should().Be(expected);
    }
}