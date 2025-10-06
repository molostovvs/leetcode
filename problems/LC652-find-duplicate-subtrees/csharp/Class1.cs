public class TreeNode
{
    public int val;
    public TreeNode? left;
    public TreeNode? right;

    public TreeNode(int val = 0, TreeNode? left = null, TreeNode? right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}

//first attempt 20 min (spied) [O(n), O(n)]
public class Solution
{
    public IList<TreeNode> FindDuplicateSubtrees(TreeNode root)
    {
        var stack = new Stack<TreeNode>();
        var visited = new Dictionary<TreeNode, string>();
        var duplicates = new Dictionary<string, List<TreeNode>>();
        stack.Push(root);

        while (stack.Count != 0)
        {
            var cur = stack.Peek();
            if (cur.left != null && !visited.ContainsKey(cur.left))
            {
                stack.Push(cur.left);
                continue;
            }

            if (cur.right != null && !visited.ContainsKey(cur.right))
            {
                stack.Push(cur.right);
                continue;
            }

            var newStructure = $"{cur.val}";
            if (cur.left != null && visited.ContainsKey(cur.left))
                newStructure = $"{visited[cur.left]} < {newStructure}";

            if (cur.right != null && visited.ContainsKey(cur.right))
                newStructure = $"{newStructure} > {visited[cur.right]}";

            visited.Add(stack.Pop(), newStructure);
            if (duplicates.ContainsKey(newStructure))
                duplicates[newStructure].Add(cur);
            else
                duplicates.Add(newStructure, new List<TreeNode> { cur });
        }

        return duplicates.Values.Where(v => v.Count > 1).Select(v => v[0]).ToList();
    }
}