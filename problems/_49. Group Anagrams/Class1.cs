using System.Text;
using FluentAssertions;
using NUnit.Framework;
using NUnit.Framework.Internal.Commands;

namespace _49._Group_Anagrams;

public class Program
{
    public static void Main() {}
}

public class Solution
{
    public IList<IList<string>> GroupAnagrams(string[] strs)
    {
        var dict = new Dictionary<string, List<string>>();

        foreach (var s in strs)
        {
            var sortedString = new string(s.OrderBy(c => c).ToArray());
            if (!dict.TryAdd(sortedString, new List<string>(new[] { s })))
                dict[sortedString].Add(s);
        }

        return dict.Select(kv => kv.Value).Cast<IList<string>>().ToList();
    }
}

[TestFixture]
public class Tests
{
    private static Solution s = new();

    [Test]
    public static void Example()
    {
        var strs = new[] { "eat", "tea", "tan", "ate", "nat", "bat" };
        var res = s.GroupAnagrams(strs);
        var expected = new List<IList<string>>();
        expected.Add(new[] { "bat" });
        expected.Add(new[] { "nat", "tan" });
        expected.Add(new[] { "ate", "eat", "tea" });
        res.Should().BeEquivalentTo(expected);
    }

    [Test]
    public static void Example2()
    {
        var strs = new[] { "ac", "c" };
        var res = s.GroupAnagrams(strs);
        var expected = new List<IList<string>>();
        expected.Add(new[] { "ac" });
        expected.Add(new[] { "c" });
        res.Should().BeEquivalentTo(expected);
    }
}