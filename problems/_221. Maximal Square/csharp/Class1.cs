//first attempt 30 min [O(m*n), O(m*n)] - fucking input chars
public class Solution
{
    public int MaximalSquare(char[][] matrix)
    {
        var answer = 0;

        var grid = new int[matrix.GetLength(0)][];
        for (var r = 0; r < matrix.Length; r++)
        {
            grid[r] = new int[matrix[r].GetLength(0)];
            for (var i = 0; i < grid[r].GetLength(0); i++)
                grid[r][i] = int.Parse(matrix[r][i].ToString());
        }

        for (var r = 0; r < grid.GetLength(0); r++)
            for (var c = 0; c < grid[0].GetLength(0); c++)
                if (grid[r][c] != 0)
                {
                    var diag = r - 1 >= 0 && c - 1 >= 0 ? grid[r - 1][c - 1] : 0;
                    var validTop = CheckTop(grid, (r, c), diag);
                    var validLeft = CheckLeft(grid, (r, c), diag);

                    var validSquare = Math.Min(validTop + 1, validLeft + 1);
                    if (diag + 1 == validSquare)
                        grid[r][c] = validSquare;
                    else
                        grid[r][c] = validSquare;

                    if (grid[r][c] > answer)
                        answer = grid[r][c];
                }

        return answer * answer;
    }

    private int CheckLeft(int[][] grid, (int R, int C) start, int diag)
    {
        var ans = 0;
        for (var c = start.C - 1; c >= start.C - diag; c--)
            if (grid[start.R][c] == 0)
                return ans;
            else
                ans++;
        return ans;
    }

    private int CheckTop(int[][] grid, (int R, int C) start, int diag)
    {
        var ans = 0;
        for (var r = start.R - 1; r >= start.R - diag; r--)
            if (grid[r][start.C] == 0)
                return ans;
            else
                ans++;

        return ans;
    }
}