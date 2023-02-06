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
public class OldSolution
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

//second attempt 13 min ugly code [O(n), O(1)]
public class Solution
{
    public int ClimbStairs(int n)
    {
        var v1 = 1;
        var v2 = 2;
        var v3 = -1;
        if (n == 1)
            return v1;
        if (n == 2)
            return v2;

        var steps = 3;
        while (steps <= n)
        {
            v3 = v2 + v1;
            v1 = v2;
            v2 = v3;
            steps++;
        }

        return v3;
    }
}