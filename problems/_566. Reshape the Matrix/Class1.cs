using FluentAssertions;
using NUnit.Framework;

namespace _566._Reshape_the_Matrix;

public class Program
{
    public static void Main() {}
}

public class Solution
{
    public int[][] MatrixReshape(int[][] mat, int r, int c)
    {
        // using LINQ and two loops [O(n, m), O(1)]
        if (mat.GetLength(0) * mat[0].GetLength(0) != r * c)
            return mat;

        var result = new int[r][];
        var items = mat.SelectMany(arr => arr);
        var enumerator = items.GetEnumerator();
        enumerator.MoveNext();

        for (var i = 0; i < result.GetLength(0); i++)
        {
            result[i] = new int[c];
            for (var j = 0; j < c; j++)
            {
                result[i][j] = enumerator.Current;
                enumerator.MoveNext();
            }
        }

        return result;
    }
}

[TestFixture]
public class Tests
{
    private static Solution s = new();

    [Test]
    public static void SquareToLinear()
    {
        var inp = new[] { new[] { 1, 2 }, new[] { 3, 4 } };
        var result = s.MatrixReshape(inp, 1, 4);
        var expected = new[] { new[] { 1, 2, 3, 4 } };
        CollectionAssert.AreEqual(expected, result);
    }

    [Test]
    public static void SquareToNone()
    {
        var inp = new[] { new[] { 1, 2 }, new[] { 3, 4 } };
        var result = s.MatrixReshape(inp, 2, 4);
        var expected = inp;
        CollectionAssert.AreEqual(expected, result);
    }
}