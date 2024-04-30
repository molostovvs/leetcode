public class FirstSolution
{
    public bool CanConstruct(string ransomNote, string magazine)
    {
        var dict = new Dictionary<char, int>();

        foreach (var c in magazine)
            if (!dict.TryAdd(c, 1))
                dict[c]++;

        foreach (var c in ransomNote)
            if (dict.ContainsKey(c) && dict[c] > 0)
                dict[c]--;
            else
                return false;
        return true;
    }
}

//second attempt optimized for memory [O(n), O(1)]
public class Solution
{
    public bool CanConstruct(string ransomNote, string magazine)
    {
        var d = new int['z' - 'a' + 1];

        for (var i = 0; i < magazine.Length; i++)
        {
            var ch = magazine[i];
            d[ch - 'a']++;
        }

        for (var i = 0; i < ransomNote.Length; i++)
        {
            var ch = ransomNote[i];

            if (d[ch - 'a'] > 0)
                d[ch - 'a']--;
            else
                return false;
        }

        return true;
    }
}

// 5 min [O(n), O(1)] - memory O(1) since using const length array
public class ThirdSolution
{
    public bool CanConstruct(string ransomNote, string magazine)
    {
        var arr = new int['z' - 'a' + 1];

        foreach (var ch in magazine)
            arr[ch - 'a']++;

        foreach (var ch in ransomNote)
        {
            arr[ch - 'a']--;

            if (arr[ch - 'a'] < 0)
                return false;
        }

        return true;
    }
}
