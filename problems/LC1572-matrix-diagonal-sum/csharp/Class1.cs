namespace _1572._Matrix_Diagonal_Sum;

//my solution [O(n), O(1)]
public class Solution
{
    public int DiagonalSum(int[][] mat)
    {
        var sum = 0;
        var n = mat.GetLength(0);

        for (var i = 0; i < n; i++)
            sum += mat[i][i];

        for (var j = n; j > 0; j--)
            sum += mat[n - j][j - 1];

        sum -= n % 2 != 0 ? mat[n / 2][n / 2] : 0;

        return sum;
    }
}