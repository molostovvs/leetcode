using System.Text;

//first attempt [O(n), O(n)]
public class OldSolution
{
    public string ReverseWords(string s)
    {
        var sb = new StringBuilder();
        var prevWhiteSpace = 0;
        for (var i = 0; i < s.Length; i++)
            if (char.IsWhiteSpace(s[i]) && i != s.Length - 1)
            {
                sb.Append(ReverseWord(s, i - 1, prevWhiteSpace));
                sb.Append(" ");
                prevWhiteSpace = i;
            }
            else if (i == s.Length - 1)
            {
                sb.Append(ReverseWord(s, i, prevWhiteSpace));
            }

        return sb.ToString();
    }

    private string ReverseWord(string s, int right, int left)
    {
        var sb = new StringBuilder();
        while (right >= left)
        {
            if (char.IsWhiteSpace(s[right]))
                break;
            sb.Append(s[right]);
            right--;
        }

        return sb.ToString();
    }
}

//second attempt (more clean) [O(n), O(n)]
public class Solution
{
    public string ReverseWords(string s)
    {
        var arr = s.ToCharArray();
        var wordStart = 0;
        for (var i = 0; i < arr.Length; i++)
            if (char.IsWhiteSpace(s[i]) || i == arr.Length - 1)
            {
                ReverseWord(arr, wordStart, i == arr.Length - 1 ? i : i - 1);
                wordStart = i + 1;
            }

        return new string(arr);
    }

    private void ReverseWord(char[] arr, int left, int right)
    {
        while (left < right)
        {
            (arr[left], arr[right]) = (arr[right], arr[left]);
            left++;
            right--;
        }
    }
}