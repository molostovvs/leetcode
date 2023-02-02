using FluentAssertions;
using NUnit.Framework;

public class Program
{
    public static void Main() {}
}

//first attempt
public class OldSolution
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

//second attempt 10 min [O(n), O(alphabet)]
public class Solution
{
    public bool IsAlienSorted(string[] words, string order)
    {
        var alphabet = new Dictionary<char, int>();
        for (var i = 0; i < order.Length; i++)
            alphabet.Add(order[i], i + 1);

        for (var i = 1; i < words.Length; i++)
            if (!PreviousWordIsSmaller(words[i - 1], words[i], alphabet))
                return false;

        return true;
    }

    private bool PreviousWordIsSmaller(string prev, string cur, Dictionary<char, int> alphabet)
    {
        var minLength = Math.Min(prev.Length, cur.Length);
        for (var i = 0; i < minLength; i++)
            if (alphabet[prev[i]] < alphabet[cur[i]])
                return true;
            else if (alphabet[prev[i]] > alphabet[cur[i]])
                return false;

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
    [TestCase(new[] { "kuvp", "q" }, "ngxlkthsjuoqcpavbfdermiywz", true)]
    public static void Example(string[] words, string alphabet, bool expected)
    {
        var result = s.IsAlienSorted(words, alphabet);
        result.Should().Be(expected);
    }
}