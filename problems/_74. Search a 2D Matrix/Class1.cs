using FluentAssertions;
using NUnit.Framework;

namespace _74._Search_a_2D_Matrix;

public class Program
{
    public static void Main() {}
}

public class Solution
{
    public bool SearchMatrix(int[][] matrix, int target)
    {
        //Binary among arrays [O(log (m * n)), O(1)]
        var n = matrix[0].GetLength(0);

        var left = 0;
        var right = matrix.GetLength(0) - 1;

        while (left <= right)
        {
            var mid = (left + right) / 2;
            if (matrix[mid][0] > target)
                right = mid - 1;
            else if (matrix[mid][n - 1] < target)
                left = mid + 1;
            else if (matrix[mid][0] <= target && target <= matrix[mid][n - 1])
                return matrix[mid].Contains(target); //again simple binary search in array
            else
                return false;
        }

        return false;
    }
}

[TestFixture]
public class Tests
{
    private static Solution s = new();

    [Test]
    public static void Matrix1x1Absent()
    {
        var matrix = new int[1][];
        matrix[0] = new[] { 1 };

        var result = s.SearchMatrix(matrix, 0);
        result.Should().BeFalse();
    }

    [Test]
    public static void Matrix1x1Absent2()
    {
        var matrix = new int[1][];
        matrix[0] = new[] { 1 };

        var result = s.SearchMatrix(matrix, 2);
        result.Should().BeFalse();
    }

    [Test]
    public static void Matrix1x2Absent()
    {
        var matrix = new int[2][];
        matrix[0] = new[] { 1 };
        matrix[1] = new[] { 3 };

        var result = s.SearchMatrix(matrix, 0);
        result.Should().BeFalse();
    }

    [Test]
    public static void Matrix1x1Present()
    {
        var matrix = new int[1][];
        matrix[0] = new[] { 1 };

        var result = s.SearchMatrix(matrix, 1);
        result.Should().BeTrue();
    }

    [Test]
    public static void ThreeRowsPresentInFirs()
    {
        var matrix = new int[3][];
        matrix[0] = new[] { 1, 3, 5, 7 };
        matrix[1] = new[] { 10, 11, 16, 20 };
        matrix[2] = new[] { 23, 30, 34, 60 };

        var result = s.SearchMatrix(matrix, 3);
        result.Should().BeTrue();
    }

    [Test]
    public static void ThreeRowsPresentInThird()
    {
        var matrix = new int[3][];
        matrix[0] = new[] { 1, 3, 5, 7 };
        matrix[1] = new[] { 10, 11, 16, 20 };
        matrix[2] = new[] { 23, 30, 34, 60 };

        var result = s.SearchMatrix(matrix, 34);
        result.Should().BeTrue();
    }

    [Test]
    public static void ThreeRowsPresentInSecond()
    {
        var matrix = new int[3][];
        matrix[0] = new[] { 1, 3, 5, 7 };
        matrix[1] = new[] { 10, 11, 16, 20 };
        matrix[2] = new[] { 23, 30, 34, 60 };

        var result = s.SearchMatrix(matrix, 16);
        result.Should().BeTrue();
    }

    [Test]
    public static void ThreeRowsAbsentInFirst()
    {
        var matrix = new int[3][];
        matrix[0] = new[] { 1, 3, 5, 7 };
        matrix[1] = new[] { 10, 11, 16, 20 };
        matrix[2] = new[] { 23, 30, 34, 60 };

        var result = s.SearchMatrix(matrix, 6);
        result.Should().BeFalse();
    }

    [Test]
    public static void ThreeRowsAbsentInSecond()
    {
        var matrix = new int[3][];
        matrix[0] = new[] { 1, 3, 5, 7 };
        matrix[1] = new[] { 10, 11, 16, 20 };
        matrix[2] = new[] { 23, 30, 34, 60 };

        var result = s.SearchMatrix(matrix, 14);
        result.Should().BeFalse();
    }

    [Test]
    public static void ThreeRowsAbsentInThird()
    {
        var matrix = new int[3][];
        matrix[0] = new[] { 1, 3, 5, 7 };
        matrix[1] = new[] { 10, 11, 16, 20 };
        matrix[2] = new[] { 23, 30, 34, 60 };

        var result = s.SearchMatrix(matrix, 50);
        result.Should().BeFalse();
    }

    [Test]
    public static void FourRowsPresentInLast()
    {
        var matrix = new int[4][];
        matrix[0] = new[] { 1, 3, 5, 7 };
        matrix[1] = new[] { 10, 11, 16, 20 };
        matrix[2] = new[] { 23, 30, 34, 60 };
        matrix[3] = new[] { 70, 81, 92, 97 };

        var result = s.SearchMatrix(matrix, 92);
        result.Should().BeTrue();
    }
}