//first attempt 13 min [O(n), O(alphabet)]
public class Solution
{
    public int RomanToInt(string s)
    {
        var res = 0;

        var d = new Dictionary<char, int>
        {
            { 'I', 1 },
            { 'V', 5 },
            { 'X', 10 },
            { 'L', 50 },
            { 'C', 100 },
            { 'D', 500 },
            { 'M', 1000 },
        };

        for (var i = s.Length - 1; i >= 0; i--)
        {
            var number = s[i];

            if (number == 'I')
                res += d[number];
            else if (number == 'V' || number == 'X')
                if (i > 0 && s[i - 1] == 'I')
                {
                    res += d[number] - d['I'];
                    i--;
                }
                else
                {
                    res += d[number];
                }
            else if (number == 'L' || number == 'C')
                if (i > 0 && s[i - 1] == 'X')
                {
                    res += d[number] - d['X'];
                    i--;
                }
                else
                {
                    res += d[number];
                }
            else if (number == 'D' || number == 'M')
                if (i > 0 && s[i - 1] == 'C')
                {
                    res += d[number] - d['C'];
                    i--;
                }
                else
                {
                    res += d[number];
                }
        }

        return res;
    }
}