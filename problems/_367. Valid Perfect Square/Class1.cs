using FluentAssertions;
using NUnit.Framework;

public class Program
{
    public static void Main() {}
}

public class Solution
{
    public bool IsPerfectSquare(int num)
    {
        long left = 1;
        var right = Math.Min(num, uint.MaxValue);

        while (left <= right)
        {
            if (left == right)
                return left * right == num;

            var mid = left + (right - left) / 2;
            if (mid * mid == num)
                return true;

            if (mid * mid > num)
                right = mid - 1;
            if (mid * mid < num)
                left = mid + 1;
        }

        return false;
    }
}

[TestFixture]
public class Tests
{
    private static Solution s = new Solution();

    [TestCase(808201, true)]
    [TestCase(16, true)]
    [TestCase(15, false)]
    [TestCase(25, true)]
    [TestCase(24, false)]
    [TestCase(36, true)]
    [TestCase(49, true)]
    [TestCase(64, true)]
    [TestCase(81, true)]
    [TestCase(80, false)]
    [TestCase(100, true)]
    [TestCase(101, false)]
    [TestCase(9, true)]
    [TestCase(4, true)]
    [TestCase(2, false)]
    [TestCase(1, true)]
    [TestCase(598, false)]
    [TestCase(2147395600, true)]
    public static void Example(int n, bool expected)
    {
        var result = s.IsPerfectSquare(n);
        result.Should().Be(expected);
    }
}