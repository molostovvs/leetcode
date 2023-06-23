using FluentAssertions;
using NUnit.Framework;

public class Program
{
    // public static void Main() {}
}

public class FirstSolution
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

//second attempt 5 min [O(n), O(1)]
public class SecondSolution
{
    public int MaxProfit(int[] prices)
    {
        var buy = prices[0];
        var res = 0;

        for (var i = 1; i < prices.Length; i++)
        {
            var sell = prices[i];
            res = Math.Max(res, sell - buy);

            if (sell < buy)
                buy = sell;
        }

        return res;
    }
}

//third attempt 10 min [O(n), O(n)]
public class Solution
{
    public int MaxProfit(int[] prices)
    {
        var stack = new Stack<int>();

        var min = prices[0];
        stack.Push(min);
        var profit = 0;

        for (var i = 1; i < prices.Length; i++)
        {
            var cur = prices[i];

            if (cur > min)
            {
                stack.Push(cur);
            }
            else
            {
                while (stack.Count > 0)
                {
                    var pop = stack.Pop();
                    if (pop - min > profit)
                        profit = pop - min;
                }

                min = cur;
            }
        }

        if (stack.Count != 0)
            return Math.Max(profit, stack.Max() - min);

        return profit;
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