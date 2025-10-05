using FluentAssertions;
using NUnit.Framework;

namespace _202._Happy_Number;

public class Program
{
    public static void Main() {}
}

public class Solution
{
    public bool IsHappy(int n)
    {
        /*//Hashset solution [O(log n), O(log n)]
        var set = new HashSet<int>(); // time is O(log n) + O (log log n) + ... Result is O(log n), space is O(log n)
        while (n != 1)
        {
            n = n.GetAllDigits().Select(i => i * i).Sum(); //GetAllDigits is O(log n)
            if (!set.Add(n))
                return false;
        }

        return true;*/

        // two pointers solution [O(log n), O(1)]
        var slow = n.GetAllDigits().Sum(i => i * i);
        var fast = slow.GetAllDigits().Sum(i => i * i);

        while (fast != 1)
        {
            if (slow == fast)
                return false;
            slow = slow.GetAllDigits().Sum(i => i * i);
            fast = fast.GetAllDigits().Sum(i => i * i).GetAllDigits().Sum(i => i * i);
        }

        return true;
    }
}

public static class IntExtensions
{
    public static int[] GetAllDigits(this int n)
    {
        var result = new List<int>();
        while (n > 0)
        {
            result.Add(n % 10);
            n = n / 10;
        }

        result.Reverse();
        return result.ToArray();
    }
}

[TestFixture]
public class Tests
{
    private static Solution s = new();

    [TestCase(2, false)]
    [TestCase(5, false)]
    [TestCase(19, true)]
    [TestCase(12303210, true)]
    [TestCase((int)(int.MaxValue * 0.5), false)]
    [TestCase(int.MaxValue, false)]
    public static void Example(int n, bool expected)
    {
        var result = s.IsHappy(n);
        result.Should().Be(expected);
    }
}