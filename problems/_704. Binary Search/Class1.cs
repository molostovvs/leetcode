using FluentAssertions;
using NUnit.Framework;

namespace _704._Binary_Search;

public class FirstSolution
{
    public int Search(int[] nums, int target)
    {
        var left = 0;
        var right = nums.Length - 1;
        while (left <= right)
        {
            var mid = (left + right) / 2;
            if (nums[mid] > target)
                right = mid - 1;
            else if (nums[mid] < target)
                left = mid + 1;
            else
                return mid;
        }

        return -1;
    }
}

public class Solution
{
    public int Search(int[] nums, int target)
    {
        int left = 0, right = nums.Length - 1;

        while (left < right)
        {
            var midIndex = (left + right) / 2;
            var mid = nums[midIndex];

            if (mid == target)
                return midIndex;

            if (mid < target)
                left = midIndex + 1;
            else
                right = midIndex;
        }

        return nums[left] == target ? left : -1;
    }
}

[TestFixture]
public class Tests
{
    private static Solution s = new();

    [TestCase(new[] { -1, 0, 5 }, 2, -1)]
    [TestCase(new[] { 1, 2 }, 2, 1)]
    [TestCase(new[] { 1, 2 }, 1, 0)]
    [TestCase(new[] { 1, 2, 3 }, 1, 0)]
    [TestCase(new[] { 1, 2, 3 }, 2, 1)]
    [TestCase(new[] { 1, 2, 3 }, 3, 2)]
    public static void Example(int[] inp, int target, int expected)
    {
        var result = s.Search(inp, target);
        result.Should().Be(expected);
    }
}