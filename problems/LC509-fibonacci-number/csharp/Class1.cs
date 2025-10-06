namespace _509._Fibonacci_Number;

public class OldSolution
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

//second attempt 4 min [O(n), O(1)]
public class Solution
{
    public int Fib(int n)
    {
        if (n == 0)
            return 0;
        if (n == 1)
            return 1;
        var prepre = 0;
        var pre = 1;
        var cur = 0;
        for (var i = 2; i <= n; i++)
        {
            cur = pre + prepre;
            prepre = pre;
            pre = cur;
        }

        return cur;
    }
}