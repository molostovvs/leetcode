using System.Collections;
using System.Text;

//first attempt after googling
public class Solution
{
    public string GcdOfStrings(string str1, string str2)
    {
        var minLength = Math.Min(str1.Length, str2.Length);
        var minStr = str1.Length == minLength ? str1 : str2;
        var sb = new StringBuilder();
        var res = string.Empty;

        for (var i = 0; i < minLength; i++)
        {
            sb.Append(minStr[i]);
            if (str1.Length % sb.Length == 0 && str2.Length % sb.Length == 0)
                if (IsPrefixValidForString(str1, sb) && IsPrefixValidForString(str2, sb))
                    res = sb.ToString();
        }

        return res;
    }

    private static bool IsPrefixValidForString(string str1, StringBuilder sb)
    {
        var prefixStr = new StringBuilder();
        var c1 = str1.Length / sb.Length;
        while (c1 > 0)
        {
            prefixStr.Append(sb);
            c1--;
        }

        return prefixStr.ToString() == str1;
    }
}

public class MathSolution
{
    public string GcdOfStrings(string str1, string str2)
    {
        if (str1 + str2 != str2 + str1)
            return string.Empty;
        int gcdVal = gcd(str1.Length, str2.Length);
        return str2.Substring(0, gcdVal);
    }

    private int gcd(int p, int q)
    {
        if (q == 0)
            return p;
        return gcd(q, p % q);
    }
}