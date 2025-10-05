//first attempt (spied) 35 min [O(n), O(n)]
public class Solution
{
    public int NumTrees(int n)
    {
        var dp = new int[n + 1];
        dp[0] = 1;
        dp[1] = 1;

        for (var level = 2; level <= n; level++)
            for (var root = 1; root <= level; root++)
                dp[level] += dp[level - root] * dp[root - 1];

        return dp[^1];
    }
}