/*//using stack and linked list
public class MinStack
{
    private Stack<int> _stack;
    private LinkedList<int> _list;

    public MinStack()
    {
        _stack = new Stack<int>();
        _list = new LinkedList<int>();
    }

    public void Push(int val)
    {
        if (_list.Count == 0)
        {
            _list.AddFirst(val);
        }
        else
        {
            if (val < _list.Last.Value)
                _list.AddLast(val);
            else
                _list.AddLast(_list.Last.Value);
        }

        _stack.Push(val);
    }

    public void Pop()
    {
        var item = _stack.Pop();
        _list.RemoveLast();
    }

    public int Top()
        => _stack.Peek();

    public int GetMin()
        => _list.Last.Value;
}*/

//custom linked list solution [O(n), O(n)]
public class MinStack
{
    private Node _head;

    public void Push(int val)
    {
        if (_head is null)
            _head = new Node(val, val, null);
        else
            _head = new Node(val, Math.Min(_head.Min, val), _head);
    }

    public void Pop()
        => _head = _head.Previous;

    public int Top()
        => _head.Value;

    public int GetMin()
        => _head.Min;

    private class Node
    {
        public int Value;
        public int Min;
        public Node Previous;

        public Node(int value, int min, Node previous)
        {
            Value = value;
            Min = min;
            Previous = previous;
        }
    }
}