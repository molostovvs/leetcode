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

//naive solution 30min [O(n), O(h)]
public class NaiveSolution
{
    public int MinDiffInBST(TreeNode root)
    {
        return Helper(root, int.MaxValue, int.MaxValue);
    }

    public int Helper(TreeNode root, int prevMin, int prevMax, int minDiff = int.MaxValue)
    {
        minDiff = Math.Min(minDiff, Math.Min(Math.Abs(prevMax - root.val), Math.Abs(prevMin - root.val)));
        if (root.left is null && root.right is null)
            return minDiff;

        if (root.left is not null && root.right is not null)
            return Math.Min(Helper(root.left, prevMin, root.val, minDiff), Helper(root.right, root.val, prevMax, minDiff));
        if (root.left is null)
            return Helper(root.right, root.val, prevMax, minDiff);
        if (root.right is null)
            return Helper(root.left, prevMin, root.val, minDiff);
        return int.MaxValue;
    }
}

//inorder traversal [O(n), O(h)]
public class Solution
{
    private int res = int.MaxValue;
    private int pre = -1;

    public int MinDiffInBST(TreeNode root)
    {
        if (root.left is not null)
            MinDiffInBST(root.left);
        if (pre != -1)
            res = Math.Min(res, root.val - pre);
        pre = root.val;
        if (root.right is not null)
            MinDiffInBST(root.right);
        return res;
    }
}