namespace _409._Longest_Palindrome;

public class Solution
{
    public int LongestPalindrome(string s)
    {
        var dict = new Dictionary<char, int>(); //can be replaced with set [time O(n), space O(1)]
        foreach (var c in s)
            if (dict.ContainsKey(c))
                dict[c]++;
            else
                dict.Add(c, 1);

        var result = 0;

        foreach (var kv in dict)
            if (kv.Value % 2 == 0)
                result += kv.Value;
            else if (result % 2 == 0)
                result += kv.Value;
            else
                result += kv.Value - 1;

        return result;
    }
}