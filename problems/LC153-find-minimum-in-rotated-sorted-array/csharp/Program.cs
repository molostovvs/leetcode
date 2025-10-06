public class Solution
{
    public int FindMin(int[] nums)
    {
        var left = 0;
        var right = nums.Length - 1;

        while (left < right)
        {
            var mid = left + (right - left) / 2;

            if (nums[mid] < nums[right])
                right = mid;
            else
                left = mid + 1;
        }

        return nums[right];
    }
}