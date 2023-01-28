public class Solution
{
    public int[] PlusOne(int[] digits)
    {
        var s = new Stack<int>();
        var overhead = 0;

        for (var i = digits.Length - 1; i >= 0; i--)
        {
            var n = digits[i];
            if (i == digits.Length - 1)
            {
                if (n + 1 == 10)
                {
                    overhead = 1;
                    s.Push(0);
                }
                else
                {
                    digits[digits.Length - 1] += 1;
                    return digits;
                }
            }
            else
            {
                if (n + overhead == 10)
                {
                    overhead = 1;
                    s.Push(0);
                }
                else
                {
                    s.Push(n + overhead);
                    overhead = 0;
                }
            }
        }

        if (overhead > 0)
            s.Push(overhead);
        return s.ToArray();
    }
}