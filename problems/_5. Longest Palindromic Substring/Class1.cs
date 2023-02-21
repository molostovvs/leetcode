using FluentAssertions;
using NUnit.Framework;

public class Program
{
    public static void Main() {}
}

//first attempt 30 min (spied) [O(n^2), O(1)]
public class Solution
{
    public string LongestPalindrome(string s)
    {
        var start = 0;
        var maxLength = 1;

        for (var i = 0; i < s.Length; i++)
        {
            var right = i;

            while (right < s.Length && s[i] == s[right])
                right++;

            var left = i - 1;
            while (left >= 0 && right < s.Length && s[left] == s[right])
            {
                left--;
                right++;
            }

            var curMax = right - left - 1;
            if (curMax > maxLength)
            {
                maxLength = curMax;
                start = left + 1;
            }
        }

        return s[start..(start + maxLength)];
    }
}

[TestFixture]
public class Tests
{
    private static Solution s = new();

    [TestCase("babad", "bab")]
    [TestCase("cbbd", "bb")]
    public static void Example(string inp, string expected)
    {
        var result = s.LongestPalindrome(inp);
        result.Should().Be(expected);
    }
}