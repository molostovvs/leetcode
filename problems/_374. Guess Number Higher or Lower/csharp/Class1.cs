/**
 * Forward declaration of guess API.
 * @param  num   your guess
 * @return 	     -1 if num is higher than the picked number
 * 1 if num is lower than the picked number
 * otherwise return 0
 * int guess(int num);
 */
public class GuessGame
{
    public int guess(int num)
        => 0;
}

public class Solution : GuessGame
{
    public int GuessNumber(int n)
    {
        var left = 0;
        var right = n;

        while (left <= right)
        {
            var mid = right - (right - left) / 2;
            var ans = guess(mid);

            if (ans == -1)
                right = mid - 1;
            else if (ans == 1)
                left = mid + 1;
            else
                return mid;
        }

        return int.MaxValue;
    }
}