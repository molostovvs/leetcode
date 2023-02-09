//first attempt 5 min [O(n), O(1)]
public class Solution
{
    public int Rob(int[] nums)
    {
        var prepre = 0;
        var pre = 0;

        foreach (var num in nums)
        {
            var cur = Math.Max(prepre + num, pre);
            prepre = pre;
            pre = cur;
        }

        return pre;
    }
}