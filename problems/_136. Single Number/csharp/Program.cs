//naive solution [O(n), O(n)]
public class NaiveSolution
{
    public int SingleNumber(int[] nums)
    {
        var d = new Dictionary<int, byte>();

        foreach (var i in nums)
            if (!d.TryAdd(i, 1))
                d[i]++;

        return d.First(kv => kv.Value == 1).Key;
    }
}

//fuck this problem in O(n) time
public class Solution
{
    public int SingleNumber(int[] nums)
    {
        var x = 0;
        foreach (var n in nums)
            x ^= n;

        return x;
    }
}