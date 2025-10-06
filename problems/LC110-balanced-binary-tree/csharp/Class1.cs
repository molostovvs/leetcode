using FluentAssertions;
using NUnit.Framework;

public class TreeNode
{
    public int val;
    public TreeNode? left;
    public TreeNode? right;

    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}

//First attempt 40 min [O(n^2), O(h)]
public class Solution
{
    public bool IsBalanced(TreeNode? root)
    {
        if (root is null)
            return true;

        if (Math.Abs(GetHeight(root.left) - GetHeight(root.right)) > 1)
            return false;

        return IsBalanced(root.left) && IsBalanced(root.right);
    }

    private int GetHeight(TreeNode? root)
    {
        if (root is null)
            return 0;

        return Math.Max(GetHeight(root.left), GetHeight(root.right)) + 1;
    }
}

//30 min [O(n), o(h)]
public class SecondSolution
{
    public bool IsBalanced(TreeNode? root)
    {
        if (root is null)
            return true;

        return Dfs(root).IsBalanced;
    }

    public (bool IsBalanced, int Height) Dfs(TreeNode? node)
    {
        if (node is null)
            return (true, 0);

        if (node.left is null && node.right is null)
            return (true, 1);

        var left = Dfs(node.left);
        var right = Dfs(node.right);

        var curHeight = Math.Max(left.Height, right.Height) + 1;

        if (left.IsBalanced is false || right.IsBalanced is false)
            return (false, curHeight);

        if (Math.Abs(left.Height - right.Height) > 1)
            return (false, curHeight);

        return (true, curHeight);
    }
}

[TestFixture]
public class Tests
{
    [Test]
    public void SimpleTest()
    {
        var r = new TreeNode(
            3,
            new TreeNode(9),
            new TreeNode(20, new TreeNode(15), new TreeNode(7))
        );

        var s = new Solution();
        var actual = s.IsBalanced(r);
        actual.Should().BeTrue();
    }

    [Test]
    public void Test2()
    {
        var r = new TreeNode(
            1,
            new TreeNode(2, new TreeNode(3, new TreeNode(4), new TreeNode(4)), new TreeNode(3)),
            new TreeNode(2)
        );

        var s = new Solution();
        var actual = s.IsBalanced(r);
        actual.Should().BeFalse();
    }

    [Test]
    public void Test3()
    {
        var r = new TreeNode(1, null, new TreeNode(2, null, new TreeNode(3)));

        var s = new Solution();
        var actual = s.IsBalanced(r);
        actual.Should().BeFalse();
    }
}
