using FluentAssertions;
using NUnit.Framework;

public class Program
{
    public static void Main() {}
}

//googled [O(n), O(n + k)]
public class LinearSolution
{
    public int FindKthPositive(int[] arr, int k)
    {
        var x = Enumerable.Range(1, arr.Length + k).ToArray();
        for (var i = 0; i < x.Length; i++)
        {
            if (!arr.Contains(x[i]))
                k--;
            if (k == 0)
                return i + 1;
        }

        return int.MaxValue;
    }
}

//googled [O(log n), O(1)]
public class Solution
{
    public int FindKthPositive(int[] arr, int k)
    {
        var left = 0;
        var right = arr.Length;

        while (left < right)
        {
            var mid = left + (right - left) / 2;
            if (arr[mid] - 1 - mid < k)
                left = mid + 1;
            else
                right = mid;
        }

        return left + k;
    }
}

[TestFixture]
public class Tests
{
    private static Solution s = new Solution();

    [TestCase(new[] { 2, 3, 4, 7, 11 }, 5, 9)]
    [TestCase(new[] { 1, 2, 3, 4 }, 2, 6)]
    public static void Example(int[] arr, int k, int expected)
    {
        var result = s.FindKthPositive(arr, k);
        result.Should().Be(expected);
    }
}