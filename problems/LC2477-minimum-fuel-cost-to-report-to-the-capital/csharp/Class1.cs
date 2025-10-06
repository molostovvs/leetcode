using FluentAssertions;
using NUnit.Framework;

public class Program
{
    public static void Main() {}
}

public class Solution
{
    long cost;

    public long MinimumFuelCost(int[][] roads, int seats)
    {
        if (roads.GetLength(0) == 0)
            return 0;

        cost = 0;

        var graph = new Dictionary<int, List<int>>();
        foreach (var road in roads)
        {
            if (!graph.TryAdd(road[0], new List<int>(new[] { road[1] })))
                graph[road[0]].Add(road[1]);

            if (!graph.TryAdd(road[1], new List<int>(new[] { road[0] })))
                graph[road[1]].Add(road[0]);
        }

        DFS(graph, 0, 0, seats);
        return cost;
    }

    private int DFS(Dictionary<int, List<int>> graph, int prevCity, int curCity, int seats)
    {
        var people = 1;
        foreach (var neighbour in graph[curCity])
            if (neighbour != prevCity)
                people += DFS(graph, curCity, neighbour, seats);

        if (curCity != 0)
            cost += people / seats + (people % seats > 0 ? 1 : 0);

        return people;
    }
}

[TestFixture]
public class Tests
{
    private static Solution s = new();

    [Test]
    public static void Example()
    {
        var inp = new[]
        {
            new[] { 0, 1 },
            new[] { 0, 2 },
            new[] { 0, 3 },
        };
        var result = s.MinimumFuelCost(inp, 5);
        result.Should().Be(3);
    }

    [Test]
    public static void Example2()
    {
        var inp = new[]
        {
            new[] { 3, 1 },
            new[] { 3, 2 },
            new[] { 1, 0 },
            new[] { 0, 4 },
            new[] { 0, 5 },
            new[] { 4, 6 },
        };
        var result = s.MinimumFuelCost(inp, 2);
        result.Should().Be(7);
    }

    [Test]
    public static void Example17()
    {
        var inp = new[]
        {
            new[] { 0, 1 },
            new[] { 0, 2 },
            new[] { 1, 3 },
            new[] { 1, 4 },
        };
        var result = s.MinimumFuelCost(inp, 5);
        result.Should().Be(4);
    }

    [Test]
    public static void Example72()
    {
        var inp = new[]
        {
            new[] { 0, 1 },
            new[] { 1, 2 },
            new[] { 1, 3 },
            new[] { 4, 2 },
            new[] { 5, 3 },
            new[] { 6, 3 },
            new[] { 6, 7 },
            new[] { 8, 6 },
            new[] { 9, 0 },
            new[] { 5, 10 },
            new[] { 11, 9 },
            new[] { 12, 5 },
            new[] { 5, 13 },
            new[] { 8, 14 },
            new[] { 11, 15 },
            new[] { 8, 16 },
            new[] { 17, 0 },
            new[] { 18, 7 },
        };
        var result = s.MinimumFuelCost(inp, 13);
        result.Should().Be(19);
    }
}