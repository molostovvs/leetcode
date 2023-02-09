public class Solution
{
    public uint reverseBits(uint n)
    {
        var res = 0u;

        for (var i = 0; i < 32; i++)
        {
            res <<= 1;
            if ((n & 1) == 1)
                res++;
            n >>= 1;
        }

        return res;
    }
}