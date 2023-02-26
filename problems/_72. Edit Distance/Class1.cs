//first attempt 35 min [O(m*n), O(m*n)]
public class Solution
{
    public int MinDistance(string word1, string word2)
    {
        var dp = new int[word1.Length + 1, word2.Length + 1];

        for (var r = 0; r <= word1.Length; r++)
            dp[r, 0] = r;
        for (var c = 1; c <= word2.Length; c++)
            dp[0, c] = c;

        for (var r = 1; r <= word1.Length; r++)
            for (var c = 1; c <= word2.Length; c++)
                if (word1[r - 1] == word2[c - 1])
                    dp[r, c] = dp[r - 1, c - 1];
                else
                    dp[r, c] = Math.Min(dp[r - 1, c - 1], Math.Min(dp[r - 1, c], dp[r, c - 1])) + 1;

        return dp[word1.Length, word2.Length];
    }
}