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

//first attempt recursive 6 min [O(n), O(1)]
public class Solution
{
    public TreeNode MergeTrees(TreeNode root1, TreeNode root2)
    {
        TreeNode node;
        if (root1 is null && root2 is null)
            return null;
        if (root1 is null)
            node = root2;
        else if (root2 is null)
            node = root1;
        else
            node = new TreeNode(root1.val + root2.val);

        node.left = MergeTrees(root1?.left, root2?.left);
        node.right = MergeTrees(root1?.right, root2?.right);
        return node;
    }
}