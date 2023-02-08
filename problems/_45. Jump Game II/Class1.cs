using FluentAssertions;
using NUnit.Framework;

public class Program
{
    public static void Main() {}
}

//first attempt 32 min [O(n), O(1)]
public class Solution
{
    public int Jump(int[] nums)
    {
        var res = 0;

        for (var i = 0; i < nums.Length;)
        {
            if (i == nums.Length - 1)
                break;
            res++;
            if (i + nums[i] >= nums.Length - 1)
                break;
            i = GetIndexOfMaxElement(nums, i + 1, i + nums[i]);
        }

        return res;
    }

    public int GetIndexOfMaxElement(int[] arr, int start, int end)
    {
        (int Jump, int Index) t = (int.MinValue, start);
        for (; start <= end; start++)
            if (arr[start] + start >= t.Jump + t.Index)
            {
                t.Jump = arr[start];
                t.Index = start;
            }

        return t.Index;
    }
}

[TestFixture]
public class Tests
{
    private static Solution s = new();

    [TestCase(new[] { 2, 3, 1, 1, 4 }, 2)]
    [TestCase(new[] { 2, 3, 0, 1, 4 }, 2)]
    [TestCase(new[] { 2, 3, 0, 0, 0 }, 2)]
    [TestCase(new[] { 2, 1 }, 1)]
    [TestCase(new[] { 1, 1, 1, 1 }, 3)]
    [TestCase(new[] { 1, 2, 1, 1, 1 }, 3)]
    [TestCase(new[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 1, 0 }, 2)]
    public static void Example(int[] inp, int expected)
    {
        var result = s.Jump(inp);
        result.Should().Be(expected);
    }
}