using FluentAssertions;
using NUnit.Framework;

namespace _235._Lowest_Common_Ancestor_of_a_Binary_Search_Tree;

public class Program
{
    public static void Main() {}
}

public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;

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

//googled [O(log n), O(1)]
public class Solution
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
}