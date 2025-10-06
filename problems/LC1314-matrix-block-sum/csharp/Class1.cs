using FluentAssertions;
using NUnit.Framework;

public class Program
{
    public static void Main() {}
}

//naive solution 20 min [O(n^2 OR n^4), O(1)]
public class Solution
{
    public int[][] MatrixBlockSum(int[][] mat, int k)
    {
        var answer = new int[mat.GetLength(0)][];
        for (var r = 0; r < answer.Length; r++)
            answer[r] = new int[mat[0].GetLength(0)];

        for (var r = 0; r < answer.GetLength(0); r++)
        {
            for (var c = 0; c < answer[0].GetLength(0); c++)
                answer[r][c] = GetRes(mat, k, (r, c));
        }

        return answer;
    }

    private int GetRes(int[][] mat, int k, (int R, int C) cell)
    {
        var startRow = cell.R - k >= 0 ? cell.R - k : 0;
        var startCol = cell.C - k >= 0 ? cell.C - k : 0;
        var endRow = cell.R + k < mat.GetLength(0) ? cell.R + k : mat.GetLength(0) - 1;
        var endCol = cell.C + k < mat[0].GetLength(0) ? cell.C + k : mat[0].GetLength(0) - 1;

        var res = 0;
        for (var r = startRow; r <= endRow; r++)
        {
            for (var c = startCol; c <= endCol; c++)
                res += mat[r][c];
        }

        return res;
    }
}

[TestFixture]
public class Tests
{
    private static Solution s = new();

    [Test]
    public static void Example()
    {
        var mat = new[]
        {
            new[] { 1, 2, 3 },
            new[] { 4, 5, 6 },
            new[] { 7, 8, 9 },
        };
        var result = s.MatrixBlockSum(mat, 1);
        var expected = new[]
        {
            new[] { 12, 21, 16 },
            new[] { 27, 45, 33 },
            new[] { 24, 39, 28 },
        };
        result.Should().BeEquivalentTo(expected, opt => opt.WithStrictOrdering());
    }
}