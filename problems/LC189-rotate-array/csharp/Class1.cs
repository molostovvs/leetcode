using FluentAssertions;
using NUnit.Framework;

public class Program
{
    public static void Main() {}
}

//naive solution [O(n * k), O(1)]
public class NaiveSolution
{
    public void Rotate(int[] nums, int k)
    {
        while (k > 0)
        {
            var prev = nums[0];
            for (var i = 1; i < nums.Length; i++)
            {
                (nums[i], prev) = (prev, nums[i]);
                if (i == nums.Length - 1)
                    nums[0] = prev;
            }

            k--;
        }
    }
}

//stupid method [O(n), O(n)]
public class StupidSolution
{
    public void Rotate(int[] nums, int k)
    {
        var res = new int[nums.Length];

        for (var i = 0; i < nums.Length; i++)
            res[(i + k) % nums.Length] = nums[i];
        res.CopyTo(nums, 0);
    }
}

//inplace method [O(n), O(1)]
public class Solution
{
    public void Rotate(int[] nums, int k)
    {
        k %= nums.Length;
        Array.Reverse(nums);

        for (int l = 0, r = k - 1; l < r; l++, r--)
            (nums[l], nums[r]) = (nums[r], nums[l]);

        for (int l = k, r = nums.Length - 1; l < r; l++, r--)
            (nums[l], nums[r]) = (nums[r], nums[l]);
    }
}

[TestFixture]
public class Tests
{
    private static Solution s = new Solution();

    [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7 }, 3, new[] { 5, 6, 7, 1, 2, 3, 4 })]
    [TestCase(new[] { 1, 2, 3 }, 3, new[] { 1, 2, 3 })]
    [TestCase(new[] { 1, 2, 3 }, 2, new[] { 2, 3, 1 })]
    [TestCase(new[] { 1 }, 0, new[] { 1 })]
    [TestCase(new[] { -1 }, 2, new[] { -1 })]
    [TestCase(new[] { 1, 2, 3 }, 1, new[] { 3, 1, 2 })]
    [TestCase(new[] { -1, -100, 3, 99 }, 2, new[] { 3, 99, -1, -100 })]
    public static void Example(int[] nums, int k, int[] expected)
    {
        s.Rotate(nums, k);
        nums.Should().BeEquivalentTo(expected, opt => opt.WithStrictOrdering());
    }
}