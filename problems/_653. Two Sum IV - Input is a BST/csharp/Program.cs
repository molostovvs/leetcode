using FluentAssertions;
using NUnit.Framework;

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

public class Solution
{
    HashSet<int> seen = new HashSet<int>();

    public bool FindTarget(TreeNode root, int target)
    {
        if (root is null)
            return false;
        if (seen.Contains(target - root.val))
            return true;
        seen.Add(root.val);
        return FindTarget(root.left, target) || FindTarget(root.right, target);
    }
}

[TestFixture]
public class Tests
{
    private static Solution s = new Solution();

    [Test]
    public static void SmallExample()
    {
        var root = new TreeNode(2, new TreeNode(1), new TreeNode(3));
        var result = s.FindTarget(root, 4);
        result.Should().BeTrue();
    }

    [Test]
    public static void MidExample9()
    {
        var root = new TreeNode(
            5,
            new TreeNode(3, new TreeNode(2), new TreeNode(4)),
            new TreeNode(6, null, new TreeNode(7))
        );
        var result = s.FindTarget(root, 9);
        result.Should().BeTrue();
    }

    [Test]
    public static void MidExample11()
    {
        var root = new TreeNode(
            5,
            new TreeNode(3, new TreeNode(2), new TreeNode(4)),
            new TreeNode(6, null, new TreeNode(7))
        );
        var result = s.FindTarget(root, 11);
        result.Should().BeTrue();
    }

    [Test]
    public static void MidExample12()
    {
        var root = new TreeNode(
            5,
            new TreeNode(3, new TreeNode(2), new TreeNode(4)),
            new TreeNode(6, null, new TreeNode(7))
        );
        var result = s.FindTarget(root, 12);
        result.Should().BeTrue();
    }

    [Test]
    public static void MidExample8()
    {
        var root = new TreeNode(
            5,
            new TreeNode(3, new TreeNode(2), new TreeNode(4)),
            new TreeNode(6, null, new TreeNode(7))
        );
        var result = s.FindTarget(root, 8);
        result.Should().BeTrue();
    }

    [Test]
    public static void MidExample5()
    {
        var root = new TreeNode(
            5,
            new TreeNode(3, new TreeNode(2), new TreeNode(4)),
            new TreeNode(6, null, new TreeNode(7))
        );
        var result = s.FindTarget(root, 5);
        result.Should().BeTrue();
    }

    [Test]
    public static void MidExample7()
    {
        var root = new TreeNode(
            5,
            new TreeNode(3, new TreeNode(2), new TreeNode(4)),
            new TreeNode(6, null, new TreeNode(7))
        );
        var result = s.FindTarget(root, 7);
        result.Should().BeTrue();
    }

    [Test]
    public static void MidExample4()
    {
        var root = new TreeNode(
            5,
            new TreeNode(3, new TreeNode(2), new TreeNode(4)),
            new TreeNode(6, null, new TreeNode(7))
        );
        var result = s.FindTarget(root, 4);
        result.Should().BeFalse();
    }

    [Test]
    public static void TestCase1036()
    {
        var root = new TreeNode(
            600,
            new TreeNode(424, null, new TreeNode(499)),
            new TreeNode(612, null, new TreeNode(689))
        );
        var result = s.FindTarget(root, 1036);
        result.Should().BeTrue();
    }

    [Test]
    public static void TestCase1()
    {
        var root = new TreeNode(0, new TreeNode(-3, new TreeNode(-4)), new TreeNode(2, new TreeNode(1)));
        var result = s.FindTarget(root, 1);
        result.Should().BeTrue();
    }
}