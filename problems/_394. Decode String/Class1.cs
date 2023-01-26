using System.Text;
using FluentAssertions;
using NUnit.Framework;

public class Program
{
    public static void Main() {}
}

public class Solution
{
    public string DecodeString(string s)
    {
        var pointer = 0;
        var sb = Dfs(s, ref pointer);
        return sb.ToString();
    }

    StringBuilder Dfs(string s, ref int pointer)
    {
        StringBuilder sbNumber = new();
        StringBuilder sbWord = new();
        StringBuilder sbResult = new();
        if (pointer >= s.Length)
            return sbResult;
        var n = 0;
        while (pointer < s.Length && char.IsDigit(s[pointer]))
        {
            sbNumber.Append(s[pointer]);
            pointer++;
        }

        if (sbNumber.Length > 0)
            n = Convert.ToInt32(sbNumber.ToString());
        if (n > 0)
        {
            if (s[pointer] == '[')
            {
                pointer++;
                sbWord = Dfs(s, ref pointer);
            }

            for (int i = 0; i < n; i++)
                sbResult.Append(sbWord.ToString());
        }
        else
        {
            while (pointer < s.Length && char.IsLetter(s[pointer]))
            {
                sbWord.Append(s[pointer++]);
                // pointer++;
            }

            if (pointer >= s.Length - 1 || s[pointer] == ']')
                return sbWord;

            if (char.IsDigit(s[pointer]))
            {
                return sbWord.Append(Dfs(s, ref pointer));
                // return sbWord;
            }
        }

        if (pointer < s.Length - 1)
        {
            pointer++;
            sbResult.Append(Dfs(s, ref pointer));
        }

        return sbResult;
    }
}

[TestFixture]
public class Tests
{
    private static Solution s = new Solution();

    [TestCase("3[a]2[bc]", "aaabcbc")]
    public static void Example(string encoded, string expected)
    {
        var result = s.DecodeString(encoded);
        result.Should().Be(expected);
    }
}