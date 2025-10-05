using System.Numerics;
using FluentAssertions;
using NUnit.Framework;

public class Program
{
    public static void Main() {}
}

public class Solution
{
    public int[] SortByBits(int[] arr)
        => arr.OrderBy(x => (BitOperations.PopCount((uint)x), x)).ToArray();
}

// handwritten PopCount
public static class IntExtensions
{
    public static int NumborOf1Bits(this int n)
    {
        var res = 0;
        while (n > 0)
        {
            n = (n - 1) & n;
            res++;
        }

        return res;
    }
}

[TestFixture]
public class Tests
{
    private static Solution s = new();

    [TestCase(new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 }, new[] { 0, 1, 2, 4, 8, 3, 5, 6, 7 })]
    public static void Example(int[] arr, int[] expected)
    {
        var result = s.SortByBits(arr);
        result.Should().BeEquivalentTo(expected, opt => opt.WithStrictOrdering());
    }

    [TestCase(0, 0)]
    [TestCase(1, 1)]
    [TestCase(2, 1)]
    [TestCase(4, 1)]
    [TestCase(8, 1)]
    [TestCase(7, 3)]
    [TestCase(3, 2)]
    [TestCase(5, 2)]
    [TestCase(6, 2)]
    public static void BitsTest(int inp, int expected)
    {
        var res = inp.NumborOf1Bits();
        res.Should().Be(expected);
    }
}