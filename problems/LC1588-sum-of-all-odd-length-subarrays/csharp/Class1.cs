namespace _1588._Sum_of_All_Odd_Length_Subarrays;

public class Program
{
    public static void Main()
    {
        var s = new Solution();
        var x = s.SumOddLengthSubarrays(new[] { 1, 2 });
    }
}

public class Solution
{
    public int SumOddLengthSubarrays(int[] arr)
    {
        /*// One line solution [O(n), O(1)]]
        return arr.Select((x, i) => (x, i)).Sum(t => t.x * (((arr.Length - t.i) * (t.i + 1) + 1) / 2));*/

        var res = 0;
        for (var i = 0; i < arr.Length; i++)
        {
            var subArraysStarting = arr.Length - i;
            var subArraysEnding = i + 1;
            var multiplyer = (subArraysStarting * subArraysEnding + 1) / 2;
            res += arr[i] * multiplyer;
        }

        return res;
    }
}