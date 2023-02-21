using FluentAssertions;
using NUnit.Framework;

public class Program
{
    public static void Main() {}
}

//first attempt 30 min (spied) [O(m*n), O(m*n)]
public class Solution
{
    public int LongestPalindromeSubseq(string s)
    {
        var dp = new int[s.Length, s.Length];

        for (var left = s.Length - 1; left >= 0; left--)
        {
            dp[left, left] = 1;
            for (var right = left + 1; right < s.Length; right++)
                if (s[left] == s[right])
                    dp[left, right] = dp[left + 1, right - 1] + 2;
                else
                    dp[left, right] = Math.Max(dp[left + 1, right], dp[left, right - 1]);
        }

        return dp[0, s.Length - 1];
    }
}

[TestFixture]
public class Tests
{
    private static Solution s = new();

    [TestCase("bbbab", 4)]
    [TestCase("axbba", 4)]
    [TestCase("cbbd", 2)]
    public static void Example(string str, int expected)
    {
        var result = s.LongestPalindromeSubseq(str);
        result.Should().Be(expected);
    }
}