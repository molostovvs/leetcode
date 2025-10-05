using FluentAssertions;
using NUnit.Framework;

public class Program
{
    public static void Main() {}
}

//first attempt 25 min [O(n*k), O(k)]
public class Solution
{
    public IList<IList<int>> Combine(int n, int k)
        => Helper(new int[k], 0, 1, n).Cast<IList<int>>().ToList();

    private IEnumerable<int[]> Helper(int[] arr, int index, int start, int max)
    {
        if (index == arr.Length)
            yield return (int[])arr.Clone();
        else
            while (start <= max)
            {
                arr[index] = start++;
                foreach (var ints in Helper(arr, index + 1, start, max))
                    yield return ints;
            }
    }
}

[TestFixture]
public class Tests
{
    private static Solution s = new();

    [TestCase(1, 1)]
    public static void N1K1(int n, int k)
    {
        var result = s.Combine(n, k);
        var expected = new List<List<int>>
        {
            new(new[] { 1 }),
        };

        result.Should().BeEquivalentTo(expected);
    }

    [TestCase(5, 1)]
    public static void N5K1(int n, int k)
    {
        var result = s.Combine(n, k);
        var expected = new List<List<int>>
        {
            new(new[] { 1 }),
            new(new[] { 2 }),
            new(new[] { 3 }),
            new(new[] { 4 }),
            new(new[] { 5 }),
        };

        result.Should().BeEquivalentTo(expected);
    }
}