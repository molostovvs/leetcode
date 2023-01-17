using FluentAssertions;
using NUnit.Framework;

namespace _1790._Check_if_One_String_Swap_Can_Make_Strings_Equal;

public class Program
{
    public static void Main() {}
}

public class Solution
{
    public bool AreAlmostEqual(string s1, string s2)
    {
        /*// solution with list [O(n), O(1)]
        if (s1 == s2)
            return true;

        var list = new List<(char, char)>();
        for (var i = 0; i < s1.Length; i++)
        {
            if (s1[i] != s2[i])
                list.Add((s1[i], s2[i]));
            if (list.Count > 2)
                return false;
        }

        if (list.Count != 2)
            return false;
        if (list[0].Item1 == list[1].Item2 && list[0].Item2 == list[1].Item1)
            return true;
        return false;*/

        //solution without list [O(n), O(1)]
        var firstDiff = -1;
        var secondDiff = -1;

        for (var i = 0; i < s1.Length; i++)
            if (s1[i] != s2[i])
                if (firstDiff == -1)
                    firstDiff = i;
                else if (secondDiff == -1)
                    secondDiff = i;
                else
                    return false;

        if (firstDiff == -1)
            return true;
        if (secondDiff == -1)
            return false;
        return s1[firstDiff] == s2[secondDiff] && s1[secondDiff] == s2[firstDiff];
    }
}

[TestFixture]
public class Tests
{
    private static Solution s = new();

    [TestCase("a", "b", false)]
    [TestCase("aa", "ax", false)]
    [TestCase("abc", "cba", true)]
    public static void Example(string s1, string s2, bool expected)
    {
        var result = s.AreAlmostEqual(s1, s2);
        result.Should().Be(expected);
    }
}