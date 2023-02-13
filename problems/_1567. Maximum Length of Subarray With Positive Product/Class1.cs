using FluentAssertions;
using NUnit.Framework;

public class Program
{
    public static void Main() {}
}

public class Solution
{
    public int GetMaxLen(int[] nums)
    {
        var pos = 0;
        var neg = 0;

        var ans = 0;
        foreach (var n in nums)
        {
            if (n == 0)
            {
                pos = 0;
                neg = 0;
            }
            else if (n > 0)
            {
                pos++;
                neg = neg == 0 ? 0 : neg + 1;
            }
            else
            {
                var temp = pos;
                pos = neg == 0 ? 0 : neg + 1;
                neg = temp + 1;
            }

            ans = Math.Max(ans, pos);
        }

        return ans;
    }
}

[TestFixture]
public class Tests
{
    private static Solution s = new();

    [TestCase(new[] { 1, -2, -3, 4 }, 4)]
    [TestCase(new[] { 0, 1, -2, -3, -4 }, 3)]
    [TestCase(new[] { 0, -1, 0 }, 0)]
    [TestCase(new[] { 0, 1, 0 }, 1)]
    [TestCase(new[] { 0, 1, 1 }, 2)]
    [TestCase(new[] { 0, 1, -1 }, 1)]
    [TestCase(new[] { 0, 0, 0, 0 }, 0)]
    [TestCase(new[] { -1, -1, -1, -1 }, 4)]
    [TestCase(new[] { -1, -1, -1, 1 }, 3)]
    [TestCase(new[] { 1, 2, -6, 4 }, 2)]
    public static void Example(int[] nums, int expected)
    {
        var result = s.GetMaxLen(nums);
        result.Should().Be(expected);
    }
}