//first attempt 30 min (spied) [O(nlogn), O(1)]
public class Solution
{
    public int ShipWithinDays(int[] weights, int days)
    {
        var low = weights.Max();
        var high = weights.Sum();

        while (low < high)
        {
            var mid = (low + high) / 2;
            var curCap = 0;
            var shipNum = 1;

            foreach (var w in weights)
            {
                curCap += w;
                if (curCap > mid)
                {
                    curCap = w;
                    shipNum++;
                }
            }

            if (shipNum > days)
                low = mid + 1;
            else
                high = mid;
        }

        return low;
    }
}