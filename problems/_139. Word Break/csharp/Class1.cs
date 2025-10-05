using System.Text;
using FluentAssertions;
using NUnit.Framework;

public class Program
{
    public static void Main() {}
}

//first attempt (spied) 80 min [O(n^3), O(n)]
public class Solution
{
    public bool WordBreak(string str, IEnumerable<string> wordDict)
    {
        var set = wordDict.ToHashSet();
        var dp = new bool[str.Length + 1]; //boolean at each index reflects the ability to get to that index using a dictionary
        dp[0] = true; //we can reach empty string with any dictionary

        for (var start = 0; start < str.Length; start++)
            if (dp[start]) //if we can reach this index using dictionary (prefix is valid)
                for (var end = start + 1; end <= str.Length; end++) // look for next valid suffix
                    if (set.Contains(str[start..end]))
                        dp[end] = true; //represents that this index can be reached with a valid prefix

        return dp[^1]; //if we can reach end of str with valid prefix it will return true
    }
}

[TestFixture]
public class Tests
{
    private static Solution s = new();

    [TestCase("catsandog", new[] { "cats", "dog", "sand", "and", "cat" }, false)]
    [TestCase("applepenapple", new[] { "apple", "pen" }, true)]
    [TestCase("leetcode", new[] { "leet", "code" }, true)]
    [TestCase("aaaaaaaaaa", new[] { "aaa", "aaaaa" }, true)]
    [TestCase("xxxxx", new[] { "xx", "xxx" }, true)]
    [TestCase(
        "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaab",
        new[] { "a", "aa", "aaa", "aaaa", "aaaaa", "aaaaaa", "aaaaaaa", "aaaaaaaa", "aaaaaaaaa", "aaaaaaaaaa" },
        false
    )]
    public static void Example(string inp, IEnumerable<string> dict, bool expected)
    {
        var result = s.WordBreak(inp, dict);
        result.Should().Be(expected);
    }
}