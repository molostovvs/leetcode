using System.Collections;

public class Program
{
    static void Main(string[] args) {}
}

public class Solution
{
    public int[] TwoSum(int[] nums, int target)
    {
        /*for (int i = 0; i < nums.Length; i++) // O(n^2)
        {
            for (int j = nums.Length - 1; j > i; j--)
            {
                if (nums[i] + nums[j] == target)
                    return new[] { i, j };
            }
        }

        return null;*/

        var table = new Dictionary<int, int>(); // (number, position in array)

        for (var i = 0; i < nums.Length; i++)
        {
            var need = target - nums[i];
            if (table.ContainsKey(need))
                return new[] { table[need], i };
            table.TryAdd(nums[i], i);
        }

        return null;
    }
}