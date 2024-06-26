﻿using System.Globalization;
using FluentAssertions;
using NUnit.Framework;

namespace _242._Valid_Anagram;

public class FirstSolution
{
    public bool IsAnagram(string s, string t)
        => s.OrderBy(i => i).SequenceEqual(t.OrderBy(i => i));
}

//5 min [O(s+t), O(s+t)]
public class Solution
{
    public bool IsAnagram(string s, string t)
    {
        if (s.Length != t.Length)
            return false;

        var sDict = new Dictionary<char, int>(); //int for count

        for (var i = 0; i < s.Length; i++)
        {
            var ch = s[i];

            if (!sDict.TryAdd(ch, 1))
                sDict[ch]++;
        }

        for (var i = 0; i < t.Length; i++)
        {
            var ch = t[i];

            if (!sDict.ContainsKey(ch))
                return false;

            sDict[ch]--;
        }

        return sDict.All(kv => kv.Value == 0);
    }
}

//10 min [O(n), O(s)]
public class ThirdSolution
{
    public bool IsAnagram(string s, string t)
    {
        var d = new Dictionary<char, int>();

        foreach (var ch in s)
        {
            if (!d.TryAdd(ch, 1))
                d[ch]++;
        }

        foreach (var ch in t)
        {
            if (!d.ContainsKey(ch) || d[ch] == 0)
                return false;

            d[ch]--;
        }

        foreach (var kv in d)
            if (kv.Value > 0)
                return false;

        return true;
    }
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
