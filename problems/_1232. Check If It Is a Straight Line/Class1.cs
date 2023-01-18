using System.Drawing;
using NUnit.Framework;
using FluentAssertions;
using System.Drawing;

namespace _1232._Check_If_It_Is_a_Straight_Line;

public class Program
{
    public static void Main() {}
}

public class Solution
{
    public bool CheckStraightLine(int[][] inp)
    {
        for (var i = 2; i < inp.GetLength(0); i++)
        {
            var left = (inp[0][0] - inp[1][0]) * (inp[i][1] - inp[1][1]);
            var right = (inp[0][1] - inp[1][1]) * (inp[i][0] - inp[1][0]);
            if (Math.Abs(left - right) > 1e-5)
                return false;
        }

        return true;
    }
}

[TestFixture]
public class Tests
{
    private static Solution s = new();

    [Test]
    public static void Straight()
    {
        var inp = new[]
        {
            new[] { 1, 2 }, new[] { 2, 3 }, new[] { 3, 4 }, new[] { 4, 5 }, new[] { 5, 6 }, new[] { 6, 7 },
        };
        var result = s.CheckStraightLine(inp);
        result.Should().BeTrue();
    }

    [Test]
    public static void Straight1()
    {
        var inp = new[] { new[] { 2, 4 }, new[] { 2, 5 }, new[] { 2, 8 } };
        var result = s.CheckStraightLine(inp);
        result.Should().BeTrue();
    }

    [Test]
    public static void StraightBelowZero()
    {
        var inp = new[] { new[] { 0, 0 }, new[] { 0, 1 }, new[] { 0, -1 } };
        var result = s.CheckStraightLine(inp);
        result.Should().BeTrue();
    }

    [Test]
    public static void NotStraight()
    {
        var inp = new[]
        {
            new[] { 1, 1 }, new[] { 2, 2 }, new[] { 3, 4 }, new[] { 4, 5 }, new[] { 5, 6 }, new[] { 7, 7 },
        };
        var result = s.CheckStraightLine(inp);
        result.Should().BeFalse();
    }

    [Test]
    public static void NotStraight1()
    {
        var inp = new[] { new[] { 1, 1 }, new[] { 2, 2 }, new[] { 2, 0 } };
        var result = s.CheckStraightLine(inp);
        result.Should().BeFalse();
    }

    [Test]
    public static void NotStraight2()
    {
        var inp = new[] { new[] { 0, 1 }, new[] { 2, 4 }, new[] { 3, 3 } };
        var result = s.CheckStraightLine(inp);
        result.Should().BeFalse();
    }
}