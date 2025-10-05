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

public class FirstSolution
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
public class SecondSolution
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

//third attempt 2 min [O(n), O(h)]
public class Solution
{
    public TreeNode InvertTree(TreeNode root)
    {
        if (root is null)
            return root;

        (root.right, root.left) = (root.left, root.right);

        InvertTree(root.left);
        InvertTree(root.right);

        return root;
    }
}

//fourth attempt 10 min [O(n), O(h)]
public class FourthSolution
{
    public TreeNode InvertTree(TreeNode root)
    {
        if (root is null)
            return null;

        (root.left, root.right) = (root.right, root.left);
        InvertTree(root.left);
        InvertTree(root.right);

        return root;
    }
}
