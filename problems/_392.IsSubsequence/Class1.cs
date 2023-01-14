using FluentAssertions;
using NUnit.Framework;

namespace _392.IsSubsequence;

public class Program
{
    static void Main(string[] args) {}
}

public class Solution
{
    public bool IsSubsequence(string s, string t)
    {
        int count = s.Length;
        for (int i = 0, j = 0; i < t.Length && j < s.Length; i++)
            if (t[i] == s[j])
            {
                count--;
                j++;
            }

        return count == 0;
    }
}

[TestFixture]
public class Tests
{
    public static Solution sol = new();

    [TestCase("abc", "ahbgdc", true)]
    [TestCase("axc", "ahbgdc", false)]
    [TestCase("", "ahbgdc", true)]
    public static void Examples(string s, string t, bool expected)
    {
        var result = sol.IsSubsequence(s, t);
        result.Should().Be(expected);
    }
}