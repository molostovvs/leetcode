using FluentAssertions;
using NUnit.Framework;

public class Program
{
    public static void Main() {}
}

//first attempt 40 min (googled) [O(n), O(1)]
public class Solution
{
    public int MaxDistance(int[] nums1, int[] nums2)
    {
        int i = 0, j = 0, distance = 0;

        while (i < nums1.Length && j < nums2.Length)
        {
            if (nums1[i] > nums2[j])
                i++;
            else
                distance = Math.Max(distance, j++ - i);
        }

        return distance;
    }
}

[TestFixture]
public class Tests
{
    private static Solution s = new();

    [TestCase(new[] { 55, 30, 5, 4, 2 }, new[] { 100, 20, 10, 10, 5 }, 2)]
    [TestCase(new[] { 2, 2, 2 }, new[] { 10, 10, 1 }, 1)]
    [TestCase(new[] { 30, 29, 19, 5 }, new[] { 25, 25, 25, 25, 25 }, 2)]
    [TestCase(new[] { 1 }, new[] { 100 }, 0)]
    [TestCase(new[] { 10, 9, 8 }, new[] { 100, 50, 40 }, 2)]
    [TestCase(
        new[] { 19, 18, 17, 17, 16, 16, 14, 14, 14 },
        new[] { 20, 20, 20, 18, 18, 16, 14, 14, 14, 14, 9, 8, 8 },
        3
    )]
    public static void Example(int[] nums1, int[] nums2, int expected)
    {
        var result = s.MaxDistance(nums1, nums2);
        result.Should().Be(expected);
    }
}