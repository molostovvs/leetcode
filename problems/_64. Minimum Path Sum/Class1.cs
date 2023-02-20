public class Solution
{
    public int MinPathSum(int[][] grid)
    {
        for (var r = 0; r < grid.GetLength(0); r++)
            for (var c = 0; c < grid[0].GetLength(0); c++)
                if (r == 0 && c == 0)
                    continue;
                else
                    grid[r][c] += Math.Min(r - 1 >= 0 ? grid[r - 1][c] : int.MaxValue, c - 1 >= 0 ? grid[r][c - 1] : int.MaxValue);

        return grid[^1][^1];
    }
}