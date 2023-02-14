using FluentAssertions;
using NUnit.Framework;

public class Program
{
    public static void Main() {}
}

//first attempt 80 min (spied) [O(n), O(n)]
public class Solution
{
    public int NumDecodings(string s)
    {
        var dp = new int[s.Length + 1];
        dp[s.Length] = 1;
        for (var i = s.Length - 1; i >= 0; i--)
            if (s[i] != '0')
            {
                dp[i] = dp[i + 1];
                if (i < s.Length - 1 && (s[i] == '1' || (s[i] == '2' && s[i + 1] < '7')))
                    dp[i] += dp[i + 2];
            }

        return dp[0];
    }
}

[TestFixture]
public class Tests
{
    private static Solution s = new();

    [TestCase("2101", 1)]
    [TestCase("12222", 8)]
    [TestCase("1222", 5)]
    [TestCase("122", 3)]
    [TestCase("122", 3)]
    [TestCase("10", 1)]
    [TestCase("103", 1)]
    [TestCase("10011", 0)]
    public static void Example(string inp, int expected)
    {
        var result = s.NumDecodings(inp);
        result.Should().Be(expected);
    }
}