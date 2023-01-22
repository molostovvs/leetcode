using FluentAssertions;
using NUnit.Framework;

namespace _953._Verifying_an_Alien_Dictionary;

public class Program
{
    public static void Main() {}
}

public class Solution
{
    public bool IsAlienSorted(string[] words, string order)
    {
        var dict = new Dictionary<char, int>(); //char - pos in alphabet
        for (var i = 0; i < order.Length; i++)
            dict.Add(order[i], i + 1);

        for (var i = 1; i < words.Length; i++)
        {
            var prev = words[i - 1];
            var cur = words[i];
            if (!IsLexicographicallySorted(prev, cur, dict))
                return false;
        }

        return true;
    }

    private bool IsLexicographicallySorted(string prev, string cur, Dictionary<char, int> dict)
    {
        var length = Math.Min(prev.Length, cur.Length);
        for (var i = 0; i < length; i++)
        {
            if (dict[prev[i]] < dict[cur[i]])
                return true;
            if (dict[prev[i]] > dict[cur[i]])
                return false;
        }

        return prev.Length <= cur.Length;
    }
}

[TestFixture]
public class Tests
{
    private static Solution s = new();

    [TestCase(new[] { "hello", "leetcode" }, "hlabcdefgijkmnopqrstuvwxyz", true)]
    [TestCase(new[] { "word", "world", "row" }, "worldabcefghijkmnpqstuvxyz", false)]
    [TestCase(new[] { "apple", "app" }, "abcdefghijklmnopqrstuvwxyz", false)]
    [TestCase(new[] { "hello", "hello" }, "abcdefghijklmnopqrstuvwxyz", true)]
    public static void Example(string[] words, string alphabet, bool expected)
    {
        var result = s.IsAlienSorted(words, alphabet);
        result.Should().Be(expected);
    }
}