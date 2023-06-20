using System.Collections;

public class Program
{
    static void Main(string[] args) {}
}

public class OldSolution
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

// second attempt 7 min [O(n), O(n)]
public class SecondSolution
{
    public int[] TwoSum(int[] nums, int target)
    {
        var d = new Dictionary<int, List<int>>();
        for (int i = 0; i < nums.Length; i++)
        {
            if (!d.TryAdd(nums[i], new List<int> { i }))
                d[nums[i]].Add(i);
        }

        for (int i = 0; i < nums.Length; i++)
        {
            var need = target - nums[i];
            if (d.ContainsKey(need) && d[need].Where(x => x != i).Count() > 0)
                return new[] { i, d[need].First(x => x != i) };
        }

        return null;
    }
}

// ~SPIED~ third attempt after a long time from previous 30 min [O(n), O(n)]
public class ThirdSolution
{
    public int[] TwoSum(int[] nums, int target)
    {
        var d = new Dictionary<int, List<int>>();

        for (int i = 0; i < nums.Length; i++)
            if (!d.TryAdd(nums[i], new List<int> { i }))
                d[nums[i]].Add(i);

        for (int i = 0; i < nums.Length; i++)
        {
            var need = target - nums[i];
            if (d.ContainsKey(need) && d[need].Where(x => x != i).Count() > 0)
                return new[] { i, d[need].First(x => x != i) };
        }

        return null;
    }
}