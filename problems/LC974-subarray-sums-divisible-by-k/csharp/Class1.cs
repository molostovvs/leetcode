using FluentAssertions;
using NUnit.Framework;

namespace _974._Subarray_Sums_Divisible_by_K;

public class Program
{
    public static void Main() {}
}

/*//time limit
public class Solution
{
    public int SubarraysDivByK(int[] nums, int k)
    {
        var res = 0;

        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] % k == 0)
                res++;
            for (var j = i + 1; j < nums.Length; j++)
            {
                var sum = GetSumInArray(nums, i, j);
                if (sum % k == 0)
                    res++;
            }
        }

        return res;
    }

    private int GetSumInArray(int[] nums, int i, int j)
    {
        var sum = 0;
        for (; i <= j; i++)
            sum += nums[i];

        return sum;
    }
}*/

public class Solution
{
    public int SubarraysDivByK(int[] nums, int k)
    {
        var prefixSum = 0;
        var count = 0;
        // key - remainder of dividing the prefix sum by K, value - number of occurencies
        var dict = new Dictionary<int, int>(new[] { new KeyValuePair<int, int>(0, 1) });

        foreach (var n in nums)
        {
            prefixSum += n;
            var x = prefixSum % k < 0 ? prefixSum % k + k : prefixSum % k; //converting negative mod to positive
            if (!dict.TryAdd(x, 1))
            {
                count += dict[x];
                dict[x]++;
            }
        }

        return count;
    }
}

[TestFixture]
public class Tests
{
    private static Solution s = new();

    [TestCase(new[] { 4, 5, 0, -2, -3, 1 }, 5, 7)]
    [TestCase(new[] { 5 }, 5, 1)]
    [TestCase(new[] { -1, 2, 9 }, 2, 2)]
    [TestCase(new[] { 2, -2, 2, -4 }, 6, 2)]
    public static void Example(int[] nums, int k, int expected)
    {
        var result = s.SubarraysDivByK(nums, k);
        result.Should().Be(expected);
    }

    [Test]
    public static void BigExample()
    {
        var nums = Enumerable.Repeat(0, 10000).ToArray();
        var k = 10000;
        var result = s.SubarraysDivByK(nums, k);
        var expected = 50005000;
        result.Should().Be(expected);
    }
}