//first attempt 10 min [O(n), O(1)]
public class Solution
{
    public int RemoveDuplicates(int[] nums)
    {
        var slow = 0;
        var fast = 0;

        while (fast < nums.Length)
        {
            if (nums[slow] == nums[fast])
            {
                fast++;
            }
            else
            {
                nums[slow] = nums[fast - 1];
                slow++;
                nums[slow] = nums[fast];
            }
        }

        return slow + 1;
    }
}