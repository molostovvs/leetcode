// implemented as in task [O(n^2?), O(n)]
// amortized O(1) for push, O(1) for pop & peek
public class FirstMyQueue
{
    private Stack<int> _input;
    private Stack<int> _output;

    public FirstMyQueue()
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

//second solution [O(1) amortized, O(n)]
public class MyQueue
{
    private Stack<int> _s1;
    private Stack<int> _s2;

    public MyQueue()
    {
        _s1 = new Stack<int>();
        _s2 = new Stack<int>();
    }

    public void Push(int x)
    {
        _s1.Push(x);
    }

    public int Pop()
    {
        Peek();
        return _s2.Pop();
    }

    public int Peek()
    {
        if (_s2.Count == 0)
            while (_s1.Count != 0)
                _s2.Push(_s1.Pop());
        return _s2.Peek();
    }

    public bool Empty()
        => _s1.Count == 0 && _s2.Count == 0;
}