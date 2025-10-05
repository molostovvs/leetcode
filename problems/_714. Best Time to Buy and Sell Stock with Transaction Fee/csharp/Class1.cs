using System.Collections;
using FluentAssertions;
using NUnit.Framework;

public class Program
{
    public static void Main() {}
}

//first attempt (spied) 60 min [o(n), O(n)] can be improved to O(1) space 
public class Solution
{
    public int MaxProfit(int[] prices, int fee)
    {
        var buy = new int[prices.Length];
        var sell = new int[prices.Length];

        buy[0] = -prices[0] - fee;

        for (var i = 1; i < prices.Length; i++)
        {
            buy[i] = Math.Max(buy[i - 1], sell[i - 1] - prices[i] - fee);
            sell[i] = Math.Max(sell[i - 1], buy[i - 1] + prices[i]);
        }

        return sell[prices.Length - 1];
    }
}

[TestFixture]
public class Tests
{
    private static Solution s = new();

    [TestCase(new[] { 1, 3, 7, 5, 10, 3 }, 3, 6)]
    [TestCase(new[] { 1, 3, 2, 8, 4, 9 }, 2, 8)]
    public static void Example(int[] arr, int fee, int expected)
    {
        var result = s.MaxProfit(arr, fee);
        result.Should().Be(expected);
    }
}