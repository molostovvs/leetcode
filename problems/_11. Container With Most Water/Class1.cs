using FluentAssertions;
using NUnit.Framework;

public class Program
{
    public static void Main() {}
}

public class NaiveSolution
{
    public int MaxArea(int[] height)
    {
        var res = int.MinValue;

        for (var i = 0; i < height.Length - 1; i++)
        {
            for (var j = i + 1; j < height.Length; j++)
            {
                var curArea = (j - i) * Math.Min(height[i], height[j]);
                res = curArea > res ? curArea : res;
            }
        }

        return res;
    }
}

// [O(n), O(1)]
public class Solution
{
    public int MaxArea(int[] height)
    {
        var res = int.MinValue;

        var left = 0;
        var right = height.Length - 1;

        while (left < right)
        {
            var curArea = (right - left) * Math.Min(height[left], height[right]);
            res = curArea > res ? curArea : res;

            if (height[left] < height[right])
                left++;
            else
                right--;
        }

        return res;
    }
}

[TestFixture]
public class Tests
{
    private static Solution s = new Solution();

    [TestCase(new[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 }, 49)]
    public static void Example(int[] inp, int expected)
    {
        var result = s.MaxArea(inp);
        result.Should().Be(expected);
    }
}