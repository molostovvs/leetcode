//first attempt 4 min [O(n), O(1)]
public class Solution
{
    public int[] Shuffle(int[] nums, int n)
    {
        var res = new int[nums.Length];
        for (int left = 0, right = nums.Length / 2; right < nums.Length; left++, right++)
        {
            res[left * 2] = nums[left];
            res[left * 2 + 1] = nums[right];
        }

        return res;
    }
}