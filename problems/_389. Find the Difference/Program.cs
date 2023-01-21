using FluentAssertions;
using NUnit.Framework;

public class Program
{
    public static void Main() {}
}

/*// [O(s + t), O(s)]

public class Solution
{
    public char FindTheDifference(string s, string t)
    {
        var d = new Dictionary<char, int>();
        for (int i = 0; i < s.Length; i++)
            if (!d.TryAdd(s[i], 1))
                d[s[i]]++;

        for (var i = 0; i < t.Length; i++)
            if (d.ContainsKey(t[i]))
                d[t[i]]--;
            else
                return t[i];

        foreach (var kv in d)
            if (kv.Value < 0)
                return kv.Key;
        return ' ';
    }
}*/

// [O(s + t), O(1)]
public class Solution
{
    public char FindTheDifference(string s, string t)
    {
        var sum = t.Sum(x => x);
        sum -= s.Sum(x => x);
        return (char)sum;
    }
}

[TestFixture]
public class Tests
{
    public static Solution sol = new();

    [TestCase("abc", "abcd", 'd')]
    public static void Example(string s, string t, char expected)
    {
        var result = sol.FindTheDifference(s, t);
        result.Should().Be(expected);
    }
}