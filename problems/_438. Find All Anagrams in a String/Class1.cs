using FluentAssertions;
using NUnit.Framework;

public class Program
{
    public static void Main() {}
}

public class Solution
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