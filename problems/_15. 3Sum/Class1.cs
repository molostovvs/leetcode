using FluentAssertions;
using NUnit.Framework;

public class Program
{
    public static void Main() {}
}

//[O(n^2), O(1)]
public class Solution
{
    public IList<IList<int>> ThreeSum(int[] nums)
    {
        Array.Sort(nums);
        var res = new List<IList<int>>();

        for (int slow = 0; slow < nums.Length - 2; slow++)
        {
            if (slow > 0 && nums[slow] == nums[slow - 1])
                continue;

            var medium = slow + 1;
            var fast = nums.Length - 1;
            while (medium < fast)
            {
                var sum = nums[slow] + nums[medium] + nums[fast];
                if (sum > 0)
                {
                    fast--;
                }
                else if (sum < 0)
                {
                    medium++;
                }
                else
                {
                    res.Add(new[] { nums[slow], nums[medium], nums[fast] });
                    medium++;
                    while (nums[medium] == nums[medium - 1] && medium < fast)
                        medium++;
                }
            }
        }

        return res;
    }
}

[TestFixture]
public class Tests
{
    private static Solution s = new Solution();

    [Test]
    public static void Example()
    {
        var inp = new[] { -1, 0, 1, 2, -1, -4 };
        var result = s.ThreeSum(inp);
        var expected = new List<IList<int>> { new[] { -1, -1, 2 }, new[] { -1, 0, 1 } };
        result.Should().BeEquivalentTo(expected);
    }
}