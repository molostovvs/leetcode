//first attempt 25 min [O(1), O(1)] - according to description of a problem
public class NumMatrix
{
    private int[][] sum;

    public NumMatrix(int[][] matrix)
    {
        sum = matrix;
        for (var c = 1; c < sum[0].GetLength(0); c++)
            sum[0][c] += sum[0][c - 1];
        for (var r = 1; r < sum.GetLength(0); r++)
            sum[r][0] += sum[r - 1][0];

        for (var r = 1; r < sum.GetLength(0); r++)
            for (var c = 1; c < sum[0].GetLength(0); c++)
                sum[r][c] = sum[r][c - 1] + sum[r - 1][c] - sum[r - 1][c - 1] + sum[r][c];
    }

    public int SumRegion(int row1, int col1, int row2, int col2)
    {
        return sum[row2][col2]
            - (col1 - 1 < 0 ? 0 : sum[row2][col1 - 1])
            - (row1 - 1 < 0 ? 0 : sum[row1 - 1][col2])
            + (row1 - 1 < 0 || col1 - 1 < 0 ? 0 : sum[row1 - 1][col1 - 1]);
    }
}