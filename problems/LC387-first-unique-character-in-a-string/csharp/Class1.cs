namespace _387._First_Unique_Character_in_a_String;

public class Solution
{
    public int FirstUniqChar(string s)
    {
        var dict = new Dictionary<char, int>(); //char - number of occurences in string
        foreach (var c in s)
            if (!dict.TryAdd(c, 1))
                dict[c]++;

        for (var i = 0; i < s.Length; i++)
            if (dict[s[i]] == 1)
                return i;

        return -1;
    }
}