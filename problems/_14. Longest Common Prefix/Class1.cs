using System.Text;

//first attempt 5 min [O(n), O(1)]
public class Solution
{
    public string LongestCommonPrefix(string[] strs)
    {
        string prefix = null;

        foreach (var str in strs)
            if (prefix is null)
                prefix = str;
            else
                prefix = GetCommonPrefix(prefix, str);

        return prefix;
    }

    private string GetCommonPrefix(string prefix, string str)
    {
        var sb = new StringBuilder();
        var length = Math.Min(prefix.Length, str.Length);

        for (var i = 0; i < length; i++)
            if (prefix[i] == str[i])
                sb.Append(str[i]);
            else
                return sb.ToString();

        return sb.ToString();
    }
}