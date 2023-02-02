using FluentAssertions;
using NUnit.Framework;

public class Program
{
    public static void Main() {}
}

//brute force [O(n*m + nlogn), O(n)]
public class NaiveSolution
{
    public int[] KWeakestRows(int[][] mat, int k)
    {
        var res = new List<(int soldiers, int index)>();

        for (int r = 0; r < mat.GetLength(0); r++)
            res.Add((CountSoldiers(mat, r), r));

        return res.OrderBy(t => t.soldiers).ThenBy(t => t.index).Take(k).Select(t => t.index).ToArray();
    }

    private int CountSoldiers(int[][] mat, int i)
    {
        var res = 0;
        foreach (var j in mat[i])
            res += j;
        return res;
    }
}

//smart solution [O(n*log m + n*log k), O(k)]
public class Solution
{
    public int[] KWeakestRows(int[][] mat, int k)
    {
        var pq = new PriorityQueue<int, (int, int)>();
        for (var r = 0; r < mat.GetLength(0); r++)
        {
            var soldiers = GetNumberOfSoldiers(mat[r]);
            pq.Enqueue(r, (-soldiers, -r));
            if (pq.Count > k)
                pq.Dequeue();
        }

        var res = new List<int>();
        while (pq.Count > 0)
            res.Add(pq.Dequeue());
        res.Reverse();
        return res.ToArray();
    }

    private int GetNumberOfSoldiers(int[] civilians)
    {
        var left = 0;
        var right = civilians.Length - 1;

        while (left <= right)
        {
            var mid = left + (right - left) / 2;

            if (civilians[mid] == 0)
                right = mid - 1;
            else
                left = mid + 1;
        }

        return right + 1;
    }
}

[TestFixture]
public class Tests
{
    private static Solution s = new();

    [Test]
    public static void Example()
    {
        var mat = new int[5][]
        {
            new[] { 1, 1, 0, 0, 0 },
            new[] { 1, 1, 1, 1, 0 },
            new[] { 1, 0, 0, 0, 0 },
            new[] { 1, 1, 0, 0, 0 },
            new[] { 1, 1, 1, 1, 1 },
        };
        var result = s.KWeakestRows(mat, 3);
        var expected = new[] { 2, 0, 3 };
        result.Should().BeEquivalentTo(expected, opt => opt.WithStrictOrdering());
    }
}