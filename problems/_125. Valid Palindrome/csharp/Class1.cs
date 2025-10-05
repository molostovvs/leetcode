using FluentAssertions;
using NUnit.Framework;

public class FirstSolution
{
    public bool IsPalindrome(string s)
    {
        var arr = s.ToCharArray()
                   .Where(c => char.IsLetterOrDigit(c))
                   .Select(c => char.ToLowerInvariant(c))
                   .ToArray();

        for (int l = 0, r = arr.Length - 1; l <= r; l++, r--)
            if (arr[l] != arr[r])
                return false;

        return true;
    }
}

//10 min [O(n), O(1)]
public class SecondSolution
{
    public bool IsPalindrome(string s)
    {
        var left = 0;
        var right = s.Length - 1;

        while (left < right)
        {
            if (char.IsLetterOrDigit(s[left]) && char.IsLetterOrDigit(s[right]))
            {
                if (char.ToLowerInvariant(s[left]) != char.ToLowerInvariant(s[right]))
                    return false;
                left++;
                right--;
            }
            else if (!char.IsLetterOrDigit(s[left]))
            {
                left++;
            }
            else if (!char.IsLetterOrDigit(s[right]))
            {
                right--;
            }
        }

        return char.ToLowerInvariant(s[left]) == char.ToLowerInvariant(s[right]);
    }
}

//10 min [O(n), O(1)]
public class ThirdSolution
{
    public bool isPalindrome(string s)
    {
        for (int i = 0, j = s.Length - 1; i < j;)
        {
            var iCh = char.ToLowerInvariant(s[i]);
            var jCh = char.ToLowerInvariant(s[j]);

            if (!char.IsAsciiLetterOrDigit(iCh))
            {
                i++;
                continue;
            }
            if (!char.IsAsciiLetterOrDigit(jCh))
            {
                j--;
                continue;
            }

            i++;
            j--;

            if (iCh != jCh)
                return false;
        }

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
