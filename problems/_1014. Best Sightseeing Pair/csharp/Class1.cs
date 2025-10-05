using FluentAssertions;
using NUnit.Framework;

public class Program
{
    public static void Main() {}
}

public class NaiveSolution
{
    public int MaxScoreSightseeingPair(int[] values)
    {
        var res = 0;

        for (var i = 0; i < values.Length; i++)
            for (var j = i + 1; j < values.Length; j++)
                if (values[i] + values[j] - (j - i) > res)
                    res = values[i] + values[j] - (j - i);

        return res;
    }
}

//first attempt (hint) 45 min [O(n), O(1)]
public class Solution
{
    public int MaxScoreSightseeingPair(int[] values)
    {
        var res = int.MinValue;

        (int Value, int Index) highest = (values[0], 0);

        for (var j = 1; j < values.Length; j++)
        {
            var value = highest.Value + values[j];
            var distance = j - highest.Index;
            if (value - distance > res)
                res = value - distance;
            if (values[j] - highest.Value >= highest.Index - j)
                highest = (values[j], j);
        }

        return res;
    }
}

[TestFixture]
public class Tests
{
    private static Solution s = new();

    [TestCase(new[] { 8, 1, 5, 2, 6 }, 11)]
    [TestCase(new[] { 1, 2 }, 2)]
    [TestCase(new[] { 7, 8, 8, 10 }, 17)]
    [TestCase(new[] { 7, 2, 6, 6, 9, 4, 3 }, 14)]
    public static void Example(int[] inp, int expected)
    {
        var result = s.MaxScoreSightseeingPair(inp);

        result.Should().Be(expected);
    }
}