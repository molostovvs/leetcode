using FluentAssertions;
using NUnit.Framework;

public class Program
{
    public static void Main() {}
}

//first attempt (spied) 80 min [O(n), O(n)]
public class Solution
{
    public int[] ShortestAlternatingPaths(int n, int[][] redEdges, int[][] blueEdges)
    {
        var redDict = new Dictionary<int, List<int>>();
        var blueDict = new Dictionary<int, List<int>>();

        foreach (var redEdge in redEdges)
            if (redEdge.Length == 2 && !redDict.TryAdd(redEdge[0], new List<int>(new[] { redEdge[1] })))
                redDict[redEdge[0]].Add(redEdge[1]);

        foreach (var blueEdge in blueEdges)
            if (blueEdge.Length == 2 && !blueDict.TryAdd(blueEdge[0], new List<int>(new[] { blueEdge[1] })))
                blueDict[blueEdge[0]].Add(blueEdge[1]);

        var answer = Enumerable.Repeat(-1, n).ToArray();

        var q = new Queue<(int Node, int Length, string PrevColor)>();
        q.Enqueue((0, 0, null));

        var visited = new HashSet<(int Node, string Prevcolor)>();
        visited.Add((0, null));

        while (q.Count > 0)
        {
            var cur = q.Dequeue();
            if (answer[cur.Node] == -1)
                answer[cur.Node] = cur.Length;

            if (cur.PrevColor != "red" && redDict.ContainsKey(cur.Node))
                foreach (var neighbor in redDict[cur.Node])
                    if (!visited.Contains((neighbor, "red")))
                    {
                        visited.Add((neighbor, "red"));
                        q.Enqueue((neighbor, cur.Length + 1, "red"));
                    }

            if (cur.PrevColor != "blue" && blueDict.ContainsKey(cur.Node))
                foreach (var neighbor in blueDict[cur.Node])
                    if (!visited.Contains((neighbor, "blue")))
                    {
                        visited.Add((neighbor, "blue"));
                        q.Enqueue((neighbor, cur.Length + 1, "blue"));
                    }
        }

        return answer;
    }
}

[TestFixture]
public class Tests
{
    private static Solution s = new();

    [Test]
    public static void Example()
    {
        var n = 3;
        var red = new[] { new[] { 0, 1 }, new[] { 0, 2 } };
        var blue = new[] { new[] { 1, 0 } };

        var result = s.ShortestAlternatingPaths(n, red, blue);
        var expected = new[] { 0, 1, 1 };
        result.Should().BeEquivalentTo(expected, opt => opt.WithStrictOrdering());
    }

    [Test]
    public static void Example0()
    {
        var n = 3;
        var red = new[] { new[] { 0, 1 }, new[] { 1, 2 } };
        var blue = new[] { new int[0] };

        var result = s.ShortestAlternatingPaths(n, red, blue);
        var expected = new[] { 0, 1, -1 };
        result.Should().BeEquivalentTo(expected, opt => opt.WithStrictOrdering());
    }
}