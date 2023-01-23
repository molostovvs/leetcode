namespace _404._Sum_of_Left_Leaves;

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
    public int SumOfLeftLeaves(TreeNode root)
    {
        var sum = 0;
        if (root is null)
            return sum;
        if (root.left is not null && root.left.left is null && root.left.right is null)
            sum += root.left.val;

        sum += SumOfLeftLeaves(root.left);
        sum += SumOfLeftLeaves(root.right);
        return sum;
    }
}