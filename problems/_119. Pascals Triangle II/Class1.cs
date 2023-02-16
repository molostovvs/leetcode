using FluentAssertions;
using NUnit.Framework;

public class Program
{
    public static void Main() {}
}

//naive solution 3 min [O(n^2), O(n^2)]
public class NaiveSolution
{
    public IList<int> GetRow(int rowIndex)
    {
        var res = new List<IList<int>>();

        for (var i = 0; i <= rowIndex; i++)
        {
            res.Add(new List<int>(i + 1));
            for (var j = 0; j <= i; j++)
                if (j == 0 || j == i)
                    res[i].Add(1);
                else
                    res[i].Add(res[i - 1][j - 1] + res[i - 1][j]);
        }

        return res[rowIndex];
    }
}

//optimized solution 8 min [O(n^2), O(1)]
public class Solution
{
    public IList<int> GetRow(int rowIndex)
    {
        var res = new int[rowIndex + 1];

        for (var c = 0; c <= rowIndex; c++)
        {
            var prev = 1;
            var cur = 1;
            for (var i = 0; i <= c; i++)
                if (i == 0 || i == c)
                {
                    res[i] = 1;
                }
                else
                {
                    prev = cur;
                    cur = res[i];
                    res[i] = prev + cur;
                }
        }

        return res;
    }
}

[TestFixture]
public class Tests
{
    private static Solution s = new();

    [TestCase(0, new[] { 1 })]
    [TestCase(1, new[] { 1, 1 })]
    [TestCase(2, new[] { 1, 2, 1 })]
    [TestCase(3, new[] { 1, 3, 3, 1 })]
    [TestCase(4, new[] { 1, 4, 6, 4, 1 })]
    public static void Example(int row, int[] expected)
    {
        var result = s.GetRow(row);
        result.Should().BeEquivalentTo(expected, opt => opt.WithStrictOrdering());
    }
}