//first attempt 20 min (spied) [O(n), O(n)]
public class Solution
{
    public int WiggleMaxLength(int[] nums)
    {
        if (nums.Length == 0)
            return nums.Length;

        var up = new int[nums.Length];
        var down = new int[nums.Length];

        up[0] = 1;
        down[0] = 1;

        for (var i = 1; i < nums.Length; i++)
            if (nums[i] > nums[i - 1])
            {
                up[i] = down[i - 1] + 1;
                down[i] = down[i - 1];
            }
            else if (nums[i] < nums[i - 1])
            {
                down[i] = up[i - 1] + 1;
                up[i] = up[i - 1];
            }
            else
            {
                down[i] = down[i - 1];
                up[i] = up[i - 1];
            }

        return Math.Max(up[^1], down[^1]);
    }
}