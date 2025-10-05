/*//naive solution [O(n log n), O(n)]
public class Solution
{
    public int[] SortedSquares(int[] nums)
        => nums.Select(x => x * x).OrderBy(x => x).ToArray();
}*/

// [O(n), O(1)]

public class Solution
{
    public int[] SortedSquares(int[] nums)
    {
        nums[0] *= nums[0];
        for (var i = 1; i < nums.Length; i++)
        {
            var cur = nums[i] * nums[i];
            var prev = nums[i - 1];

            if (cur < prev)
            {
                nums[i - 1] = cur;
                nums[i] = prev;
                DrownItem(cur, i - 1, nums);
            }
            else
            {
                nums[i] = cur;
                nums[i - 1] = prev;
            }
        }

        return nums;
    }

    private void DrownItem(int item, int index, int[] nums)
    {
        for (var i = index; i > 0; i--)
        {
            var prev = nums[i - 1];
            if (prev < item)
                break;
            nums[i - 1] = item;
            nums[i] = prev;
        }
    }
}