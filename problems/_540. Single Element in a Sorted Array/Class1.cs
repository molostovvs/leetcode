using FluentAssertions;
using NUnit.Framework;

public class Program
{
    public static void Main() {}
}

//first attempt 15 min [O(log n), O(1)]
public class FirstSolution
{
    public int SingleNonDuplicate(int[] nums)
    {
        var left = 0;
        var right = nums.Length - 1;

        while (left < right)
        {
            var mid = left + (right - left) / 2;

            if (mid == 0 || mid == nums.Length - 1)
                return nums[mid];

            if (mid % 2 != 0)
                if (nums[mid - 1] == nums[mid])
                    left = mid + 1;
                else if (nums[mid + 1] == nums[mid])
                    right = mid - 1;
                else
                    return nums[mid];
            else if (mid % 2 == 0)
                if (nums[mid - 1] == nums[mid])
                    right = mid - 1;
                else if (nums[mid + 1] == nums[mid])
                    left = mid + 1;
                else
                    return nums[mid];
        }

        return nums[left];
    }
}

//more clean but tricky solution
public class Solution
{
    public int SingleNonDuplicate(int[] nums)
    {
        var left = 0;
        var right = nums.Length - 1;

        while (left < right)
        {
            var mid = left + (right - left) / 2;
            if (mid % 2 != 0)
                mid--;
            if (nums[mid] != nums[mid + 1])
                right = mid;
            else
                left = mid + 2;
        }

        return nums[left];
    }
}

[TestFixture]
public class Tests
{
    private static Solution s = new();

    [TestCase(new[] { 1, 1, 2, 3, 3, 4, 4, 8, 8 }, 2)]
    [TestCase(new[] { 3, 3, 7, 7, 10, 11, 11 }, 10)]
    [TestCase(new[] { 2, 3, 3 }, 2)]
    [TestCase(new[] { 2, 3, 3, 5, 5 }, 2)]
    [TestCase(new[] { 2, 2, 3, 5, 5 }, 3)]
    [TestCase(new[] { 2, 2, 3, 3, 5 }, 5)]
    [TestCase(new[] { 1, 1, 5 }, 5)]
    [TestCase(new[] { 1, 1, 2, 2, 4, 4, 5 }, 5)]
    [TestCase(new[] { 0, 1, 1, 2, 2, 4, 4, 5, 5 }, 0)]
    public static void Example(int[] inp, int expected)
    {
        var result = s.SingleNonDuplicate(inp);
        result.Should().Be(expected);
    }
}