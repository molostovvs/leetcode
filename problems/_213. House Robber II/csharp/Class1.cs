using FluentAssertions;
using NUnit.Framework;

public class Program
{
    public static void Main() {}
}

public class Solution
{
    public int Rob(int[] nums)
    {
        var prepre = 0;
        var pre = 0;

        if (nums.Length == 1)
            return nums[0];

        for (var i = 0; i < nums.Length - 1; i++)
        {
            var cur = Math.Max(pre, prepre + nums[i]);

            prepre = pre;
            pre = cur;
        }

        var res = pre;

        pre = 0;
        prepre = 0;

        for (var i = 1; i < nums.Length; i++)
        {
            var cur = Math.Max(pre, prepre + nums[i]);
            prepre = pre;
            pre = cur;
        }

        return Math.Max(res, pre);
    }
}

[TestFixture]
public class Tests
{
    private static Solution s = new();

    [TestCase(new[] { 2, 3, 2 }, 3)]
    [TestCase(new[] { 1, 2, 3, 1 }, 4)]
    [TestCase(new[] { 1, 2, 3 }, 3)]
    [TestCase(new[] { 5, 1, 2 }, 5)]
    [TestCase(new[] { 1, 2, 1, 1 }, 3)]
    [TestCase(new[] { 2, 1, 1, 2 }, 3)]
    [TestCase(new[] { 1, 3, 1, 3, 100 }, 103)]
    [TestCase(new[] { 1 }, 1)]
    public static void Example(int[] nums, int expected)
    {
        var result = s.Rob(nums);
        result.Should().Be(expected);
    }
}