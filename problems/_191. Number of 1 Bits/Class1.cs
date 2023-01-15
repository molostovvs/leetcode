using System.Numerics;
using FluentAssertions;
using NUnit.Framework;

namespace _191._Number_of_1_Bits;

public class Program
{
    static void Main(string[] args) {}
}

public class Solution
{
    public int HammingWeight(uint n)
    {
        /*return BitOperations.PopCount(n); - libary solution*/

        /*long count = 0; // naive solution
        while (n > 0)
        {
            count += n % 2;
            n /= 2;
        }

        return (int)count;*/

        /*long count = 0; // navie solution with bit operations - complexity O(n)
        while (n > 0) 
        {
            count += n & 1; //take last bit of n
            n >>= 1; //shift right for 1 bit
        }

        return (int)count;*/

        long count = 0; //smart solution with bit operations - complexity O(ans);
        while (n > 0)
        {
            n = n & (n - 1); //- remove last bit
            count++; //increment counter for every bit
            /*Example:
            1.
            010110 - n
            010101 - (n-1)
            010100 - n & (n-1)
            2.
            010100 - n
            010011 - (n-1)
            010000 - n & (n-1)
            3.
            010000 - n
            001111 - (n-1)
            000000 - n & (n-1)
            Answer - 3 bits*/
        }

        return (int)count;
    }
}

[TestFixture]
public class Tests
{
    public static Solution s = new();

    [TestCase(00000000000000000000000010000000, 1)]
    [TestCase(00000000000000000000000000001011, 3)]
    public static void Example(uint inp, int expected)
    {
        var result = s.HammingWeight(inp);
        result.Should().Be(expected);
    }
}