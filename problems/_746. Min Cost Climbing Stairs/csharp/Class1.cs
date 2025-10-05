/*//using array [O(n), O(n)]
public class Solution
{
    public int MinCostClimbingStairs(int[] cost)
    {
        var dp = new int[cost.Length];

        dp[dp.Length - 1] = cost[cost.Length - 1];
        dp[dp.Length - 2] = cost[cost.Length - 2];

        for (var i = dp.Length - 3; i >= 0; i--)
            dp[i] = cost[i] + Math.Min(dp[i + 1], dp[i + 2]);

        return Math.Min(dp[0], dp[1]);
    }
}*/

// [O(n), O(1)]
public class OldSolution
{
    public int MinCostClimbingStairs(int[] cost)
    {
        var prepre = cost[cost.Length - 1];
        var pre = cost[cost.Length - 2];
        var cur = int.MaxValue;

        for (var i = cost.Length - 3; i >= 0; i--)
        {
            cur = cost[i] + Math.Min(prepre, pre);
            prepre = pre;
            pre = cur;
        }

        return Math.Min(pre, prepre);
    }
}

//second attempt 24 min [O(n), O(1)]
public class Solution
{
    public int MinCostClimbingStairs(int[] arr)
    {
        var t1 = arr[0];
        var t2 = arr[1];
        if (arr.Length < 3)
            return Math.Min(t1, t2);

        var cost = 0;
        for (var i = 2; i < arr.Length; i++)
        {
            cost = Math.Min(t1 + arr[i], t2 + arr[i]);
            t1 = t2;
            t2 = cost;
        }

        return Math.Min(cost, t1);
    }
}