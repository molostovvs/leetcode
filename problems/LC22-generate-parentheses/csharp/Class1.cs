using FluentAssertions;
using NUnit.Framework;

public class Program
{
    public static void Main() {}
}

//NeetCode [O(?), O(?)]
public class Solution
{
    public IList<string> GenerateParenthesis(int n)
    {
        var st = new Stack<string>();

        return Backtrack(0, 0).ToList();

        IEnumerable<string> Backtrack(int open, int closed)
        {
            if (open == closed && closed == n)
                yield return string.Join("", st.Select(s => s).Reverse());

            if (open < n)
            {
                st.Push("(");
                foreach (var s in Backtrack(open + 1, closed))
                    yield return s;
                st.Pop();
            }

            if (closed < open)
            {
                st.Push(")");
                foreach (var s in Backtrack(open, closed + 1))
                    yield return s;
                st.Pop();
            }
        }
    }
}

[TestFixture]
public class Tests
{
    private static Solution s = new Solution();

    [TestCase(1, new[] { "()" })]
    public static void Example(int n, IList<string> expected)
    {
        var result = s.GenerateParenthesis(n);
        result.Should().BeEquivalentTo(expected, opt => opt.WithStrictOrdering());
    }
}