//my solution [O(log n), O(1)]
public class MySolution
{
    public int ArrangeCoins(int n)
    {
        var steps = 1;
        while (n > 0)
        {
            n -= steps;
            steps++;
        }

        return n < 0 ? steps - 2 : steps - 1;
    }
}

//binary search [O(log n), O(1)]
public class Solution
{
    public int ArrangeCoins(int n)
    {
        long left = 1, right = n;

        while (left <= right)
        {
            long mid = left + (right - left) / 2;
            long curr = mid * (mid + 1) / 2;

            if (curr == n)
                return (int)mid;

            if (n < curr)
                right = mid - 1;
            else
                left = mid + 1;
        }

        return (int)right;
    }
}