public class Solution
{
    public int RemoveElement(int[] nums, int val)
    {
        var end = nums.Length - 1;
        for (var i = 0; i <= end; i++)
            if (nums[i] == val)
                for (; end >= i; end--)
                    if (nums[end] != val || end == i)
                    {
                        (nums[i], nums[end]) = (nums[end], nums[i]);
                        end--;
                        break;
                    }

        return nums.Length - (nums.Length - 1 - end);
    }
}