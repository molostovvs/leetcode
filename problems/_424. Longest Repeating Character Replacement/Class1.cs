using FluentAssertions;
using NUnit.Framework;

public class Program
{
    public static void Main() {}
}

public class Solution
{
    // with dictionary scanning for max value [O(n), O(alphabet)]
    public int CharacterReplacement(string s, int k)
    {
        var res = int.MinValue;
        var d = new Dictionary<char, int>();

        for (int l = 0, r = 0; r < s.Length; r++)
        {
            if (!d.TryAdd(s[r], 1))
                d[s[r]]++;

            while (r - l + 1 - d.Values.Max() > k) //r - l + 1 - width of the sliding window
            {
                d[s[l]]--; // move left
                l++;       // pointer
            }

            res = Math.Max(res, r - l + 1);
        }

        return res;
    }

    /*public int CharacterReplacement(string s, int k)
    {
        var res = int.MinValue;
        var d = new Dictionary<char, int>();
        var maxFreq = 0;

        for (int l = 0, r = 0; r < s.Length; r++)
        {
            if (!d.TryAdd(s[r], 1))
                d[s[r]]++;
            maxFreq = Math.Max(maxFreq, d[s[r]]);

            while (r - l + 1 - maxFreq > k)
            {
                d[s[l]]--;
                l++;
            }

            res = Math.Max(res, r - l + 1);
        }

        return res;
    }*/
}

[TestFixture]
public class Tests
{
    private static Solution s = new();

    [TestCase("X", 0, 1)]
    [TestCase("ABAB", 2, 4)]
    [TestCase("AABABBA", 1, 4)]
    [TestCase("AAAA", 2, 4)]
    [TestCase("ABBB", 2, 4)]
    [TestCase("BAAAB", 2, 5)]
    [TestCase("ABABBA", 2, 5)]
    public static void Example(string inp, int k, int expected)
    {
        var result = s.CharacterReplacement(inp, k);
        result.Should().Be(expected);
    }
}