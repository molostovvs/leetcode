using FluentAssertions;
using NUnit.Framework;

public class Program
{
    public static void Main() {}
}

//first attempt 10 min [O(n), O(1)]
public class Solution
{
    public bool JudgeSquareSum(int c)
    {
        long left = 0;
        long right = (long)Math.Sqrt(c);

        while (left <= right)
        {
            var prod = left * left + right * right;
            if (prod == c)
                return true;

            if (prod > c)
                right--;
            else
                left++;
        }

        return false;
    }
}

[TestFixture]
public class Tests
{
    private static Solution s = new();

    [TestCase(5, true)]
    [TestCase(3, false)]
    [TestCase(17, true)]
    [TestCase(1, true)]
    [TestCase(1000000, true)]
    [TestCase(2147483600, true)]
    public static void Example(int i, bool expected)
    {
        var result = s.JudgeSquareSum(i);
        result.Should().Be(expected);
    }
}