using FluentAssertions;
using NUnit.Framework;

namespace _733._Flood_Fill;

public class Program
{
    public static void Main() {}
}

public class OldSolution
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

//second attempt [O(n), O(n)]
public class Solution
{
    public int[][] FloodFill(int[][] image, int sr, int sc, int color)
    {
        if (image[sr][sc] == color)
            return image;

        var q = new Queue<(int R, int C)>();
        var visited = new HashSet<(int R, int C)>();
        q.Enqueue((sr, sc));

        while (q.Count > 0)
        {
            var cur = q.Dequeue();
            if (visited.Contains(cur))
                continue;
            visited.Add(cur);

            foreach (var neighbor in GetNeighbors(cur, image, color))
                if (!visited.Contains(neighbor))
                    q.Enqueue(neighbor);
            image[cur.R][cur.C] = color;
        }

        return image;
    }

    private IEnumerable<(int R, int C)> GetNeighbors((int R, int C) cur, int[][] image, int color)
    {
        var d = new[] { -1, 0, 1 };
        return d.SelectMany(r => d.Select(c => (cur.R - r, cur.C - c)))
                .Where(t => cur.R == t.Item1 || cur.C == t.Item2)
                .Where(t => t.Item1 >= 0 && t.Item1 < image.GetLength(0))
                .Where(t => t.Item2 >= 0 && t.Item2 < image[0].GetLength(0))
                .Where(t => image[t.Item1][t.Item2] == image[cur.R][cur.C]);
    }
}

//NEXT ATTEMPT SHOULD BE RECURSIVE

[TestFixture]
public class Tests
{
    private static Solution s = new();

    [Test]
    public static void Example()
    {
        var image = new int[3][];
        image[0] = new[] { 1, 1, 1 };
        image[1] = new[] { 1, 1, 0 };
        image[2] = new[] { 1, 0, 1 };
        var result = s.FloodFill(image, 1, 1, 2);
        var expected = new int[3][];
        expected[0] = new[] { 2, 2, 2 };
        expected[1] = new[] { 2, 2, 0 };
        expected[2] = new[] { 2, 0, 1 };
        result.Should().BeEquivalentTo(expected, opt => opt.WithStrictOrdering());
    }
}