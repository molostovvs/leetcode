using FluentAssertions;
using NUnit.Framework;

public class Program
{
    public static void Main() {}
}

//first attempt 18 min [O(log n), O(1)]
public class Solution
{
    public int[] SearchRange(int[] nums, int target)
    {
        var left = 0;
        var right = nums.Length - 1;

        while (left <= right)
        {
            var mid = left + (right - left) / 2;
            if (nums[mid] >= target)
                right = mid - 1;
            else
                left = mid + 1;
        }

        var leftRes = left > nums.Length - 1 ? nums.Length - 1 : left;
        left = 0;
        right = nums.Length - 1;

        while (left <= right)
        {
            var mid = left + (right - left) / 2;
            if (nums[mid] <= target)
                left = mid + 1;
            else
                right = mid - 1;
        }

        var rightRes = left - 1;

        if (nums.Length == 0 || nums[leftRes] != target || nums[rightRes] != target)
            return new[] { -1, -1 };
        return new[] { leftRes, rightRes };
    }
}

[TestFixture]
public class Tests
{
    private static Solution s = new Solution();

    [TestCase(new[] { 1, 3, 3, 4 }, 3, new[] { 1, 2 })]
    [TestCase(new[] { 2, 2 }, 3, new[] { -1, -1 })]
    [TestCase(new[] { 5, 7, 7, 8, 8, 10 }, 8, new[] { 3, 4 })]
    [TestCase(new[] { 5, 7, 7, 8, 8, 10 }, 6, new[] { -1, -1 })]
    [TestCase(new int[0], 0, new[] { -1, -1 })]
    public static void Example(int[] nums, int target, int[] expected)
    {
        var result = s.SearchRange(nums, target);
        result.Should().BeEquivalentTo(expected, opt => opt.WithStrictOrdering());
    }
}