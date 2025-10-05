namespace _217._Contains_Duplicate;

public class Solution
{
    public bool ContainsDuplicate(int[] nums)
    {
        var set = new HashSet<int>();
        foreach (var n in nums)
            if (!set.Add(n))
                return true;

        return false;
    }
}