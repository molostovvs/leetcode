namespace _1822._Sign_of_the_Product_of_an_Array;

public class Solution
{
    public int ArraySign(int[] nums)
    {
        var negatives = 0; // [time O(n), space O(1)]
        foreach (var n in nums)
            if (n < 0)
                negatives++;
            else if (n == 0)
                return 0;

        return negatives % 2 == 0 ? 1 : -1;
    }
}