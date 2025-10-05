using FluentAssertions;
using NUnit.Framework;

public class Program
{
    public static void Main() {}
}

//__first attempt 40 min [O(n), O(1)]
public class Solution
{
    public int TotalFruit(int[] arr)
    {
        var d = new Dictionary<int, int>();
        var res = 0;

        for (int left = 0, right = 0; right < arr.Length; right++)
        {
            if (!d.TryAdd(arr[right], 1))
                d[arr[right]]++;

            while (d.Count > 2)
            {
                d[arr[left]]--;
                if (d[arr[left]] == 0)
                    d.Remove(arr[left]);
                left++;
            }

            var curRes = d.Values.Sum();
            res = curRes > res ? curRes : res;
        }

        return res;
    }
}

[TestFixture]
public class Tests
{
    private static Solution s = new();

    [TestCase(new[] { 1, 2, 1 }, 3)]
    [TestCase(new[] { 1, 2, 3, 2, 2 }, 4)]
    [TestCase(new[] { 0, 1, 2, 2 }, 3)]
    [TestCase(new[] { 1, 0, 1, 4, 1, 4, 1, 2, 3 }, 5)]
    public static void Example(int[] inp, int expected)
    {
        var result = s.TotalFruit(inp);
        result.Should().Be(expected);
    }
}