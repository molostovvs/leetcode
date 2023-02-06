using System.Text;
using FluentAssertions;
using NUnit.Framework;

public class Program
{
    public static void Main() {}
}

//first attempt 17 min [O(2*letters), O(1)]
public class Solution
{
    public IList<string> LetterCasePermutation(string s)
    {
        var res = new List<string>();
        Helper(res, s, new StringBuilder());
        return res;
    }

    private void Helper(List<string> res, string s, StringBuilder sb, int position = 0)
    {
        if (sb.Length == s.Length)
            res.Add(sb.ToString());
        else
            for (; position < s.Length; position++)
            {
                var ch = s[position];
                sb.Append(char.ToLower(ch));
                Helper(res, s, sb, position + 1);
                sb.Remove(sb.Length - 1, 1);
                if (char.IsLetter(ch))
                {
                    sb.Append(char.ToUpper(ch));
                    Helper(res, s, sb, position + 1);
                    sb.Remove(sb.Length - 1, 1);
                }
            }
    }
}

[TestFixture]
public class Tests
{
    private static Solution s = new();

    [Test]
    public static void Example1()
    {
        var result = s.LetterCasePermutation("a1b2");
        var expected = new List<string>
        {
            "a1b2",
            "a1B2",
            "A1b2",
            "A1B2",
        };
        result.Should().BeEquivalentTo(expected);
    }

    [Test]
    public static void SimpleExample()
    {
        var result = s.LetterCasePermutation("a1");
        var expected = new List<string>
        {
            "a1",
            "A1",
        };
        result.Should().BeEquivalentTo(expected);
    }
}