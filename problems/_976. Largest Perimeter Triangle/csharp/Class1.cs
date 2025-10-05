using FluentAssertions;
using NUnit.Framework;

namespace _976._Largest_Perimeter_Triangle;

public class Program
{
    static void Main(string[] args) {}
}

public class Solution
{
    public int LargestPerimeter(int[] nums)
    {
        Array.Sort(nums);
        for (var i = nums.Length - 1; i > 1; i--)
            if (IsValidTriangle(nums[i], nums[i - 1], nums[i - 2]))
                return nums[i] + nums[i - 1] + nums[i - 2];
        return 0;
    }

    private bool IsValidTriangle(int a, int b, int c)
        => a < b + c;
}

[TestFixture]
public class Tests
{
    public static Solution s = new();

    [TestCase(new[] { 2, 1, 2 }, 5)]
    [TestCase(new[] { 1, 2, 1, 10 }, 0)]
    public static void Example1(int[] nums, int expected)
    {
        var result = s.LargestPerimeter(nums);
        result.Should().Be(expected);
    }
}