using FluentAssertions;
using NUnit.Framework;

public class Program
{
    public static void Main() {}
}

/*// [O(n), O(n)]
public class Solution
{
    public int[] ProductExceptSelf(int[] nums)
    {
        var prod = 1;
        var ans = new int[nums.Length];

        var help = new (int left, int right)[nums.Length];
        help[0].left = 1;
        help[^1].right = 1;

        for (var i = 1; i < ans.Length; i++)
            help[i].left = help[i - 1].left * nums[i - 1];

        for (var i = nums.Length - 2; i >= 0; i--)
            help[i].right = help[i + 1].right * nums[i + 1];

        ans[0] = help[0].right;
        ans[^1] = help[^1].left;
        for (var i = 1; i < ans.Length - 1; i++)
            ans[i] = help[i].left * help[i].right;

        return ans;
    }
}*/

// [O(n), O(1)]
public class Solution
{
    public int[] ProductExceptSelf(int[] nums)
    {
        var ans = new int[nums.Length];
        ans[0] = 1;

        for (var i = 1; i < nums.Length; i++)
            ans[i] = ans[i - 1] * nums[i - 1];

        var postfix = 1;
        for (var i = ans.Length - 1; i >= 0; i--)
        {
            ans[i] *= postfix;
            postfix *= nums[i];
        }

        return ans;
    }
}

[TestFixture]
public class Tests
{
    private static Solution s = new();

    [TestCase(new[] { 1, 2, 3, 4 }, new[] { 24, 12, 8, 6 })]
    public static void Example(int[] nums, int[] expected)
    {
        var result = s.ProductExceptSelf(nums);
        result.Should().BeEquivalentTo(expected, opt => opt.WithStrictOrdering());
    }
}