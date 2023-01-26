using FluentAssertions;
using NUnit.Framework;

public class Program
{
    public static void Main() {}
}

public class Solution
{
    public int[] TwoSum(int[] numbers, int target)
    {
        var left = 0;
        var right = numbers.Length - 1;

        while (numbers[left] + numbers[right] != target)
        {
            var sum = numbers[left] + numbers[right];
            if (sum > target)
                right--;
            else
                left++;
        }

        return new[] { left + 1, right + 1 };
    }
}

[TestFixture]
public class Tests
{
    private static Solution s = new Solution();

    [TestCase(new[] { 2, 7, 11, 15 }, 9, new[] { 1, 2 })]
    [TestCase(new[] { 2, 3, 4 }, 6, new[] { 1, 3 })]
    public static void Example(int[] inp, int target, int[] expected)
    {
        var result = s.TwoSum(inp, target);
        result.Should().BeEquivalentTo(expected, opt => opt.WithStrictOrdering());
    }
}