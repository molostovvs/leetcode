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

/*//recursive solution
public class Solution
{
    public bool IsSymmetric(TreeNode root)
    {
        if (root is null)
            return true;
        return IsSymmetric(root.left, root.right);
    }

    private bool IsSymmetric(TreeNode left, TreeNode right)
    {
        if (left is null && right is null)
            return true;
        if (left is null || right is null)
            return false;
        if (left.val != right.val)
            return false;
        return IsSymmetric(left.left, right.right) && IsSymmetric(left.right, right.left);
    }
}*/

//iterative solution
public class Solution
{
    public bool IsSymmetric(TreeNode root)
    {
        if (root is null)
            return true;

        var list = new LinkedList<TreeNode>();
        list.AddFirst(root.left);
        list.AddLast(root.right);

        while (list.Count > 0)
        {
            var f = list.First.Value;
            var l = list.Last.Value;
            list.RemoveFirst();
            list.RemoveLast();

            if (f is null && l is null)
                continue;
            if (f is null || l is null)
                return false;
            if (f.val != l.val)
                return false;

            list.AddFirst(f.right);
            list.AddFirst(f.left);
            list.AddLast(l.left);
            list.AddLast(l.right);
        }

        return true;
    }
}