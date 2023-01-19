using System.Globalization;
using FluentAssertions;
using NUnit.Framework;

namespace _242._Valid_Anagram;

public class Program
{
    public static void Main() {}
}

public class Solution
{
    public bool IsAnagram(string s, string t)
        /*//simple solution via dictionary [O(s+t), O(s+t)]
        if (s.Length != t.Length)
            return false;

        var sDict = new Dictionary<char, int>();
        foreach (var c in s)
            if (!sDict.TryAdd(c, 1))
                sDict[c]++;

        var tDict = new Dictionary<char, int>();
        foreach (var c in t)
            if (!tDict.TryAdd(c, 1))
                tDict[c]++;

        foreach (var kv in sDict)
            if (!tDict.ContainsKey(kv.Key) || sDict[kv.Key] != tDict[kv.Key])
                return false;

        return true;*/
        => s.OrderBy(i => i).SequenceEqual(t.OrderBy(i => i));
}

[TestFixture]
public class Tests
{
    private static Solution s = new();

    [TestCase("cat", "rat", false)]
    [TestCase("anagram", "nagaram", true)]
    public static void Example(string s1, string s2, bool expected)
    {
        var result = s.IsAnagram(s1, s2);
        result.Should().Be(expected);
    }
}