using FluentAssertions;
using NUnit.Framework;

public class Program
{
    public static void Main() {}
}

//first attempt 100 min (spied) [O(n^2), O(n)]
public class SquareSolution
{
    public int MaxProfit(int[] prices)
    {
        var dp = new int[prices.Length];
        for (var i = 0; i < prices.Length; i++)
            if (i == 0)
            {
                dp[0] = 0;
            }
            else if (i == 1)
            {
                dp[1] = Math.Max(prices[1] - prices[0], 0);
            }
            else
            {
                dp[i] = dp[i - 1];
                // linear scan
                for (var j = 0; j < i; j++)
                {
                    var prev = j >= 2 ? dp[j - 2] : 0;
                    dp[i] = Math.Max(dp[i], prev + prices[i] - prices[j]);
                }
            }

        return dp[^1];
    }
}

//first attempt 100 min (spied) [O(n), O(n)]
public class Solution
{
    public int MaxProfit(int[] prices)
    {
        var dp = new int[prices.Length];
        var maxDiff = int.MinValue;

        for (var i = 0; i < prices.Length; i++)
        {
            if (i < 2)
                maxDiff = Math.Max(maxDiff, -prices[i]);
            if (i == 0)
            {
                dp[0] = 0;
            }
            else if (i == 1)
            {
                dp[1] = Math.Max(prices[1] - prices[0], 0);
            }
            else
            {
                dp[i] = Math.Max(dp[i - 1], maxDiff + prices[i]);
                maxDiff = Math.Max(maxDiff, dp[i - 2] - prices[i]);
            }
        }

        return dp[^1];
    }
}

[TestFixture]
public class Tests
{
    private static Solution s = new();

    [TestCase(new[] { 1, 2, 3, 0, 2 }, 3)]
    [TestCase(new[] { 1, 5, 100 }, 99)]
    [TestCase(new[] { 1, 100, 101 }, 100)]
    [TestCase(new[] { 1 }, 0)]
    [TestCase(new[] { 1, 4, 2 }, 3)]
    [TestCase(new[] { 2, 1 }, 0)]
    [TestCase(new[] { 6, 1, 3, 2, 4, 7 }, 6)]
    [TestCase(new[] { 1, 2, 4, 2, 5, 7, 2, 4, 9, 0 }, 11)]
    public static void Example(int[] inp, int expected)
    {
        var result = s.MaxProfit(inp);
        result.Should().Be(expected);
    }
}