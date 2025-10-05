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
    public IList<int> PostorderTraversal(TreeNode root)
    {
        var list = new LinkedList<int>();
        if (root is null)
            return list.ToList();
        var s = new Stack<TreeNode>();
        s.Push(root);

        while (s.Count > 0)
        {
            var cur = s.Pop();
            list.AddFirst(cur.val);
            if (cur.left is not null)
                s.Push(cur.left);
            if (cur.right is not null)
                s.Push(cur.right);
        }

        return list.ToList();
    }
}

/*//iterative solution [O(n), O(n)]
public class Solution
{
    public IList<int> PostorderTraversal(TreeNode root)
    {
        var list = new LinkedList<int>();
        if (root is null)
            return list.ToList();
        var s = new Stack<TreeNode>();
        s.Push(root);

        while (s.Count > 0)
        {
            var cur = s.Pop();
            list.AddFirst(cur.val);
            if (cur.left is not null)
                s.Push(cur.left);
            if (cur.right is not null)
                s.Push(cur.right);
        }

        return list.ToList();
    }
}*/