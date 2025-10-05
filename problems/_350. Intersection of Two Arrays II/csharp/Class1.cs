using FluentAssertions;
using NUnit.Framework;

public class Program
{
    public static void Main() {}
}

//first attempt 
public class OldSolution
{
    public int[] Intersect(int[] nums1, int[] nums2)
    {
        /*if (nums1.Length > nums2.Length) //time O(n + m) space O(n)
            return Intersect(nums2, nums1);

        var dict = new Dictionary<int, int>();
        var result = new List<int>();

        foreach (var n in nums1)
            if (!dict.TryAdd(n, 0))
                dict[n]++;

        foreach (var x in nums2)
            if (dict.ContainsKey(x) && dict[x] >= 0)
            {
                result.Add(x);
                dict[x]--;
            }

        return result.ToArray();*/

        var result = new List<int>(); // naive solution time O(n * m^2) space O(m)
        var bannedIndexes = new HashSet<int>();
        for (int i = 0; i < nums1.Length; i++)
        {
            var n = nums1[i];
            for (var k = 0; k < nums2.Length; k++)
                if (n == nums2[k] && !bannedIndexes.Contains(k))
                {
                    result.Add(nums2[k]);
                    bannedIndexes.Add(k);
                    break;
                }
        }

        return result.ToArray();

        /*Array.Sort(nums1); // time O(n*logn + m*logm) space(sorting algorithm complexity for space)
        Array.Sort(nums2);
        var result = new List<int>();

        for (int i = nums1.Length - 1, j = nums2.Length - 1; i >= 0 && j >= 0;)
            if (nums1[i] < nums2[j])
            {
                j--;
            }
            else if (nums2[j] < nums1[i])
            {
                i--;
            }
            else
            {
                result.Add(nums1[i]);
                i--;
                j--;
            }

        return result.ToArray();*/
    }
}

//second attempt 8 min [O(nlogn + mlogm), O(sorting)]
public class Solution
{
    public int[] Intersect(int[] nums1, int[] nums2)
    {
        var res = new List<int>();

        Array.Sort(nums1);
        Array.Sort(nums2);

        for (int l = 0, r = 0; l < nums1.Length && r < nums2.Length;)
            if (nums1[l] == nums2[r])
            {
                res.Add(nums1[l]);
                l++;
                r++;
            }
            else if (nums1[l] < nums2[r])
            {
                l++;
            }
            else if (nums1[l] > nums2[r])
            {
                r++;
            }

        return res.ToArray();
    }
}

[TestFixture]
public class Tests
{
    private static Solution s = new();

    [TestCase(new[] { 1, 2, 2, 1 }, new[] { 2, 2 }, new[] { 2, 2 })]
    [TestCase(new[] { 4, 9, 5 }, new[] { 9, 4, 9, 8, 4 }, new[] { 9, 4 })]
    public static void Example(int[] n1, int[] n2, int[] expected)
    {
        var result = s.Intersect(n1, n2);
        result.Should().BeEquivalentTo(expected);
    }
}