using System.Collections;
using FluentAssertions;
using NUnit.Framework;

public class Program
{
    static void Main(string[] args) {}
}

public class Solution
{
    public bool IsIsomorphic(string s, string t)
    {
        var d = new Dictionary<char, char>();
        for (var i = 0; i < s.Length; i++)
            if ((d.ContainsKey(s[i]) && d[s[i]] != t[i]) || (!d.ContainsKey(s[i]) && d.ContainsValue(t[i])))
                return false;
            else
                d.TryAdd(s[i], t[i]);
        return true;
    }
}

[TestFixture]
public class Tests
{
    private static Solution s = new();

    [TestCase("egg", "add", true)]
    [TestCase("paper", "title", true)]
    [TestCase("foo", "bar", false)]
    [TestCase("door", "room", true)]
    [TestCase("door", "flat", false)]
    [TestCase("badc", "baba", false)]
    public static void Examples(string s1, string s2, bool expected)
    {
        var result = s.IsIsomorphic(s1, s2);
        result.Should().Be(expected);
    }
}