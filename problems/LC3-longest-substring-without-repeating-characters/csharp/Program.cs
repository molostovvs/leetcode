using FluentAssertions;
using NUnit.Framework;

public class Program
{
    public static void Main() {}
}

//first attempt 23 min [O(n), O(n)]
public class Solution
{
    public int LengthOfLongestSubstring(string s)
    {
        var q = new Queue<char>();
        var counter = 0;

        foreach (var ch in s)
        {
            if (q.Contains(ch))
                while (q.Contains(ch))
                    q.Dequeue();

            q.Enqueue(ch);

            if (q.Count > counter)
                counter = q.Count;
        }

        return counter;
    }
}

[TestFixture]
public class Tests
{
    private static Solution s = new();

    [TestCase("abc", 3)]
    [TestCase("abcc", 3)]
    [TestCase("abcabcbb", 3)]
    [TestCase("bbbbbb", 1)]
    [TestCase("pwwkew", 3)]
    [TestCase("pwwkew", 3)]
    [TestCase("abbcax", 4)]
    [TestCase("abcdax", 5)]
    [TestCase("dvdf", 3)]
    public static void Example(string inp, int expected)
    {
        var result = s.LengthOfLongestSubstring(inp);
        result.Should().Be(expected);
    }
}