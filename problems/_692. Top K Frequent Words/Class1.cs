using FluentAssertions;
using NUnit.Framework;

public class Program
{
    public static void Main() {}
}

//my solution
public class Solution
{
    public IList<string> TopKFrequent(string[] words, int k)
    {
        var d = new Dictionary<string, int>();

        foreach (var word in words)
            if (!d.TryAdd(word, 1))
                d[word]++;

        return d.OrderBy(kv => (-kv.Value, kv.Key)).Take(k).Select(kv => kv.Key).ToList();
    }
}

//one line solution
public class OneLineSolution
{
    public IList<string> TopKFrequent(string[] words, int k)
        => words.GroupBy(w => w).OrderBy(g => (-g.Count(), g.Key)).Select(g => g.Key).Take(k).ToList();
}

[TestFixture]
public class Tests
{
    private static Solution s = new Solution();

    [TestCase(new[] { "i", "love", "leetcode", "i", "love", "coding" }, 2, new[] { "i", "love" })]
    public static void Example(string[] words, int k, string[] expected)
    {
        var result = s.TopKFrequent(words, k);
        result.Should().BeEquivalentTo(expected, opt => opt.WithStrictOrdering());
    }
}