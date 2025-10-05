using FluentAssertions;
using NUnit.Framework;

namespace _98._Validate_Binary_Search_Tree;

public class Program
{
    public static void Main() {}
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

/* //__first attempt 90 min [O(n), O(h)]
public class Solution
{
    public bool IsValidBST(TreeNode root, double leftThreshold = double.NegativeInfinity,
        double rightThreshold = double.PositiveInfinity)
    {
        if (root is null)
            return true;

        if (root.val >= rightThreshold || root.val <= leftThreshold)
            return false;

        return IsValidBST(root.right, root.val, rightThreshold) && IsValidBST(root.left, leftThreshold, root.val);
    }
}*/

//second attempt 5 min [O(n), O(h)]
public class Solution
{
    public bool IsValidBST(TreeNode root, long leftThr = long.MinValue, long rightThr = long.MaxValue)
    {
        if (root is null)
            return true;

        if (root.val <= leftThr || root.val >= rightThr)
            return false;

        return IsValidBST(root.left, leftThr, root.val) && IsValidBST(root.right, root.val, rightThr);
    }
}

[TestFixture]
public class Tests
{
    private static Solution s = new();

    [Test]
    public static void Example()
    {
        var root = new TreeNode(2, new TreeNode(1), new TreeNode(3));
        var result = s.IsValidBST(root);
        result.Should().BeTrue();
    }

    [Test]
    public static void Example2()
    {
        var root = new TreeNode(1, null, new TreeNode(1));
        var result = s.IsValidBST(root);
        result.Should().BeFalse();
    }
}