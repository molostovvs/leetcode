using FluentAssertions;
using NUnit.Framework;

namespace _102._Binary_Tree_Level_Order_Traversal;

public class Program
{
    public static void Main() { }
}

public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;

    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}

public class Solution
{
    public IList<IList<int>> LevelOrder(TreeNode root)
    {
        var res = new List<IList<int>>();
        if (root is null)
            return res;

        var buffer = new Queue<TreeNode>(new[] { root });

        while (buffer.Count > 0)
        {
            res.Add(new List<int>());

            var currCount = buffer.Count;
            for (var i = 0; i < currCount; i++)
            {
                var curr = buffer.Dequeue();
                res[res.Count - 1].Add(curr.val);
                if (curr.left != null)
                    buffer.Enqueue(curr.left);

                if (curr.right != null)
                    buffer.Enqueue(curr.right);
            }
        }

        return res;
    }
}

//25 min [O(n), O(h)]
public class SecondSolution
{
    public IList<IList<int>> LevelOrder(TreeNode root)
    {
        var result = new List<IList<int>>();

        if (root is null)
            return result;

        result.Add(new List<int> { root.val });

        T(root.left, result, 1);
        T(root.right, result, 1);

        return result;
    }

    public void T(TreeNode root, List<IList<int>> result, int level)
    {
        if (root is null)
            return;

        if (result.Count - 1 < level)
            result.Add(new List<int> { root.val });
        else
            result[level].Add(root.val);


        T(root.left, result, level + 1);
        T(root.right, result, level + 1);
    }
}

[TestFixture]
public class Tests
{
    private static Solution s = new();

    [Test]
    public static void EmptyRoot()
    {
        TreeNode root = null;
        var result = s.LevelOrder(root);
        var expected = new List<IList<int>>();
        result.Should().BeEquivalentTo(expected, opt => opt.WithStrictOrdering());
    }

    [Test]
    public static void OneNode()
    {
        var root = new TreeNode(1);
        var result = s.LevelOrder(root);
        var expected = new List<IList<int>> { new List<int>(new[] { 1 }) };
        result.Should().BeEquivalentTo(expected, opt => opt.WithStrictOrdering());
    }

    [Test]
    public static void ThreeNode()
    {
        var root = new TreeNode(1, new TreeNode(9), new TreeNode(20));
        var result = s.LevelOrder(root);
        var expected = new List<IList<int>> { new List<int>(new[] { 1 }) };
        expected.Add(new List<int>(new[] { 9, 20 }));
        result.Should().BeEquivalentTo(expected, opt => opt.WithStrictOrdering());
    }

    [Test]
    public static void FiveNode()
    {
        var root = new TreeNode(1, new TreeNode(9), new TreeNode(20, new TreeNode(15), new TreeNode(7)));
        var result = s.LevelOrder(root);
        var expected = new List<IList<int>> { new List<int>(new[] { 1 }) };
        expected.Add(new List<int>(new[] { 9, 20 }));
        expected.Add(new List<int>(new[] { 15, 7 }));
        result.Should().BeEquivalentTo(expected, opt => opt.WithStrictOrdering());
    }
}
