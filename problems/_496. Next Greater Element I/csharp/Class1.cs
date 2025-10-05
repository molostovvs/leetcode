using FluentAssertions;
using NUnit.Framework;

namespace _496._Next_Greater_Element_I;

public class Program
{
    public static void Main() {}
}

public class Solution
{
    public int[] NextGreaterElement(int[] nums1, int[] nums2)
    {
        /*// brute force [O(m^2), O(1)]
        var res = new int[nums1.Length];

        for (var x = 0; x < nums1.Length; x++)
        {
            for (var j = 0; j < nums2.Length; j++)
                if (nums1[x] == nums2[j])
                    for (var k = j + 1; k < nums2.Length; k++)
                        if (nums2[k] > nums1[x])
                        {
                            res[x] = nums2[k];
                            break;
                        }

            if (res[x] == 0)
                res[x] = -1;
        }

        return res;*/

        /*// brute force [O(n*m), O(n)]
        var res = new int[nums1.Length];
        var dict = new Dictionary<int, int>();
        for (var i = 0; i < nums1.Length; i++)
            dict.Add(nums1[i], i);

        for (var j = 0; j < nums2.Length; j++)
        {
            if (!dict.ContainsKey(nums2[j]))
                continue;

            res[dict[nums2[j]]] = -1;
            var n = nums2[j];

            for (var k = j + 1; k < nums2.Length; k++)
                if (nums2[k] > n)
                {
                    res[dict[nums2[j]]] = nums2[k];
                    break;
                }
        }

        return res;*/

        //smart solution [O(n+m), O(n)]
        var res = Enumerable.Repeat(-1, nums1.Length).ToArray();
        var dict = nums1.Select((value, index) => new { value, index })
                        .ToDictionary(pair => pair.value, pair => pair.index);
        var stack = new Stack<int>();

        foreach (var curr in nums2)
        {
            while (stack.Count > 0 && curr > stack.Peek())
            {
                var val = stack.Pop();
                var index = dict[val];
                res[index] = curr;
            }

            if (dict.ContainsKey(curr))
                stack.Push(curr);
        }

        return res;
    }
}

[TestFixture]
public class Tests
{
    private static Solution s = new();

    [TestCase(new[] { 1, 2 }, new[] { 1, 2, 3 }, new[] { 2, 3 })]
    [TestCase(new[] { 4, 1, 2 }, new[] { 1, 3, 4, 2 }, new[] { -1, 3, -1 })]
    [TestCase(new[] { 4, 1, 2 }, new[] { 1, 2, 3, 4 }, new[] { -1, 2, 3 })]
    [TestCase(new[] { 2, 4 }, new[] { 1, 2, 3, 4 }, new[] { 3, -1 })]
    [TestCase(new[] { 1, 3, 5, 2, 4 }, new[] { 6, 5, 4, 3, 2, 1, 7 }, new[] { 7, 7, 7, 7, 7 })]
    public static void Example(int[] nums1, int[] nums2, int[] expected)
    {
        var result = s.NextGreaterElement(nums1, nums2);
        result.Should().BeEquivalentTo(expected, opt => opt.WithStrictOrdering());
    }
}