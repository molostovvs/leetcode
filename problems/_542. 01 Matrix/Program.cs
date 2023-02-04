//first attempt (with hints) 50 min [O(n*m), O(1)]
public class Solution
{
    public int[][] UpdateMatrix(int[][] mat)
    {
        for (var r = 0; r < mat.GetLength(0); r++)
            for (var c = 0; c < mat[0].GetLength(0); c++)
                if (mat[r][c] > 0)
                {
                    var top = 10001;
                    var left = 10001;
                    if (r >= 1)
                        top = mat[r - 1][c];
                    if (c >= 1)
                        left = mat[r][c - 1];
                    mat[r][c] = Math.Min(top, left) + 1;
                }

        for (var r = mat.GetLength(0) - 1; r >= 0; r--)
            for (var c = mat[0].GetLength(0) - 1; c >= 0; c--)
                if (mat[r][c] > 0)
                {
                    var bot = 10001;
                    var right = 10001;
                    if (r < mat.GetLength(0) - 1)
                        bot = mat[r + 1][c];
                    if (c < mat[0].GetLength(0) - 1)
                        right = mat[r][c + 1];
                    mat[r][c] = Math.Min(mat[r][c], Math.Min(bot, right) + 1);
                }

        return mat;
    }
}