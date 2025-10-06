using FluentAssertions;
using NUnit.Framework;

public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;

    public TreeNode(int val, TreeNode left, TreeNode right)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }

    public TreeNode(int x)
        => val = x;
}

/*//my solution but not very clever [O(n+h), O(n+h)]
public class Solution
{
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
    {
        var dict = new Dictionary<TreeNode, TreeNode>(); //node - father
        dict.Add(root, null);
        FillDictionary(dict, root);

        var set = new HashSet<TreeNode>();
        set.Add(p);
        set.Add(q);

        while (true)
        {
            if (dict[p] is not null)
            {
                if (!set.Add(dict[p]))
                    return dict[p];
                p = dict[p];
            }

            if (dict[q] is not null)
            {
                if (!set.Add(dict[q]))
                    return dict[q];
                q = dict[q];
            }
        }
    }

    private void FillDictionary(Dictionary<TreeNode, TreeNode> dict, TreeNode root)
    {
        if (root is null)
            return;

        if (root.left is not null)
            dict.Add(root.left, root);
        if (root.right is not null)
            dict.Add(root.right, root);

        FillDictionary(dict, root.left);
        FillDictionary(dict, root.right);
    }
}*/

/*//googled [O(log n), O(1)]
public class OldSolution
{
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
    {
        var curr = root;
        while (curr != null)
        {
            if (p.val > curr.val && q.val > curr.val)
                curr = curr.right;
            else if (p.val < curr.val && q.val < curr.val)
                curr = curr.left;
            else
                return curr;
        }

        return curr;
    }
}*/

//second attempt 6 min [O(log n, O(h))]
public class SecondSolution
{
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
    {
        if ((p.val < root.val && q.val > root.val) || (p.val > root.val && q.val < root.val))
            return root;

        if (p.val == root.val || q.val == root.val)
            return root;

        if (p.val < root.val && q.val < root.val)
            return LowestCommonAncestor(root.left, p, q);
        return LowestCommonAncestor(root.right, p, q);
    }
}

//third attempt 4 min [O(log n, O(h))]
public class Solution
{
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode child1, TreeNode child2)
    {
        if (root.val == child1.val || root.val == child2.val)
            return root;

        if (root.val > child1.val && root.val < child2.val
            || root.val < child1.val && root.val > child2.val)
            return root;

        if (root.val > child1.val && root.val > child2.val)
            return LowestCommonAncestor(root.left, child1, child2);

        return LowestCommonAncestor(root.right, child1, child2);
    }
}

//10 min [O(log n), O(h)]
public class FourthSolution
{
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
    {
        if (root.val >= p.val && root.val <= q.val
            || root.val <= p.val && root.val >= q.val)
            return root;

        if (root.val > p.val && root.val > q.val)
            return LowestCommonAncestor(root.left, p, q);
        else
            return LowestCommonAncestor(root.right, p, q);
    }
}

[TestFixture]
public class Tests
{
    private static Solution s = new();

    [Test]
    public static void Example()
    {
        var p = new TreeNode(2);
        var q = new TreeNode(1);
        p.right = q;
        var result = s.LowestCommonAncestor(p, p, q);
        var expected = p;
        result.Should().Be(expected);
    }

    [Test]
    public static void Example2()
    {
        var p = new TreeNode(2);
        p.left = new TreeNode(0);
        p.right = new TreeNode(4);
        p.right.left = new TreeNode(3);
        p.right.right = new TreeNode(5);
        var q = new TreeNode(8);
        q.left = new TreeNode(7);
        q.right = new TreeNode(9);
        var root = new TreeNode(6, p, q);
        var result = s.LowestCommonAncestor(root, p, q);
        var expected = root;
        result.Should().Be(expected);
    }
}
