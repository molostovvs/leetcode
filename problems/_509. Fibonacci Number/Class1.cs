namespace _509._Fibonacci_Number;

public class Solution
{
    public int Fib(int n)
    {
        if (n == 0)
            return 0;
        if (n == 1)
            return 1;

        var res = -1;
        var preprev = 0;
        var prev = 1;

        for (var i = 2; i <= n; i++)
        {
            res = preprev + prev;
            preprev = prev;
            prev = res;
        }

        return res;
    }
}