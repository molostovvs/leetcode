using FluentAssertions;
using NUnit.Framework;

namespace _347._Top_K_Frequent_Elements;

public class Program
{
    public static void Main() {}
}

/*// [O(n + n log n), O(n)]
public class Solution
{
    public int[] TopKFrequent(int[] nums, int k)
    {
        var dict = new Dictionary<int, int>(); //value - freq
        foreach (var n in nums)
            if (!dict.TryAdd(n, 1))
                dict[n]++;

        return dict.OrderByDescending(kv => kv.Value).Take(k).Select(kv => kv.Key).ToArray();
    }
}*/

public class Solution
{
    public int[] TopKFrequent(int[] nums, int k)
    {
        var dict = new Dictionary<int, int>();
        foreach (var n in nums)
            if (!dict.TryAdd(n, 1))
                dict[n]++;

        var bucket = new List<int>[nums.Length];
        foreach (var kv in dict)
            if (bucket[kv.Value - 1] is null)
                bucket[kv.Value - 1] = new List<int>(new List<int>(new[] { kv.Key }));
            else
                bucket[kv.Value - 1].Add(kv.Key);

        var res = new int[k];
        var i = bucket.Length - 1;
        
        while (k > 0)
        {
            if (bucket[i] != null)
                foreach (var n in bucket[i])
                {
                    res[k - 1] = n;
                    k--;
                }

            i--;
        }

        return res;
    }
}

[TestFixture]
public class Tests
{
    private static Solution s = new();

    [TestCase(new[] { 1, 1, 1, 2, 2, 3 }, 2, new[] { 1, 2 })]
    [TestCase(new[] { 1 }, 1, new[] { 1 })]
    public static void Example(int[] nums, int k, int[] expected)
    {
        var result = s.TopKFrequent(nums, k);
        result.Should().BeEquivalentTo(expected);
    }
}