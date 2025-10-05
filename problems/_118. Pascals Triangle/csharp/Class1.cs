using FluentAssertions;
using NUnit.Framework;

public class Program
{
    public static void Main() {}
}

public class FirstSolution
{
    public IList<IList<int>> Generate(int numRows)
    {
        // simple code [O(n^2), O(n^2)]
        var triangle = new List<IList<int>>();
        triangle.Add(new List<int>(new[] { 1 }));

        for (var i = 1; i < numRows; i++)
        {
            triangle.Add(new List<int>());
            var curr = triangle[i];
            var prev = triangle[i - 1];
            for (var j = 0; j <= i; j++)
                if (j == 0 || j == i)
                    curr.Add(1);
                else
                    curr.Add(prev[j - 1] + prev[j]);
        }

        return triangle;
    }
}

//second attempt 3 min [O(n^2), O(1)]
public class Solution
{
    public IList<IList<int>> Generate(int numRows)
    {
        var res = new List<IList<int>>();

        for (var i = 0; i < numRows; i++)
        {
            res.Add(new List<int>(i + 1));
            for (var j = 0; j <= i; j++)
                if (j == 0 || j == i)
                    res[i].Add(1);
                else
                    res[i].Add(res[i - 1][j - 1] + res[i - 1][j]);
        }

        return res;
    }
}

[TestFixture]
public class Tests
{
    private static Solution s = new();

    [Test]
    public static void OneRow()
    {
        var result = s.Generate(1);
        var expected = new List<List<int>>();
        expected.Add(new List<int>(new[] { 1 }));
        result.Should().BeEquivalentTo(expected, options => options.WithStrictOrdering());
    }

    [Test]
    public static void TwoRow()
    {
        var result = s.Generate(2);
        var expected = new List<List<int>>();
        expected.Add(new List<int>(new[] { 1 }));
        expected.Add(new List<int>(new[] { 1, 1 }));
        result.Should().BeEquivalentTo(expected, options => options.WithStrictOrdering());
    }

    [Test]
    public static void ThreeRow()
    {
        var result = s.Generate(3);
        var expected = new List<List<int>>();
        expected.Add(new List<int>(new[] { 1 }));
        expected.Add(new List<int>(new[] { 1, 1 }));
        expected.Add(new List<int>(new[] { 1, 2, 1 }));
        result.Should().BeEquivalentTo(expected, options => options.WithStrictOrdering());
    }

    [Test]
    public static void FourRow()
    {
        var result = s.Generate(4);
        var expected = new List<List<int>>();
        expected.Add(new List<int>(new[] { 1 }));
        expected.Add(new List<int>(new[] { 1, 1 }));
        expected.Add(new List<int>(new[] { 1, 2, 1 }));
        expected.Add(new List<int>(new[] { 1, 3, 3, 1 }));
        result.Should().BeEquivalentTo(expected, options => options.WithStrictOrdering());
    }

    [Test]
    public static void FiveRow()
    {
        var result = s.Generate(5);
        var expected = new List<List<int>>();
        expected.Add(new List<int>(new[] { 1 }));
        expected.Add(new List<int>(new[] { 1, 1 }));
        expected.Add(new List<int>(new[] { 1, 2, 1 }));
        expected.Add(new List<int>(new[] { 1, 3, 3, 1 }));
        expected.Add(new List<int>(new[] { 1, 4, 6, 4, 1 }));
        result.Should().BeEquivalentTo(expected, options => options.WithStrictOrdering());
    }
}