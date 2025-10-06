using FluentAssertions;
using NUnit.Framework;

namespace _283._Move_Zeroes;

public class Program
{
    public static void Main() {}
}

/*
public class Solution
{
    public void MoveZeroes(int[] nums)
    {
        //first attempt 
        var zeroPointer = 0; //staying on zero
        var digitPointer = 0; //looking for digit

        while (zeroPointer < nums.Length && digitPointer < nums.Length)
        {
            if (nums[zeroPointer] == 0)
            {
                while (nums[digitPointer] == 0)
                {
                    digitPointer++;
                    if (digitPointer == nums.Length)
                        break;
                }

                if (digitPointer == nums.Length)
                    break;
                (nums[zeroPointer], nums[digitPointer]) = (nums[digitPointer], nums[zeroPointer]);
            }
            else
            {
                zeroPointer++;
                digitPointer++;
            }
        }

        /#1#/non intuitive
        for (int lastNonZeroFoundAt = 0, cur = 0; cur < nums.Length; cur++)
            if (nums[cur] != 0)
                (nums[cur], nums[lastNonZeroFoundAt]) = (nums[lastNonZeroFoundAt++], nums[cur]);#1#
    }
}*/

//second attempt minimum operations [O(n), O(1)]
public class Solution
{
    public void MoveZeroes(int[] nums)
    {
        var zeroesCount = 0;
        for (var i = 0; i < nums.Length; i++)
            if (nums[i] != 0 && zeroesCount > 0)
            {
                nums[i - zeroesCount] = nums[i];
                nums[i] = 0;
            }
            else if (nums[i] == 0)
            {
                zeroesCount++;
            }
    }
}

[TestFixture]
public class Tests
{
    private static Solution s = new();

    [TestCase(new[] { 0 }, new[] { 0 })]
    [TestCase(new[] { 0, 0 }, new[] { 0, 0 })]
    [TestCase(new[] { 1 }, new[] { 1 })]
    [TestCase(new[] { 1, 2, 3 }, new[] { 1, 2, 3 })]
    [TestCase(new[] { 0, 1, 0, 3, 12 }, new[] { 1, 3, 12, 0, 0 })]
    [TestCase(new[] { 0, 0, 1, 3, 12 }, new[] { 1, 3, 12, 0, 0 })]
    [TestCase(new[] { 1, 3, 12, 0, 0 }, new[] { 1, 3, 12, 0, 0 })]
    public static void Example(int[] nums, int[] expected)
    {
        s.MoveZeroes(nums);
        nums.Should().BeEquivalentTo(expected, opt => opt.WithStrictOrdering());
    }
}