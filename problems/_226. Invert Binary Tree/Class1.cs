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

public class OldSolution
{
    public TreeNode InvertTree(TreeNode root)
    {
        if (root is null)
            return root;

        (root.left, root.right) = (root.right, root.left);

        InvertTree(root.left);
        InvertTree(root.right);
        return root;
    }
}

//second attempt 3 min [O(n), O(h)]
public class Solution
{
    public TreeNode InvertTree(TreeNode root)
    {
        Helper(root);
        return root;
    }

    private void Helper(TreeNode root)
    {
        if (root is null)
            return;

        (root.left, root.right) = (root.right, root.left);
        Helper(root.left);
        Helper(root.right);
    }
}