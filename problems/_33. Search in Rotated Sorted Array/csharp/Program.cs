using FluentAssertions;
using NUnit.Framework;

public class Program
{
    public static void Main() {}
}

//googled 50 min [O(log n), O(1)]
public class Solution
{
    public int Search(int[] arr, int target)
    {
        var left = 0;
        var right = arr.Length - 1;

        while (left < right)
        {
            var mid = left + (right - left) / 2;
            if (arr[mid] > arr[right])
                left = mid + 1;
            else
                right = mid;
        }

        var smallest = left;

        left = 0;
        right = arr.Length - 1;

        while (left <= right)
        {
            var mid = left + (right - left) / 2;
            var realMid = (mid + smallest) % arr.Length;
            if (arr[realMid] == target)
                return realMid;

            if (arr[realMid] < target)
                left = mid + 1;
            else
                right = mid - 1;
        }

        return -1;
    }
}

[TestFixture]
public class Tests
{
    private static Solution s = new();

    [TestCase(new[] { 4, 5, 6, 7, 0, 1, 2 }, 0, 4)]
    [TestCase(new[] { 3, 5, 1 }, 3, 0)]
    [TestCase(new[] { 5, 1, 3 }, 5, 0)]
    [TestCase(new[] { 0, 1, 2, 4, 5, 6, 7 }, 0, 0)]
    [TestCase(new[] { 0, 1, 2, 4, 5, 6, 7 }, 7, 6)]
    [TestCase(new[] { 0, 1, 2, 4, 5, 6, 7 }, 8, -1)]
    [TestCase(new[] { 0, 1, 2, 4, 5, 6, 7 }, -1, -1)]
    public static void Example(int[] arr, int target, int expected)
    {
        var result = s.Search(arr, target);
        result.Should().Be(expected);
    }
}