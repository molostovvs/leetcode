using FluentAssertions;
using NUnit.Framework;

public class Program
{
    static void Main(string[] args) {}
}

public class OldSolution
{
    // public int CountOdds(int low, int high)
    //     => Enumerable.Range(low, high - low + 1).Where(x => x % 2 != 0).Count();

    public int CountOdds(int low, int high)
    {
        var diff = high - low + 1;
        if (diff % 2 == 0)
            return diff / 2;
        if (low % 2 != 0)
            return diff / 2 + 1;
        return diff / 2;
    }
}

//second attempt 3 min [O(1), O(1)]
public class Solution
{
    public int CountOdds(int low, int high)
    {
        var res = high - low + 1;

        if (res % 2 == 0)
            return res / 2;

        return low % 2 == 0 ? res / 2 : res / 2 + 1;
    }
}

[TestFixture]
public class Tests
{
    private static Solution s = new();

    [TestCase(3, 7, 3)]
    [TestCase(8, 10, 1)]
    [TestCase(13, 20, 4)]
    [TestCase(11, 13, 2)]
    [TestCase(1, 3, 2)]
    [TestCase(1, 4, 2)]
    [TestCase(2, 5, 2)]
    public static void Example(int low, int high, int expected)
    {
        var result = s.CountOdds(low, high);
        result.Should().Be(expected);
    }
}