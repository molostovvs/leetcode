using System.Text;
using FluentAssertions;
using NUnit.Framework;

public class Program
{
    public static void Main() {}
}

//first attempt (ugliest solution ever) 20 min [O(n), O(1)]
public class UglySolution
{
    public string AddBinary(string a, string b)
    {
        var sb = new StringBuilder();
        var overhead = 0;

        var minLength = Math.Min(a.Length, b.Length);
        for (var i = 1; i <= minLength; i++)
            if (a[^i] == '1' && b[^i] == '1')
            {
                if (overhead == 0)
                {
                    sb.Append(0);
                    overhead = 1;
                }
                else
                {
                    sb.Append(1);
                }
            }
            else if (a[^i] == '0' && b[^i] == '0')
            {
                if (overhead == 0)
                {
                    sb.Append(0);
                }
                else
                {
                    sb.Append(1);
                    overhead = 0;
                }
            }
            else if (overhead == 0)
            {
                sb.Append(1);
            }
            else
            {
                sb.Append(0);
            }

        var maxLength = Math.Max(a.Length, b.Length);
        var maxString = a.Length > b.Length ? a : b;
        for (var i = minLength + 1; i <= maxLength; i++)
            if (maxString[^i] == '1')
                if (overhead == 0)
                    sb.Append(1);
                else
                    sb.Append(0);
            else if (maxString[^i] == '0')
                if (overhead == 0)
                {
                    sb.Append(0);
                }
                else
                {
                    sb.Append(1);
                    overhead = 0;
                }

        if (overhead > 0)
            sb.Append(overhead);

        var arr = sb.ToString().ToCharArray().Reverse().ToArray();
        return new string(arr);
    }
}

//first attempt 20 min much more clean code
public class Solution
{
    public string AddBinary(string a, string b)
    {
        var res = new List<int>();
        var overhead = '0';

        var minLength = Math.Min(a.Length, b.Length);
        var maxLength = Math.Max(a.Length, b.Length);
        var maxStr = a.Length > b.Length ? a : b;
        var minStr = a.Length > b.Length ? b : a;

        for (var i = 1; i <= maxLength; i++)
        {
            var maxCh = maxStr[^i];
            var minCh = '0';
            if (i <= minLength)
                minCh = minStr[^i];

            var sum = minCh + maxCh + overhead;

            if (sum == '1' + '1' + '1')
            {
                res.Add(1);
                overhead = '1';
            }
            else if (sum == '1' + '1' + '0')
            {
                res.Add(0);
                overhead = '1';
            }
            else
            {
                res.Add(sum % ('0' + '0' + '0'));
                if (overhead == '1')
                    overhead = '0';
            }
        }

        if (overhead == '1')
            res.Add(1);

        res.Reverse();
        return string.Concat(res);
    }
}

[TestFixture]
public class Tests
{
    private static Solution s = new();

    [TestCase("11", "1", "100")]
    [TestCase("1010", "1011", "10101")]
    [TestCase("0", "0", "0")]
    [TestCase("0", "1", "1")]
    [TestCase("110010", "10111", "1001001")]
    public static void Example(string a, string b, string expected)
    {
        var result = s.AddBinary(a, b);
        result.Should().Be(expected);
    }
}