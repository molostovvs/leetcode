using FluentAssertions;
using NUnit.Framework;

public class Program
{
    public static void Main() { }
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

//25 min [O(n^3), O(1)] - TLE
public class SecondBadSolution
{
    public IList<IList<int>> ThreeSum(int[] nums)
    {
        var res = new List<IList<int>>();

        var set = new HashSet<(int, int, int)>();

        for (var i = 0; i <= nums.Length - 3; i++)
            for (var j = i + 1; j <= nums.Length - 2; j++)
                for (var k = j + 1; k <= nums.Length - 1; k++)
                    if (nums[i] + nums[j] + nums[k] == 0)
                    {
                        var candidate = new[] { nums[i], nums[j], nums[k] };

                        Array.Sort(candidate);

                        if (set.Add((candidate[0], candidate[1], candidate[2])))
                            res.Add(candidate);
                    }

        return res;
    }
}

//40 min spied [O(n^2), O(1)] - not sure about space complexity
//since it depends on sorting algorithm
public class SecondSolution
{
    public IList<IList<int>> ThreeSum(int[] nums)
    {
        var res = new List<IList<int>>();

        Array.Sort(nums);

        int start = 0, left, right, target;

        while (start < nums.Length - 2)
        {
            target = nums[start] * -1;
            left = start + 1;
            right = nums.Length - 1;

            while (left < right)
            {
                if (nums[left] + nums[right] > target)
                    right--;
                else if (nums[left] + nums[right] < target)
                    left++;
                else
                {
                    var solution = new[] { nums[start], nums[left], nums[right] };
                    res.Add(solution);

                    while (left < right && nums[left] == solution[1])
                        left++;
                    while (left < right && nums[right] == solution[2])
                        right--;
                }
            }

            var curStart = nums[start];

            while (start < nums.Length - 2 && nums[start] == curStart)
                start++;
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
