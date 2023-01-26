using System.Text;
using FluentAssertions;
using NUnit.Framework;

public class Program
{
    public static void Main() {}
}

//[O(s + t), O(s + t)]
public class NaiveSolution
{
    public bool BackspaceCompare(string s, string t)
    {
        var sbs = new StringBuilder();
        var sbt = new StringBuilder();

        foreach (var c in s)
            if (c != '#')
            {
                sbs.Append(c);
            }
            else
            {
                if (sbs.Length > 0)
                    sbs.Remove(sbs.Length - 1, 1);
            }

        foreach (var c in t)
            if (c != '#')
            {
                sbt.Append(c);
            }
            else
            {
                if (sbt.Length > 0)
                    sbt.Remove(sbt.Length - 1, 1);
            }

        return sbs.ToString() == sbt.ToString();
    }
}

//[O(s), O(1)]
public class Solution
{
    public bool BackspaceCompare(string s, string t)
    {
        var skipsInS = 0;
        var skipsInT = 0;

        for (int sPointer = s.Length - 1, tPointer = t.Length - 1; sPointer >= 0 || tPointer >= 0;)
        {
            while (sPointer >= 0)
            {
                if (s[sPointer] == '#')
                {
                    skipsInS++;
                    sPointer--;
                }
                else if (skipsInS > 0)
                {
                    skipsInS--;
                    sPointer--;
                }
                else
                {
                    break;
                }
            }

            while (tPointer >= 0)
            {
                if (t[tPointer] == '#')
                {
                    skipsInT++;
                    tPointer--;
                }
                else if (skipsInT > 0)
                {
                    skipsInT--;
                    tPointer--;
                }
                else
                {
                    break;
                }
            }

            if (sPointer >= 0 && tPointer >= 0 && s[sPointer] != t[tPointer])
                return false;

            if (sPointer >= 0 != tPointer >= 0)
                return false;

            sPointer--;
            tPointer--;
        }

        return true;
    }
}

[TestFixture]
public class Tests
{
    private static Solution sol = new Solution();

    [TestCase("a##c", "#a#c", true)]
    [TestCase("ab#c", "ad#c", true)]
    [TestCase("ab##", "c#d#", true)]
    [TestCase("a#c", "b", false)]
    [TestCase("###", "b#", true)]
    [TestCase("xywrrmp", "xywrrmu#p", true)]
    public static void Example(string s, string t, bool expected)
    {
        var result = sol.BackspaceCompare(s, t);
        result.Should().Be(expected);
    }
}