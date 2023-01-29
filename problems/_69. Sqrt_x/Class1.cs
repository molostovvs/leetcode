using NUnit.Framework;

public class Program
{
    public static void Main() {}
}

//first attempt [O(n), O(1)]
public class MySolution
{
    public int MySqrt(int x)
    {
        var left = 0d;
        if (x == 1)
            return 1;
        var right = (double)x;

        while (left <= right)
        {
            var mid = left + (right - left) / 2;
            var sqr = mid * mid;
            if (Math.Abs(sqr - x) < 10e-3)
                return (int)mid;
            if (sqr < x)
                left = mid;
            else
                right = mid;
        }

        return (int)left;
    }
}

//second attempt [O(x), O(1)]
public class Solution
{
    public int MySqrt(int x)
    {
        var left = 0;
        var right = x;

        while (left <= right)
        {
            long mid = left + (right - left) / 2;
            long sqr = mid * mid;
            if (sqr == x)
                return (int)mid;
            if (sqr < x)
                left = (int)mid + 1;
            else
                right = (int)mid - 1;
        }

        return right;
    }
}

[TestFixture]
public class Tests
{
    private static Solution s = new Solution();

    [TestCase(0, 0)]
    [TestCase(1, 1)]
    [TestCase(4, 2)]
    [TestCase(8, 2)]
    [TestCase(9, 3)]
    [TestCase(14, 3)]
    [TestCase(16, 4)]
    [TestCase(21, 4)]
    [TestCase(81, 9)]
    [TestCase(99, 9)]
    [TestCase(1024, 32)]
    [TestCase(2147395599, 46339)]
    public static void Example(int x, int expected)
    {
        var result = s.MySqrt(x);
        result.Should().Be(expected);
    }
}