namespace _232._Implement_Queue_using_Stacks;

/**
 * Your MyQueue object will be instantiated and called as such:
 * MyQueue obj = new MyQueue();
 * obj.Push(x);
 * int param_2 = obj.Pop();
 * int param_3 = obj.Peek();
 * bool param_4 = obj.Empty();
 */

// implemented as in task [O(n^2?), O(n)]
// amortized O(1) for push, O(1) for pop & peek
public class MyQueue
{
    private Stack<int> _input;
    private Stack<int> _output;

    public MyQueue()
    {
        _input = new Stack<int>();
        _output = new Stack<int>();
    }

    public void Push(int x)
    {
        MoveItems(_output, _input);
        _input.Push(x);
    }

    public int Pop()
    {
        MoveItems(_input, _output);
        return _output.Pop();
    }

    public int Peek()
    {
        MoveItems(_input, _output);
        return _output.Peek();
    }

    private void MoveItems(Stack<int> from, Stack<int> to)
    {
        while (from.Count > 0)
            to.Push(from.Pop());
    }

    public bool Empty()
        => _input.Count == 0 && _output.Count == 0;
}