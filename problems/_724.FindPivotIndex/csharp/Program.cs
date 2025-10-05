using System.Text;
using NUnit.Framework;

public class Program
{
    static void Main(string[] args) {}
}

public class Solution
{
    public int PivotIndex(int[] nums)
    {
        int sum = nums.Sum();
        var leftSum = 0;
        for (var i = 0; i < nums.Length; i++)
        {
            var right = sum - leftSum - nums[i];
            if (right == leftSum)
                return i;
            leftSum += nums[i];
        }

        return -1;
    }
}

[TestFixture]
public class Tests
{
    [SetUp]
    public static void SetUp()
        => s = new Solution();

    private static Solution s;

    [TestCase(new[] { 1, 7, 3, 6, 5, 6 }, 3)]
    [TestCase(new[] { 1, 2, 3 }, -1)]
    [TestCase(new[] { 2, 1, -1 }, 0)]
    [TestCase(new[] { 0, 0, 0, 0, 1, 2, 5, 3 }, 6)]
    [TestCase(new[] { -1, -1, -1, -1, -1, 0 }, 2)]
    [TestCase(new[] { -1, -1, -1, -1, -1, 1 }, -1)]
    public static void TestExample1(int[] arr, int expected)
    {
        var res = s.PivotIndex(arr);
        Assert.AreEqual(expected, res, arr.PrintItems());
    }
}

public static class ArrayExtensions
{
    public static string PrintItems(this int[] arr)
    {
        var sb = new StringBuilder();
        foreach (var v in arr)
            sb.Append(v + " ");

        return sb.ToString();
    }
}