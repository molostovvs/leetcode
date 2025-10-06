using FluentAssertions;
using NUnit.Framework;

//first attempt 30 min (spied) [O(n^2), O(n)]
public class Solution
{
    public int LengthOfLIS(int[] nums)
    {
        var dp = Enumerable.Repeat(1, nums.Length).ToArray();

        for (var i = 0; i < nums.Length; i++)
            for (var j = 0; j < i; j++)
                if (nums[i] > nums[j] && dp[i] < dp[j] + 1)
                    dp[i] = dp[j] + 1;
        return dp.Max();
    }
}

[TestFixture]
public class Tests
{
    private static Solution s = new();

    [TestCase(new[] { 2, 5, 3, 7, 9, 8 }, 4)]
    [TestCase(new[] { 10, 9, 2, 5, 3, 7, 101, 18 }, 4)]
    [TestCase(new[] { 0, 1, 0, 3, 2, 3 }, 4)]
    [TestCase(new[] { 7, 7, 7, 7, 7, 7, 7 }, 1)]
    public static void Example(int[] arr, int expected)
    {
        var result = s.LengthOfLIS(arr);
        result.Should().Be(expected);
    }
}