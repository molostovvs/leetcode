using FluentAssertions;
using NUnit.Framework;

public class Program
{
    public static void Main() {}
}

public class OldSolution
{
    public bool CheckInclusion(string s1, string s2)
    {
        var d1 = new Dictionary<char, int>();
        foreach (var ch in s1)
            if (!d1.TryAdd(ch, 1))
                d1[ch]++;

        var d2 = new Dictionary<char, int>();
        for (var i = 0; i < s2.Length; i++)
        {
            if (i < s1.Length)
            {
                if (!d2.TryAdd(s2[i], 1))
                    d2[s2[i]]++;
                continue;
            }

            if (IsDictionariesAreTheSame(d1, d2))
                return true;

            if (d2[s2[i - s1.Length]] > 1)
                d2[s2[i - s1.Length]]--;
            else
                d2.Remove(s2[i - s1.Length]);

            if (!d2.TryAdd(s2[i], 1))
                d2[s2[i]]++;
        }

        return IsDictionariesAreTheSame(d1, d2);
    }

    private bool IsDictionariesAreTheSame(Dictionary<char, int> d1, Dictionary<char, int> d2)
    {
        if (d1.Count != d2.Count)
            return false;
        foreach (var kv in d1)
            if (!d2.ContainsKey(kv.Key) || d2[kv.Key] != kv.Value)
                return false;

        return true;
    }
}

//second attempt 15 min [O(m + n), O(alphabet)]
public class Solution
{
    public bool CheckInclusion(string s1, string s2)
    {
        var d1 = new Dictionary<char, int>();
        foreach (var ch in s1)
            if (!d1.TryAdd(ch, 1))
                d1[ch]++;

        var d2 = new Dictionary<char, int>();

        for (var i = 0; i < s2.Length; i++)
        {
            if (i < s1.Length)
            {
                if (!d2.TryAdd(s2[i], 1))
                    d2[s2[i]]++;
                continue;
            }

            if (DictionariesAreTheSame(d1, d2))
                return true;

            if (d2[s2[i - s1.Length]] == 1)
                d2.Remove(s2[i - s1.Length]);
            else
                d2[s2[i - s1.Length]]--;

            if (!d2.TryAdd(s2[i], 1))
                d2[s2[i]]++;
        }

        return DictionariesAreTheSame(d1, d2);
    }

    private bool DictionariesAreTheSame(Dictionary<char, int> d1, Dictionary<char, int> d2)
        => d1.All(kv => d2.ContainsKey(kv.Key) && d2[kv.Key] == kv.Value);
}

[TestFixture]
public class Tests
{
    private static Solution s = new();

    [TestCase("ab", "eidbaooo", true)]
    [TestCase("ab", "eidboaoo", false)]
    [TestCase("adc", "dcda", true)]
    public static void Example(string s1, string s2, bool expected)
    {
        var result = s.CheckInclusion(s1, s2);
        result.Should().Be(expected);
    }
}