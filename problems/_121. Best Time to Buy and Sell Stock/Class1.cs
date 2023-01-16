using FluentAssertions;
using NUnit.Framework;

namespace _121._Best_Time_to_Buy_and_Sell_Stock;

public class Program
{
    public static void Main() {}
}

public class Solution
{
    public int MaxProfit(int[] prices)
    {
        /*(int Value, int Index) previousMin = (prices[0], 0); //my first solution - not elegant
        (int Value, int Index) currentMin = (prices[0], 0);
        (int Value, int Index) currentMax = (prices[0], 0);

        for (var i = 1; i < prices.Length; i++)
        {
            if (previousMin.Value > currentMin.Value && previousMin.Index < currentMax.Index)
                currentMin = previousMin;

            if (prices[i] - previousMin.Value > currentMax.Value - currentMin.Value)
            {
                currentMax = (prices[i], i);
                currentMin = previousMin;
            }

            if (prices[i] < previousMin.Value)
                previousMin = (prices[i], i);
        }

        return currentMax.Value - currentMin.Value;*/

        var minPrice = int.MaxValue;
        var maxProfit = 0;

        foreach (var price in prices)
        {
            minPrice = minPrice < price ? minPrice : price;
            var diff = price - minPrice;
            maxProfit = maxProfit > diff ? maxProfit : diff;
        }

        return maxProfit;
    }
}

[TestFixture]
public class Tests
{
    private static Solution s = new();

    [TestCase(new[] { 1 }, 0)]
    [TestCase(new[] { 1, 5 }, 4)]
    [TestCase(new[] { 1, 2, 3 }, 2)]
    [TestCase(new[] { 3, 2, 1 }, 0)]
    [TestCase(new[] { 7, 1, 5, 3, 6, 4 }, 5)]
    [TestCase(new[] { 7, 1, 5, 6 }, 5)]
    [TestCase(new[] { 7, 6, 4, 3, 1 }, 0)]
    public static void Example(int[] prices, int expected)
    {
        var result = s.MaxProfit(prices);
        result.Should().Be(expected);
    }

    [Test]
    public static void BigExample()
    {
        var prices = new int[100000000];
        var result = s.MaxProfit(prices);
        result.Should().Be(0);
    }
}