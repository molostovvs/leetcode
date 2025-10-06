using FluentAssertions;
using NUnit.Framework;

public class Program
{
    public static void Main() {}
}

//first attempt (spied) 65 min [O(n), O(n)]
public class Solution
{
    public int Trap(int[] arr)
    {
        if (arr.Length <= 2)
            return 0;
        // pre-compute
        var leftMax = new int[arr.Length];
        var rightMax = new int[arr.Length];
        leftMax[0] = arr[0]; // init
        rightMax[^1] = arr[^1];

        for (int i = 1, j = 2; i < arr.Length; i++, j++)
        {
            leftMax[i] = Math.Max(leftMax[i - 1], arr[i]);
            rightMax[^j] = Math.Max(rightMax[^(j - 1)], arr[^j]);
        }

        var totalWater = 0;
        for (var k = 1; k < arr.Length - 1; ++k) // do not consider the first and the last places
        {
            var water = Math.Min(leftMax[k - 1], rightMax[k + 1]) - arr[k];
            totalWater += water > 0 ? water : 0;
        }

        return totalWater;
    }
}

[TestFixture]
public class Tests
{
    private static Solution s = new();

    [TestCase(new[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 }, 6)]
    public static void Example(int[] arr, int expected)
    {
        var result = s.Trap(arr);
        result.Should().Be(expected);
    }
}