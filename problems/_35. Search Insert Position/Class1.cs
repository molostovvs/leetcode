/*//first attempt
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
}*/

//second attempt 5 min
public class Solution
{
    public int SearchInsert(int[] nums, int target)
    {
        var left = 0;
        var right = nums.Length - 1;

        while (left <= right)
        {
            var mid = left + (right - left) / 2;
            if (nums[mid] == target)
                return mid;
            if (nums[mid] < target)
                left = mid + 1;
            else
                right = mid - 1;
        }

        if (left >= nums.Length)
            return left;
        return nums[left] < target ? left + 1 : left;
    }
}