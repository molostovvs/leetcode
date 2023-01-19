namespace _383._Ransom_Note;

public class Solution
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