using FluentAssertions;
using NUnit.Framework;

namespace _88._Merge_Sorted_Array;

public class P
{
    static void Main(string[] args) {}
}

public class Solution
{
    public void Merge(int[] nums1, int m, int[] nums2, int n)
    {
        /*var res = new int[m + n]; // naive solution using additional array and copy
        var i = 0;
        var j = 0;
        var k = 0;

        while (i < m && j < n)
        {
            if (nums1[i] < nums2[j])
            {
                res[k] = nums1[i];
                i++;
            }
            else
            {
                res[k] = nums2[j];
                j++;
            }

            k++;
        }

        if (i < m)
            for (var x = i; i < m; x++, i++, k++)
                res[k] = nums1[i];
        else if (j < n)
            for (var x = j; j < n; x++, j++, k++)
                res[k] = nums2[j];

        Array.Copy(res, nums1, m + n);*/

        /*var pointer = nums1.Length - 1; //solution using pointers time - O(n), space O(1)

        while (m > 0 && n > 0)
        {
            if (nums1[m - 1] > nums2[n - 1])
            {
                nums1[pointer] = nums1[m - 1];
                m--;
            }
            else if (nums2[n - 1] >= nums1[m - 1])
            {
                nums1[pointer] = nums2[n - 1];
                n--;
            }

            pointer--;
        }

        if (m == 0)
            while (n != 0)
            {
                nums1[pointer] = nums2[n - 1];
                pointer--;
                n--;
            }

        if (n == 0)
            while (m != 0)
            {
                nums1[pointer] = nums1[m - 1];
                pointer--;
                m--;
            }*/
    }
}

[TestFixture]
public class Tests
{
    public static Solution s = new();

    [Test]
    public static void Example()
    {
        var nums1 = new[] { 1, 2, 3, 0, 0, 0 };
        var nums2 = new[] { 2, 5, 6 };
        s.Merge(nums1, 3, nums2, 3);
        var expected = new[] { 1, 2, 2, 3, 5, 6 };
        Assert.AreEqual(expected, nums1);
    }
}