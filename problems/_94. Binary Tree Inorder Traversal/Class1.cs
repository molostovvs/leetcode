using System.Collections;

namespace _94._Binary_Tree_Inorder_Traversal;

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

// recursive solution [O(n), O(n)]
public class Solution
{
    public IList<int> InorderTraversal(TreeNode root)
    {
        var list = new List<int>();

        foreach (var node in TraverseInorder(root))
            list.Add(node.val);

        return list;
    }

    private IEnumerable<TreeNode> TraverseInorder(TreeNode root)
    {
        if (root is null)
            yield break;
        foreach (var node in TraverseInorder(root.left))
            yield return node;
        yield return root;
        foreach (var node in TraverseInorder(root.right))
            yield return node;
    }
}

/*// iterative solution [O(n), O(n)]
public class Solution
{
    public IList<int> InorderTraversal(TreeNode root)
    {
        var list = new List<int>();
        var s = new Stack<TreeNode>();
        var cur = root;

        while (cur != null || s.Count > 0)
        {
            while (cur != null)
            {
                s.Push(cur);
                cur = cur.left;
            }

            cur = s.Pop();
            list.Add(cur.val);
            cur = cur.right;
        }

        return list;
    }
}*/