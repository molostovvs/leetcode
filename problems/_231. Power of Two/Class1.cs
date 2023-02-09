using FluentAssertions;
using NUnit.Framework;

public class Program
{
    public static void Main() {}
}

//first attempt bit manipulation iterative 10 min [O(log n), O(1)]
public class IterativeSolution
{
    public bool IsPowerOfTwo(int n)
    {
        while (n > 0)
        {
            if (n == 1)
                return true;
            if (n % 2 != 0)
                return false;
            n >>= 1;
        }

        return false;
    }
}

//recursive spied solution [O(log n), O(log n)]
public class RecursiveSolution
{
    public bool IsPowerOfTwo(int n)
    {
        if (n <= 0)
            return false;
        if (n == 1)
            return true;
        return n % 2 == 0 && IsPowerOfTwo(n / 2);
    }
}

//smart bit manipulation [O(1), O(1)]
public class Solution
{
    public bool IsPowerOfTwo(int n)
        => n > 0 && (n & (n - 1)) == 0;
}

[TestFixture]
public class Tests
{
    private static Solution s = new();

    [TestCase(1, true)]
    [TestCase(2, true)]
    [TestCase(4, true)]
    [TestCase(8, true)]
    [TestCase(16, true)]
    [TestCase(32, true)]
    [TestCase(64, true)]
    [TestCase(128, true)]
    [TestCase(256, true)]
    [TestCase(512, true)]
    [TestCase(1024, true)]
    [TestCase(1023, false)]
    [TestCase(3, false)]
    [TestCase(7, false)]
    [TestCase(9, false)]
    [TestCase(15, false)]
    [TestCase(17, false)]
    public static void Example(int n, bool expected)
    {
        var result = s.IsPowerOfTwo(n);
        result.Should().Be(expected);
    }
}