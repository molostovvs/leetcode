using FluentAssertions;
using NUnit.Framework;

public class Program
{
    public static void Main() {}
}

//first attempt 2 min [O(n), O(1)]
public class Solution
{
    public int Tribonacci(int n)
    {
        var t1 = 0;
        var t2 = 1;
        var t3 = 1;

        switch (n)
        {
            case 0: return t1;
            case 1: return t2;
            case 2: return t3;
        }

        var cur = -1;
        for (var i = 3; i <= n; i++)
        {
            cur = t1 + t2 + t3;
            t1 = t2;
            t2 = t3;
            t3 = cur;
        }

        return cur;
    }
}

public class CrazySolution
{
    public int Tribonacci(int n)
        => n switch
        {
            0 => 0,
            1 => 1,
            2 => 1,
            3 => 2,
            4 => 4,
            5 => 7,
            6 => 13,
            7 => 24,
            8 => 44,
            9 => 81,
            10 => 149,
            11 => 274,
            12 => 504,
            13 => 927,
            14 => 1705,
            15 => 3136,
            16 => 5768,
            17 => 10609,
            18 => 19513,
            19 => 35890,
            20 => 66012,
            21 => 121415,
            22 => 223317,
            23 => 410744,
            24 => 755476,
            25 => 1389537,
            26 => 2555757,
            27 => 4700770,
            28 => 8646064,
            29 => 15902591,
            30 => 29249425,
            31 => 53798080,
            32 => 98950096,
            33 => 181997601,
            34 => 334745777,
            35 => 615693474,
            36 => 1132436852,
            37 => 2082876103,
            _ => -1,
        };
}

[TestFixture]
public class Tests
{
    private static Solution s = new();

    [TestCase(0, 0)]
    [TestCase(1, 1)]
    [TestCase(2, 1)]
    [TestCase(3, 2)]
    [TestCase(4, 4)]
    [TestCase(5, 7)]
    [TestCase(6, 13)]
    [TestCase(7, 24)]
    [TestCase(8, 44)]
    [TestCase(9, 81)]
    [TestCase(10, 149)]
    [TestCase(11, 274)]
    [TestCase(12, 504)]
    [TestCase(13, 927)]
    [TestCase(14, 1705)]
    [TestCase(15, 3136)]
    [TestCase(16, 5768)]
    [TestCase(17, 10609)]
    [TestCase(18, 19513)]
    [TestCase(19, 35890)]
    [TestCase(20, 66012)]
    [TestCase(21, 121415)]
    [TestCase(22, 223317)]
    [TestCase(23, 410744)]
    [TestCase(24, 755476)]
    [TestCase(25, 1389537)]
    [TestCase(26, 2555757)]
    [TestCase(27, 4700770)]
    [TestCase(28, 8646064)]
    [TestCase(29, 15902591)]
    [TestCase(30, 29249425)]
    [TestCase(31, 53798080)]
    [TestCase(32, 98950096)]
    [TestCase(33, 181997601)]
    [TestCase(34, 334745777)]
    [TestCase(35, 615693474)]
    [TestCase(36, 1132436852)]
    [TestCase(37, 2082876103)]
    public static void Example(int n, int expected)
    {
        var result = s.Tribonacci(n);
        result.Should().Be(expected);
    }
}