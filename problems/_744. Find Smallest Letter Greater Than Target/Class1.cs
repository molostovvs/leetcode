using FluentAssertions;
using NUnit.Framework;

public class Program
{
    public static void Main() {}
}

//first attempt
public class Solution
{
    public char NextGreatestLetter(char[] letters, char target)
    {
        var left = 0;
        var right = letters.Length;

        while (left < right)
        {
            var mid = left + (right - left) / 2;
            if (left >= letters.Length)
                break;
            if (letters[mid] > target)
                right = mid - 1;
            else
                left = mid + 1;
        }

        return left >= letters.Length ? letters[0] : letters[left];
    }
}

[TestFixture]
public class Tests
{
    private static Solution s = new Solution();

    [TestCase(new[] { 'c', 'f', 'j' }, 'a', 'c')]
    [TestCase(new[] { 'x', 'x', 'y', 'y' }, 'z', 'x')]
    public static void Example(char[] inp, char target, char expected)
    {
        var result = s.NextGreatestLetter(inp, target);
        result.Should().Be(expected);
    }
}