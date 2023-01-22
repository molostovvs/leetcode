using System.Text;
using FluentAssertions;
using NUnit.Framework;

namespace _1309._Decrypt_String_from_Alphabet_to_Integer_Mapping;

public class Program
{
    public static void Main() {}
}

// With StringBuilder and Reverse [O(n), O(n)]
public class Solution
{
    public string FreqAlphabets(string s)
    {
        var sb = new StringBuilder();
        for (var i = s.Length - 1; i >= 0;)
        {
            var c = s[i];
            if (c == '#')
            {
                var str = s[i - 2] + s[i - 1].ToString();
                var n = int.Parse(str);
                sb.Append((char)(n + 'a' - 1));
                i -= 3;
            }
            else
            {
                var n = int.Parse(c.ToString());
                sb.Append((char)(n + 'a' - 1));
                i--;
            }
        }

        var a = sb.ToString().ToCharArray().Reverse().ToArray();
        return new string(a);
    }
}

[TestFixture]
public class Tests
{
    private static Solution s = new();

    [TestCase("10#11#12", "jkab")]
    public static void Example(string inp, string expected)
    {
        var result = s.FreqAlphabets(inp);
        result.Should().Be(expected);
    }
}