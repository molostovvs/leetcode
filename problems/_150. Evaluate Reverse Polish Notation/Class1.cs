using FluentAssertions;
using NUnit.Framework;

public class Program
{
    public static void Main() {}
}

public class Solution
{
    public int EvalRPN(string[] tokens)
    {
        var s = new Stack<int>();
        var operations = new Dictionary<string, Func<int, int, int>>();
        operations.Add("+", (x, y) => y + x);
        operations.Add("-", (x, y) => y - x);
        operations.Add("*", (x, y) => y * x);
        operations.Add("/", (x, y) => y / x);

        foreach (var str in tokens)
            if (str != "+" && str != "-" && str != "*" && str != "/")
                s.Push(int.Parse(str));
            else
                s.Push(operations[str].Invoke(s.Pop(), s.Pop()));

        return s.Pop();
    }
}

[TestFixture]
public class Tests
{
    private static Solution s = new Solution();

    [TestCase(new[] { "4", "13", "5", "/", "+" }, 6)]
    public static void Example(string[] tokens, int expected)
    {
        var result = s.EvalRPN(tokens);
        result.Should().Be(expected);
    }
}