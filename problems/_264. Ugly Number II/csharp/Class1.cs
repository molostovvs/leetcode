//first attempt (spied) 30 min [O(n), O(1)]
public class Solution
{
    public int NthUglyNumber(int n)
    {
        int t2 = 0, t3 = 0, t5 = 0;
        var dp = new int[n];
        dp[0] = 1;
        for (var i = 1; i < n; i++)
        {
            dp[i] = Math.Min(dp[t2] * 2, Math.Min(dp[t3] * 3, dp[t5] * 5));
            if (dp[i] == dp[t2] * 2)
                t2++;
            if (dp[i] == dp[t3] * 3)
                t3++;
            if (dp[i] == dp[t5] * 5)
                t5++;
        }

        return dp[^1];
    }
}