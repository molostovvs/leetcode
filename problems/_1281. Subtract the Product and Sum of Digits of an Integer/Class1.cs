using FluentAssertions;
using NUnit.Framework;

namespace _1281._Subtract_the_Product_and_Sum_of_Digits_of_an_Integer;

public class Program
{
    static void Main(string[] args) {}
}

public class Solution
{
    public int SubtractProductAndSum(int n)
    {
        var digits = n.GetAllDigits();
        var product = 1;
        foreach (var i in digits)
            product *= i;
        var sum = digits.Sum();
        return product - sum;
    }
}

public static class IntExtensions
{
    public static int[] GetAllDigits(this int n)
    {
        var result = new int[n.GetNumberOfDigits()];
        for (var i = 0; i < result.Length; i++)
        {
            result[i] = n % 10;
            n = n / 10;
        }

        result.Reverse();
        return result;
    }

    public static int GetNumberOfDigits(this int n)
    {
        if (n == 0)
            return 1;
        var count = 0;
        while (n != 0)
        {
            count++;
            n = n / 10;
        }

        return count;
    }
}

[TestFixture]
public class Tests
{
    public static Solution s = new();

    [TestCase(1, 1)]
    [TestCase(0, 1)]
    [TestCase(15, 2)]
    [TestCase(15, 2)]
    [TestCase(123, 3)]
    [TestCase(6666, 4)]
    public static void DigitsTest(int input, int expected)
    {
        var result = input.GetNumberOfDigits();
        result.Should().Be(expected);
    }

    [TestCase(0, new[] { 0 })]
    [TestCase(24, new[] { 2, 4 })]
    [TestCase(123, new[] { 1, 2, 3 })]
    public static void GetDigitsTest(int input, int[] expected)
    {
        var result = input.GetAllDigits();
        result.Should().BeEquivalentTo(expected);
    }
}