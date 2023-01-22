using System.Text;

/*// Library Solution [O(n), O(n)]
public class Solution
{
    public string ToLowerCase(string s)
    {
        return s.ToLowerInvariant();
    }
}*/

//Custom solution [O(n), O(n)]
public class Solution
{
    public string ToLowerCase(string s)
    {
        var sb = new StringBuilder();
        foreach (var c in s)
            if (c >= 'A' && c <= 'Z')
                sb.Append((char)('a' - 'A' + c));
            else
                sb.Append(c);

        return sb.ToString();
    }
}