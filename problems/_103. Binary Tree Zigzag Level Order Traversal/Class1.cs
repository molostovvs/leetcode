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

//first attempt 20 min [O(n), O(n)]
public class Solution
{
    public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
    {
        var answer = new List<IList<int>>();
        if (root is null)
            return answer;
        var s = new Stack<TreeNode>();
        s.Push(root);
        var fromRight = false;

        while (s.Count > 0)
        {
            answer.Add(new List<int>());
            var tempSt = new Stack<TreeNode>();

            while (s.Count > 0)
            {
                var cur = s.Pop();
                answer[^1].Add(cur.val);

                if (fromRight)
                {
                    if (cur.right is not null)
                        tempSt.Push(cur.right);
                    if (cur.left is not null)
                        tempSt.Push(cur.left);
                }
                else
                {
                    if (cur.left is not null)
                        tempSt.Push(cur.left);
                    if (cur.right is not null)
                        tempSt.Push(cur.right);
                }
            }

            s = tempSt;
            fromRight = !fromRight;
        }

        return answer;
    }
}