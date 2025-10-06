using FluentAssertions;
using NUnit.Framework;

public class Program
{
    public static void Main() {}
}

public class Solution
{
    public int MaxProduct(int[] arr)
    {
        var curMax = 1;
        var curMin = 1;
        var ans = arr[0];
        foreach (var n in arr)
        {
            var temp = curMax;
            curMax = Math.Max(curMax * n, Math.Max(curMin * n, n));
            curMin = Math.Min(temp * n, Math.Min(curMin * n, n));
            ans = Math.Max(ans, curMax);
        }

        return ans;
    }
}

[TestFixture]
public class Tests
{
    private static Solution s = new();

    [TestCase(new[] { 2, 3, -2, 4 }, 6)]
    [TestCase(new[] { -2, 0, -1 }, 0)]
    [TestCase(new[] { 5 }, 5)]
    [TestCase(new[] { 5, 1 }, 5)]
    [TestCase(new[] { 5, 0 }, 5)]
    [TestCase(new[] { 5, 0, 5 }, 5)]
    [TestCase(new[] { 5, 1, 5 }, 25)]
    [TestCase(new[] { 0, 2 }, 2)]
    [TestCase(new[] { -2, 3, -4 }, 24)]
    [TestCase(new[] { 3, -1, 4 }, 4)]
    [TestCase(new[] { 2, -5, -2, -4, 3 }, 24)]
    public static void Example(int[] arr, int expected)
    {
        var result = s.MaxProduct(arr);
        result.Should().Be(expected);
    }
}