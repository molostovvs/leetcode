using FluentAssertions;
using NUnit.Framework;

public class Program
{
    public static void Main() {}
}

public class NaiveSolution
{
    public int FindTheDistanceValue(int[] arr1, int[] arr2, int d)
    {
        Array.Sort(arr1);
        Array.Sort(arr2);

        var res = 0;

        for (var i = 0; i < arr1.Length; i++)
        {
            var t = arr1[i];
            for (var j = arr2.Length - 1; j >= 0; j--)
                if (Math.Abs(arr2[j] - t) <= d)
                {
                    res += 1;
                    break;
                }
        }

        return arr1.Length - res;
    }
}

public class Solution
{
    public int FindTheDistanceValue(int[] arr1, int[] arr2, int d)
    {
        Array.Sort(arr1);
        Array.Sort(arr2);

        var ans = 0;
        var i = 0;
        var j = 0;

        while (i < arr1.Length && j < arr2.Length)
        {
            if (arr1[i] <= arr2[j] + d)
            {
                if (arr1[i] < arr2[j] - d)
                    ans++;
                i++;
            }
            else
            {
                j++;
            }
        }

        return ans + arr1.Length - i;
    }
}

[TestFixture]
public class Tests
{
    private static Solution s = new Solution();

    [TestCase(new[] { 4, 5, 8 }, new[] { 10, 9, 1, 8 }, 2, 2)]
    public static void Example(int[] arr1, int[] arr2, int d, int expected)
    {
        var result = s.FindTheDistanceValue(arr1, arr2, d);
        result.Should().Be(expected);
    }
}