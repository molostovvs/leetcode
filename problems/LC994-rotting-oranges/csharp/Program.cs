//first attempt 55 min [O(m*n), O(m*n)] ugly code
public class Solution
{
    public int OrangesRotting(int[][] grid)
    {
        var res = 0;
        var q = new Queue<(int R, int C)>();

        for (var r = 0; r < grid.GetLength(0); r++)
            for (var c = 0; c < grid[0].GetLength(0); c++)
                if (grid[r][c] == 2)
                    q.Enqueue((r, c));

        var count = q.Count;
        if (count == 0)
        {
            if (grid.SelectMany(row => row).Any(cell => cell == 1))
                return -1;
            return 0;
        }

        while (count > 0)
        {
            var countForRound = count;
            count = 0;

            while (countForRound > 0)
            {
                var cur = q.Dequeue();

                grid[cur.R][cur.C] = 2;
                foreach (var neighbor in GetNeighbors(cur, grid))
                {
                    grid[neighbor.R][neighbor.C] = 2;
                    q.Enqueue(neighbor);
                    count++;
                }

                countForRound--;
            }

            res++;
        }

        if (grid.SelectMany(row => row).Any(cell => cell == 1))
            return -1;

        return res - 1;

        IEnumerable<(int R, int C)> GetNeighbors((int R, int C) start, int[][] grid)
        {
            var d = new[] { -1, 0, 1 };
            return d.SelectMany(r => d.Select(c => (R: start.R - r, C: start.C - c)))
                    .Where(t => t.R == start.R || t.C == start.C)
                    .Where(t => t != start)
                    .Where(t => t.R >= 0 && t.R < grid.GetLength(0) && t.C >= 0 && t.C < grid[0].GetLength(0))
                    .Where(t => grid[t.R][t.C] == 1);
        }
    }
}