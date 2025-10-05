using FluentAssertions;
using NUnit.Framework;

public class Program
{
    public static void Main() {}
}

public class Node
{
    public int val;
    public Node left;
    public Node right;
    public Node next;

    public Node() {}

    public Node(int _val)
    {
        val = _val;
    }

    public Node(int _val, Node _left, Node _right, Node _next)
    {
        val = _val;
        left = _left;
        right = _right;
        next = _next;
    }
}

public class Solution
{
    public Node Connect(Node root)
    {
        if (root is null)
            return null;

        var q = new Queue<Node>();
        q.Enqueue(root);
        var counter = 1;

        while (q.Count > 0)
        {
            var curCounter = counter;
            counter = 0;
            Node prev = null;

            while (curCounter > 0)
            {
                var cur = q.Dequeue();
                curCounter--;
                if (cur.left is not null)
                {
                    q.Enqueue(cur.left);
                    q.Enqueue(cur.right);
                    counter += 2;
                }

                if (prev is not null)
                    prev.next = cur;
                prev = cur;
            }
        }

        return root;
    }
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
            new Node(2, new Node(4), new Node(5), null),
            new Node(3, new Node(6), new Node(7), null),
            null
        );
        var result = s.Connect(root);
        var n7 = new Node(7, null, null, null);
        var n6 = new Node(6, null, null, n7);
        var n3 = new Node(3, n6, n7, null);
        var n5 = new Node(5, null, null, n6);
        var n4 = new Node(4, null, null, n5);
        var n2 = new Node(2, n4, n5, n3);
        var n1 = new Node(1, n2, n3, null);
        var expected = n1;
        result.Should().BeEquivalentTo(expected);
    }
}