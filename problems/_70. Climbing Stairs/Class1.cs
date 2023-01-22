namespace _70._Climbing_Stairs;

/*// [O(n), O(n)]
public class Solution
{
    public int ClimbStairs(int n)
    {
        var dp = new int[n + 1];
        dp[n] = 1;
        dp[n - 1] = 1;

        for (var i = n - 2; i >= 0; i--)
            dp[i] = dp[i + 1] + dp[i + 2];

        return dp[0];
    }
}*/

// [O(n), O(1)]
public class Solution
{
    public int ClimbStairs(int n)
    {
        var prepre = 1;
        var pre = 1;

        while (n - 1 > 0)
        {
            var cur = prepre + pre;
            prepre = pre;
            pre = cur;
            n--;
        }

        return pre;
    }
}