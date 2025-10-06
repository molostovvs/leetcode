using FluentAssertions;
using NUnit.Framework;

public class Program
{
    public static void Main() {}
}

public class Solution
{
    public int MaxProfit(int[] prices)
    {
        var profit = 0;

        var buy = prices[0];

        foreach (var sell in prices)
        {
            if (sell > buy)
            {
                profit += sell - buy;
                buy = sell;
            }

            if (sell < buy)
                buy = sell;
        }

        return profit;
    }
}

[TestFixture]
public class Tests
{
    private static Solution s = new();

    [TestCase(new[] { 7, 1, 5, 3, 6, 4 }, 7)]
    [TestCase(new[] { 1, 2, 3, 4, 5 }, 4)]
    [TestCase(new[] { 7, 6, 4, 3, 1 }, 0)]
    public static void Example(int[] nums, int expected)
    {
        var result = s.MaxProfit(nums);
        result.Should().Be(expected);
    }
}