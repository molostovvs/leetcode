using FluentAssertions;
using NUnit.Framework;

public class Program
{
    public static void Main() {}
}

//first attempt 15 min [O(n), O(1)]
public class Solution
{
    public IList<int> AddToArrayForm(int[] num, int k)
    {
        var res = new List<int>();
        var overhead = 0;

        for (var i = 1; i <= num.Length; i++)
        {
            var curDigit = num[^i];
            var lastDigit = k % 10;
            k /= 10;

            res.Add((curDigit + lastDigit + overhead) % 10);
            overhead = (curDigit + lastDigit + overhead) / 10;
        }

        while (k > 0)
        {
            var lastDigit = k % 10;
            k /= 10;
            res.Add((lastDigit + overhead) % 10);
            overhead = (lastDigit + overhead) / 10;
        }

        if (overhead != 0)
            res.Add(overhead);

        res.Reverse();
        return res;
    }
}

[TestFixture]
public class Tests
{
    private static Solution s = new();

    [TestCase(new[] { 9, 9, 9 }, 99, new[] { 1, 0, 9, 8 })]
    [TestCase(new[] { 2, 1, 5 }, 806, new[] { 1, 0, 2, 1 })]
    [TestCase(new[] { 2, 7, 4 }, 181, new[] { 4, 5, 5 })]
    [TestCase(new[] { 1, 2, 0, 0 }, 34, new[] { 1, 2, 3, 4 })]
    [TestCase(new[] { 1, 2 }, 5, new[] { 1, 7 })]
    [TestCase(new[] { 0 }, 23, new[] { 2, 3 })]
    [TestCase(new[] { 5 }, 23, new[] { 2, 8 })]
    public static void Example(int[] num, int k, int[] expected)
    {
        var result = s.AddToArrayForm(num, k);
        result.Should().BeEquivalentTo(expected, opt => opt.WithStrictOrdering());
    }
}