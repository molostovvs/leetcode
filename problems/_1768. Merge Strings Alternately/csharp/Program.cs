using System.Text;

public class Solution
{
    public string MergeAlternately(string word1, string word2)
    {
        var sb = new StringBuilder();
        var p1 = 0;
        var p2 = 0;
        while (p1 < word1.Length && p2 < word2.Length)
        {
            sb.Append(word1[p1]);
            sb.Append(word2[p2]);
            p1++;
            p2++;
        }

        if (p1 < word1.Length)
            for (; p1 < word1.Length; p1++)
                sb.Append(word1[p1]);
        if (p2 < word2.Length)
            for (; p2 < word2.Length; p2++)
                sb.Append(word2[p2]);

        return sb.ToString();
    }
}