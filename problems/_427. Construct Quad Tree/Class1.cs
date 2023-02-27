// Definition for a QuadTree node.
public class Node
{
    public bool val;
    public bool isLeaf;
    public Node topLeft;
    public Node topRight;
    public Node bottomLeft;
    public Node bottomRight;

    public Node()
    {
        val = false;
        isLeaf = false;
        topLeft = null;
        topRight = null;
        bottomLeft = null;
        bottomRight = null;
    }

    public Node(bool _val, bool _isLeaf)
    {
        val = _val;
        isLeaf = _isLeaf;
        topLeft = null;
        topRight = null;
        bottomLeft = null;
        bottomRight = null;
    }

    public Node(bool _val, bool _isLeaf, Node _topLeft, Node _topRight, Node _bottomLeft, Node _bottomRight)
    {
        val = _val;
        isLeaf = _isLeaf;
        topLeft = _topLeft;
        topRight = _topRight;
        bottomLeft = _bottomLeft;
        bottomRight = _bottomRight;
    }
}

//first attempt 20 min
public class Solution
{
    public Node Construct(int[][] grid)
        => Construct(0, 0, grid.Length, grid);

    public Node Construct(int x, int y, int n, int[][] grid)
    {
        var answer = new Node();
        if (n == 1)
            return new Node(grid[y][x] == 1, true);

        var halfSize = n / 2;
        var upperLeft = Construct(x, y, halfSize, grid);
        var upperRight = Construct(x + halfSize, y, halfSize, grid);
        var bottomLeft = Construct(x, y + halfSize, halfSize, grid);
        var bottomRight = Construct(x + halfSize, y + halfSize, halfSize, grid);

        if (upperLeft.val == upperRight.val
            && upperRight.val == bottomLeft.val
            && bottomLeft.val == bottomRight.val
            && upperLeft.isLeaf
            && upperRight.isLeaf
            && bottomLeft.isLeaf
            && bottomRight.isLeaf)
        {
            answer.val = upperRight.val;
            answer.isLeaf = true;
        }
        else
        {
            answer.topLeft = upperLeft;
            answer.topRight = upperRight;
            answer.bottomLeft = bottomLeft;
            answer.bottomRight = bottomRight;
        }

        return answer;
    }
}