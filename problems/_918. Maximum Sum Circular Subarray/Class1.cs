using FluentAssertions;
using NUnit.Framework;

public class Program
{
    public static void Main() {}
}

//first attempt (spied) 80 min [O(n), O(1)]
public class Solution
{
    public int MaxSubarraySumCircular(int[] arr)
    {
        int total = 0, maxSum = arr[0], curMax = 0, minSum = arr[0], curMin = 0;
        foreach (var n in arr)
        {
            curMax = Math.Max(curMax + n, n);
            maxSum = Math.Max(maxSum, curMax);
            curMin = Math.Min(curMin + n, n);
            minSum = Math.Min(minSum, curMin);
            total += n;
        }

        return maxSum > 0 ? Math.Max(maxSum, total - minSum) : maxSum;
    }
}

[TestFixture]
public class Tests
{
    private static Solution s = new();

    [TestCase(new[] { 5, -3, 5 }, 10)]
    [TestCase(new[] { 5, -1, 100, -1, 100, -1, 5 }, 208)]
    [TestCase(new[] { 2, -2, 2, 7, 8, 0 }, 19)]
    [TestCase(new[] { -3, -2, -3 }, -2)]
    public static void Example(int[] nums, int expected)
    {
        var result = s.MaxSubarraySumCircular(nums);
        result.Should().Be(expected);
    }
}