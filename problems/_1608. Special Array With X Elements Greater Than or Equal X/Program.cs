public class Solution
{
    public int SpecialArray(int[] nums)
    {
        Array.Sort(nums);
        var left = 0;
        var right = nums.Length - 1;

        while (left <= right)
        {
            var mid = left + (right - left) / 2;
            var n = nums.Length - mid;

            if (mid > 0 && nums[mid] >= n && nums[mid - 1] < n)
                return n;
            if (mid == 0 && nums[mid] >= n)
                return n;

            if (nums[mid] < n)
                left = mid + 1;
            else
                right = mid - 1;
        }

        return -1;
    }
}