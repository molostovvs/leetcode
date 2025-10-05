using FluentAssertions;
using NUnit.Framework;

namespace _589._N_ary_Tree_Preorder_Traversal;

public class Program
{
    public static void Main() {}
}

public class Node
{
    public int val;
    public IList<Node> children;

    public Node() {}

    public Node(int _val)
        => val = _val;

    public Node(int _val, IList<Node> _children)
    {
        val = _val;
        children = _children;
    }

    public override string ToString()
        => val.ToString();
}

public class Solution
{
    /*//recursive algorithm [O(n), O(1)]
    public IList<int> Preorder(Node root)
    {
        var res = new List<int>();
        res.AddRange(GetChildrenValues(root));
        return res;
    }

    private IEnumerable<int> GetChildrenValues(Node root)
    {
        if (root == null)
            yield break;
        yield return root.val;
        foreach (var child in root.children)
        {
            foreach (var i in GetChildrenValues(child))
                yield return i;
        }
    }*/

    //iterative with linked list [O(n), O(n)]
    public IList<int> Preorder(Node root)
    {
        var res = new List<int>();
        if (root is null)
            return res;
        var x = new LinkedList<Node>(new[] { root });

        while (x.Count > 0)
        {
            var curr = x.First();
            x.RemoveFirst();
            res.Add(curr.val);

            if (curr.children == null)
                continue;

            var prev = x.First;
            foreach (var child in curr.children)
                if (child == curr.children.First())
                    prev = x.AddFirst(child);
                else
                    prev = x.AddAfter(prev, child);
        }

        return res;
    }

    /*//iterative with stack [O(n), O(n)]
    public IList<int> Preorder(Node root)
    {
        var res = new List<int>();
        if (root is null)
            return res;

        var s = new Stack<Node>(new[] { root });

        while (s.Count > 0)
        {
            root = s.Pop();
            res.Add(root.val);

            if (root.children == null)
                continue;
            for (var i = root.children.Count - 1; i >= 0; i--)
                s.Push(root.children[i]);
        }

        return res;
    }*/
}

[TestFixture]
public class Tests
{
    private static Solution s = new();

    [Test]
    public static void Example()
    {
        var root = new Node(
            1,
            new List<Node>(
                new[] { new Node(3, new List<Node>(new[] { new Node(5), new Node(6) })), new Node(2), new Node(4) }
            )
        );
        var result = s.Preorder(root);
        var expected = new List<int>(new[] { 1, 3, 5, 6, 2, 4 });
        result.Should().BeEquivalentTo(expected, opt => opt.WithStrictOrdering());
    }
}