//first attempt 8 min [O(m*n), O(1)]
public class Solution
{
    public int MinFallingPathSum(int[][] matrix)
    {
        for (var r = 1; r < matrix.GetLength(0); r++)
            for (var c = 0; c < matrix[0].GetLength(0); c++)
                if (c == 0)
                    matrix[r][c] += Math.Min(matrix[r - 1][c], c + 1 < matrix[0].GetLength(0) ? matrix[r - 1][c + 1] : int.MaxValue);
                else if (c == matrix[0].GetLength(0) - 1)
                    matrix[r][c] += Math.Min(matrix[r - 1][c], c - 1 >= 0 ? matrix[r - 1][c - 1] : int.MaxValue);
                else
                    matrix[r][c] += Math.Min(matrix[r - 1][c - 1], Math.Min(matrix[r - 1][c], matrix[r - 1][c + 1]));

        return matrix[^1].Min();
    }
}