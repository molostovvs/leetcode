//first attempt 13 min [O(m*n), O(1)]
public class Solution
{
    public int UniquePathsWithObstacles(int[][] grid)
    {
        for (var r = 0; r < grid.GetLength(0); r++)
        {
            for (var c = 0; c < grid[0].GetLength(0); c++)
                if (r == 0 && c == 0)
                    grid[r][c] = grid[r][c] == 0 ? 1 : 0;
                else if (grid[r][c] == 1)
                    grid[r][c] = 0;
                else
                    grid[r][c] = (c - 1 >= 0 ? grid[r][c - 1] : 0) + (r - 1 >= 0 ? grid[r - 1][c] : 0);
        }

        return grid[^1][^1];
    }
}