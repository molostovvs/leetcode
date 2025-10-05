using System.Text;
using FluentAssertions;
using NUnit.Framework;

public class Program
{
    public static void Main() {}
}

//fucking genius [O(n), O(1)]
public class Solution
{
    public string Convert(string s, int numRows)
    {
        if (numRows == 1 || numRows >= s.Length)
            return s;
        //minus 2 because we dont want to take into account items in rows with index 0 and row
        var diagonal = numRows - 2;
        var sb = new StringBuilder();

        for (var i = 0; i < numRows; i++)
        {
            var curIndex = i;
            while (curIndex < s.Length)
            {
                sb.Append(s[curIndex]);
                if (i != 0 && i != numRows - 1)
                {
                    var step = numRows + diagonal - 2 * i;
                    if (curIndex + step < s.Length)
                        sb.Append(s[curIndex + step]);
                }

                curIndex += numRows + diagonal;
            }
        }

        return sb.ToString();
    }
}

[TestFixture]
public class Tests
{
    private static Solution s = new();

    [TestCase("PAYPALISHIRING", 3, "PAHNAPLSIIGYIR")]
    [TestCase("A", 1, "A")]
    [TestCase("A", 3, "A")]
    [TestCase("ABCDEFG", 3, "AEBDFCG")]
    [TestCase("ABCDEFG", 2, "ACEGBDF")]
    [TestCase("ABCDEFG", 4, "AGBFCED")]
    [TestCase("AB", 4, "AB")]
    public static void Example(string input, int rows, string expected)
    {
        var result = s.Convert(input, rows);
        result.Should().Be(expected);
    }
}