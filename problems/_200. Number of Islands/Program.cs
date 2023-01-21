// [O(n*m), O(n*m)]

public class Solution
{
    public int NumIslands(char[][] grid)
    {
        var res = 0;
        var seen = new HashSet<(int x, int y)>();

        for (var r = 0; r < grid.GetLength(0); r++)
        {
            for (var c = 0; c < grid[0].GetLength(0); c++)
                if (grid[r][c] == '1' && !seen.Contains((r, c)))
                {
                    DiscoverIsland((r, c), grid, seen);
                    res++;
                }
        }

        return res;
    }

    private void DiscoverIsland((int x, int y) start, char[][] grid, HashSet<(int x, int y)> seen)
    {
        var q = new Queue<(int x, int y)>();
        q.Enqueue(start);

        while (q.Count > 0)
        {
            var cur = q.Dequeue();
            if (seen.Contains(cur))
                continue;
            seen.Add(cur);

            foreach (var neighbor in GetNeighbors(cur, grid, seen))
                q.Enqueue(neighbor);
        }
    }

    private static IEnumerable<(int, int)> GetNeighbors((int x, int y) cur, char[][] grid, HashSet<(int x, int y)> seen)
    {
        if (cur.x > 0 && grid[cur.x - 1][cur.y] == '1' && !seen.Contains((cur.x - 1, cur.y)))
            yield return (cur.x - 1, cur.y);
        if (cur.x < grid.GetLength(0) - 1 && grid[cur.x + 1][cur.y] == '1' && !seen.Contains((cur.x + 1, cur.y)))
            yield return (cur.x + 1, cur.y);
        if (cur.y > 0 && grid[cur.x][cur.y - 1] == '1' && !seen.Contains((cur.x, cur.y - 1)))
            yield return (cur.x, cur.y - 1);
        if (cur.y < grid[0].GetLength(0) - 1 && grid[cur.x][cur.y + 1] == '1' && !seen.Contains((cur.x, cur.y + 1)))
            yield return (cur.x, cur.y + 1);
    }
}