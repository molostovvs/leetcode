public class Program
{
    static void Main(string[] args)
    {
        
    }
}

public class Solution 
{
    public int[] TwoSum(int[] nums, int target) 
    {
        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = nums.Length - 1; j > i; j--)
            {
                if (nums[i] + nums[j] == target)
                    return new[] { i, j };
            }
        }

        return null;
    }
}