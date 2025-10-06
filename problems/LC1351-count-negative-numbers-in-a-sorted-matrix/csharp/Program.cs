//10 min [O(n*m), O(1)]
public class NaiveSolution
{
    public int CountNegatives(int[][] grid)
    {
        var counter = 0;
        for (var r = 0; r < grid.GetLength(0); r++)
            for (var c = 0; c < grid[0].GetLength(0); c++)
                if (grid[r][c] < 0)
                    counter++;

        return counter;
    }
}

//20 min [O(n+m), O(1)]
public class Solution
{
    public int CountNegatives(int[][] grid)
    {
        int m = grid.GetLength(0);
        int n = grid[0].GetLength(0);
        var row = m - 1;
        var col = 0;
        var res = 0;

        while (row >= 0 && col < n)
        {
            if (grid[row][col] < 0)
            {
                row--;
                res += n - col;
            }
            else
            {
                col++;
            }
        }

        return res;
    }
}