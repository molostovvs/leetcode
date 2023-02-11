using FluentAssertions;
using NUnit.Framework;

namespace _53._Maximum_Subarray;

public class Program
{
    static void Main(string[] args) {}
}

public class OldSolution
{
    public int MaxSubArray(int[] nums)
    {
        var maxSum = int.MinValue;

        var currentSum = 0;
        foreach (var n in nums)
        {
            currentSum += n;
            if (currentSum < n)
                currentSum = n;
            if (currentSum > maxSum)
                maxSum = currentSum;
        }

        return Math.Max(currentSum, maxSum);
    }
}

//second attempt 8 min [O(n), O(1)]
public class Solution
{
    public int MaxSubArray(int[] nums)
    {
        var max = int.MinValue;

        var curSum = 0;
        foreach (var n in nums)
        {
            curSum += n;

            if (n > curSum)
                curSum = n;

            if (curSum > max)
                max = curSum;
        }

        return max;
    }
}

public class Tests
{
    public static Solution s = new();

    [TestCase(new[] { 1 }, 1)]
    [TestCase(new[] { -1, 0, -2 }, 0)]
    [TestCase(new[] { 2, 1, -3 }, 3)]
    [TestCase(new[] { 100, 500 }, 600)]
    [TestCase(new[] { -1000, -100 }, -100)]
    [TestCase(new[] { 5, 4, -1, 7, 8 }, 23)]
    [TestCase(new[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 }, 6)]
    public static void ExampleTests(int[] nums, int expectedSum)
    {
        var result = s.MaxSubArray(nums);
        result.Should().Be(expectedSum);
    }
}