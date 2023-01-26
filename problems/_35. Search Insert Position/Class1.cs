public class Solution
{
    public int SearchInsert(int[] nums, int target)
    {
        var left = 0;
        var right = nums.Length - 1;

        while (left <= right)
        {
            if (left == right)
                break;
            var mid = left + (right - left) / 2;
            if (target < nums[mid])
                right = mid - 1;
            else if (target > nums[mid])
                left = mid + 1;
            else if (target == nums[mid])
                return mid;
        }

        if (nums[left] < target)
            return left + 1;
        return left;
    }
}