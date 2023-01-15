namespace _88._Merge_Sorted_Array;

public class Solution
{
    public void Merge(int[] nums1, int m, int[] nums2, int n)
    {
        var res = new int[m + n];
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

        Array.Copy(res, nums1, m + n);
    }
}