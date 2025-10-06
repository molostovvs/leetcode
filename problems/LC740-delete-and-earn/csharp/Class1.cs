using FluentAssertions;
using NUnit.Framework;

public class Program
{
    public static void Main() {}
}

public class Solution
{
    public int DeleteAndEarn(int[] nums)
    {
        var buckets = new int[10001];
        foreach (var n in nums)
            buckets[n] += n;

        var take = 0;
        var skip = 0;

        foreach (var b in buckets)
        {
            var takeCur = skip + b;
            var skipCur = Math.Max(skip, take);
            take = takeCur;
            skip = skipCur;
        }

        return Math.Max(take, skip);
    }
}

[TestFixture]
public class Tests
{
    private static Solution s = new();

    [TestCase(new[] { 3, 1 }, 4)]
    [TestCase(new[] { 3, 4, 2 }, 6)]
    [TestCase(new[] { 2, 2, 3, 3, 3, 4 }, 9)]
    [TestCase(new[] { 1, 1, 1, 2, 4, 5, 5, 5, 6 }, 18)]
    public static void Example(int[] nums, int expected)
    {
        var result = s.DeleteAndEarn(nums);
        result.Should().Be(expected);
    }
}