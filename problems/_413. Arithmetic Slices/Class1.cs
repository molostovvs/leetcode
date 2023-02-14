using FluentAssertions;
using NUnit.Framework;

public class Program
{
    public static void Main() {}
}

//first attempt 8 min [O(n^2), O(1)]
public class NaiveSolution
{
    public int NumberOfArithmeticSlices(int[] arr)
    {
        var count = 0;

        for (var start = 0; start < arr.Length; start++)
        {
            var diff = int.MinValue;
            var subArrayCount = 1;
            for (var end = start + 1; end < arr.Length; end++)
            {
                if (end == start + 1)
                    diff = arr[end] - arr[start];

                var cur = arr[end];
                var prev = arr[end - 1];
                if (cur - prev == diff)
                {
                    subArrayCount++;
                    if (subArrayCount >= 3)
                        count++;
                }
                else
                {
                    break;
                }
            }
        }

        return count;
    }
}

//first attempt linear (spied) [O(n), O(n)]
public class LinearSolution
{
    public int NumberOfArithmeticSlices(int[] arr)
    {
        var dp = new int[arr.Length];

        for (var i = 2; i < arr.Length; i++)
            if (arr[i - 1] - arr[i - 2] == arr[i] - arr[i - 1])
                dp[i] = dp[i - 1] + 1;

        return dp.Sum();
    }
}

//first attempt linear (spied) memory optimized [O(n), O(1)]
public class Solution
{
    public int NumberOfArithmeticSlices(int[] arr)
    {
        var res = 0;
        var dp = 0;

        for (var i = 2; i < arr.Length; i++)
            if (arr[i - 1] - arr[i - 2] == arr[i] - arr[i - 1])
                res += ++dp;
            else
                dp = 0;

        return res;
    }
}

[TestFixture]
public class Tests
{
    private static Solution s = new();

    [TestCase(new[] { 1, 2, 3, 4 }, 3)]
    [TestCase(new[] { 1, 2, 3, 4, 5 }, 6)]
    [TestCase(new[] { 1, 2, 3, 8, 9, 10 }, 2)]
    [TestCase(new[] { 1 }, 0)]
    public static void Example(int[] arr, int expected)
    {
        var result = s.NumberOfArithmeticSlices(arr);
        result.Should().Be(expected);
    }
}