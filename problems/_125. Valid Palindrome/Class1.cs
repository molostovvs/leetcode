using FluentAssertions;
using NUnit.Framework;

public class Program
{
    public static void Main() {}
}

public class Solution
{
    public bool IsPalindrome(string s)
    {
        var arr = s.ToCharArray().Where(c => char.IsLetterOrDigit(c)).Select(c => char.ToLowerInvariant(c)).ToArray();

        for (int l = 0, r = arr.Length - 1; l <= r; l++, r--)
            if (arr[l] != arr[r])
                return false;

        return true;
    }
}

[TestFixture]
public class Tests
{
    private static Solution s = new Solution();

    [TestCase("A man, a plan, a canal: Panama", true)]
    [TestCase("0P", false)]
    public static void Example(string inp, bool expected)
    {
        var result = s.IsPalindrome(inp);
        result.Should().Be(expected);
    }
}