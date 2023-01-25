using FluentAssertions;
using NUnit.Framework;

public class Program
{
    public static void Main() {}
}

public class Solution
{
    public string GetHint(string secret, string guess)
    {
        var bulls = 0;
        var cows = 0;

        var d = new Dictionary<char, int>();
        foreach (var c in secret)
            if (!d.TryAdd(c, 1))
                d[c]++;

        for (var i = 0; i < secret.Length; i++)
            if (secret[i] == guess[i])
            {
                bulls++;
                d[guess[i]]--;
            }

        for (var i = 0; i < secret.Length; i++)
            if (secret[i] != guess[i] && d.ContainsKey(guess[i]) && d[guess[i]] > 0)
            {
                cows++;
                d[guess[i]]--;
            }

        return $"{bulls}A{cows}B";
    }
}

[TestFixture]
public class Tests
{
    private static Solution s = new Solution();

    [TestCase("1807", "7810", "1A3B")]
    [TestCase("1807", "1807", "4A0B")]
    [TestCase("1123", "0111", "1A1B")]
    [TestCase("5", "6", "0A0B")]
    [TestCase("5", "5", "1A0B")]
    [TestCase("5555", "5125", "2A0B")]
    [TestCase("1234", "1111", "1A0B")]
    [TestCase("1122", "1222", "3A0B")]
    public static void Example(string secret, string guess, string expected)
    {
        var result = s.GetHint(secret, guess);
        result.Should().Be(expected);
    }
}