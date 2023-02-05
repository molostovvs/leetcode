using FluentAssertions;
using NUnit.Framework;

public class Program
{
    public static void Main() {}
}

//first attempt 85 min [O(s+p), O(s+p)]
public class OldSolution
{
    public IList<int> FindAnagrams(string input, string p)
    {
        var res = new List<int>();

        var pDict = new Dictionary<char, int>();
        foreach (var c in p)
            if (!pDict.TryAdd(c, 1))
                pDict[c]++;

        var sDict = new Dictionary<char, int>();

        for (int left = 0, right = 0; right < input.Length;)
        {
            var toAdd = input[right];

            if (!sDict.TryAdd(toAdd, 1))
                sDict[toAdd]++;
            if (left > 0)
            {
                var toRemove = input[left - 1];
                if (sDict[toRemove] == 1)
                    sDict.Remove(toRemove);
                else
                    sDict[toRemove]--;
            }

            if (right - left + 1 == p.Length)
            {
                if (SequenceEquivalent(pDict, sDict))
                    res.Add(left);

                left++;
                right++;
            }
            else
            {
                right++;
            }
        }

        return res;
    }

    private static bool SequenceEquivalent(Dictionary<char, int> pDict, Dictionary<char, int> sDict)
    {
        foreach (var kv in sDict)
        {
            if (!pDict.ContainsKey(kv.Key))
                return false;
            if (pDict[kv.Key] != kv.Value)
                return false;
        }

        return true;
    }
}

//second attempt 8 min [O(s+p), O(s+p)]
public class Solution
{
    public IList<int> FindAnagrams(string s, string p)
    {
        var res = new List<int>();

        var d2 = new Dictionary<char, int>();
        foreach (var ch in p)
            if (!d2.TryAdd(ch, 1))
                d2[ch]++;

        var cur = new Dictionary<char, int>();
        for (var i = 0; i < s.Length; i++)
        {
            if (i < p.Length)
            {
                if (!cur.TryAdd(s[i], 1))
                    cur[s[i]]++;
                continue;
            }

            if (DictionariesAreSimilar(d2, cur))
                res.Add(i - p.Length);

            if (cur[s[i - p.Length]] == 1)
                cur.Remove(s[i - p.Length]);
            else
                cur[s[i - p.Length]]--;

            if (!cur.TryAdd(s[i], 1))
                cur[s[i]]++;
        }

        if (DictionariesAreSimilar(cur, d2))
            res.Add(s.Length - p.Length);

        return res;
    }

    public bool DictionariesAreSimilar(Dictionary<char, int> d1, Dictionary<char, int> d2)
        => d1.All(kv => d2.ContainsKey(kv.Key) && d2[kv.Key] == kv.Value);
}

[TestFixture]
public class Tests
{
    private static Solution s = new();

    [TestCase("aaa", "a", new[] { 0, 1, 2 })]
    [TestCase("abc", "b", new[] { 1 })]
    [TestCase("abab", "ab", new[] { 0, 1, 2 })]
    [TestCase("zxba", "ab", new[] { 2 })]
    [TestCase("cbaebabacd", "abc", new[] { 0, 6 })]
    public static void Example(string inp, string p, IList<int> expected)
    {
        var result = s.FindAnagrams(inp, p);
        result.Should().BeEquivalentTo(expected, opt => opt.WithStrictOrdering());
    }
}