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
    public TreeNode InsertIntoBST(TreeNode root, int val)
    {
        if (root is null)
            return new TreeNode(val);

        if (val < root.val)
        {
            if (root.left is not null)
            {
                InsertIntoBST(root.left, val);
            }
            else
            {
                root.left = new TreeNode(val);
                return root;
            }
        }
        else
        {
            if (root.right is not null)
            {
                InsertIntoBST(root.right, val);
            }
            else
            {
                root.right = new TreeNode(val);
                return root;
            }
        }

        return root;
    }
}