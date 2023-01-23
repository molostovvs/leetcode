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

//using recursion [O(n), O(n)]
public class Solution
{
    public IList<int> PreorderTraversal(TreeNode root)
        => TraverseTree(root).ToList();

    private IEnumerable<int> TraverseTree(TreeNode root)
    {
        if (root is null)
            yield break;

        yield return root.val;

        foreach (var node in TraverseTree(root.left))
            yield return node;

        foreach (var node in TraverseTree(root.right))
            yield return node;
    }
}

/*// iterative [O(n), O(n)]
public class Solution
{
    public IList<int> PreorderTraversal(TreeNode root)
    {
        var list = new List<int>();
        var x = new LinkedList<TreeNode>();
        x.AddFirst(root);

        while (x.Count > 0)
        {
            var cur = x.First.Value;
            x.RemoveFirst();
            if (cur is null)
                continue;

            list.Add(cur.val);
            var y = x.AddFirst(cur.left);
            x.AddAfter(y, cur.right);
        }

        return list;
    }
}*/