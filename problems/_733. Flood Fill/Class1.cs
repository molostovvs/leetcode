namespace _733._Flood_Fill;

public class Solution
{
    public int[][] FloodFill(int[][] image, int sr, int sc, int color)
    {
        var q = new Queue<(int, int)>();
        q.Enqueue((sr, sc));

        var seen = new HashSet<(int, int)>();
        while (q.Count > 0)
        {
            (int x, int y) cur = q.Dequeue();
            if (seen.Contains(cur) || IsCurrentPixelAlreadyDesiredColor(image, color, cur))
                continue;
            seen.Add(cur);

            foreach (var neighbor in GetNeighbors(cur, image))
                if (!seen.Contains(neighbor))
                    q.Enqueue(neighbor);

            image[cur.x][cur.y] = color;
        }

        return image;
    }

    private IEnumerable<(int, int)> GetNeighbors((int x, int y) cur, int[][] image)
    {
        (int x, int y) n1 = (cur.x - 1, cur.y);
        (int x, int y) n2 = (cur.x + 1, cur.y);
        (int x, int y) n3 = (cur.x, cur.y - 1);
        (int x, int y) n4 = (cur.x, cur.y + 1);

        if (cur.x > 0 && image[n1.x][n1.y] == image[cur.x][cur.y])
            yield return n1;
        if (cur.x < image.GetLength(0) - 1 && image[n2.x][n2.y] == image[cur.x][cur.y])
            yield return n2;
        if (cur.y > 0 && image[n3.x][n3.y] == image[cur.x][cur.y])
            yield return n3;
        if (cur.y < image[0].GetLength(0) - 1 && image[n4.x][n4.y] == image[cur.x][cur.y])
            yield return n4;
    }

    private static bool IsCurrentPixelAlreadyDesiredColor(int[][] image, int color, (int, int) cur)
        => image[cur.Item1][cur.Item2] == color;
}