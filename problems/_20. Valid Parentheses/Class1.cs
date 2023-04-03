namespace _20._Valid_Parentheses;

public class OldSolution
{
    private char _result;

    public bool IsValid(string inp)
    {
        var s = new Stack<char>();

        foreach (var p in inp)
            if (p is '(' or '[' or '{')
            {
                s.Push(p);
            }
            else
            {
                char opening;
                if (!s.TryPop(out opening))
                    return false;
                switch (opening)
                {
                    case '(' when p is ')':
                    case '[' when p is ']':
                    case '{' when p is '}':
                        continue;
                    default: return false;
                }
            }

        return s.Count == 0;
    }
}

public class Solution
{
    public bool IsValid(string s)
    {
        var stack = new Stack<char>();
        var d = new Dictionary<char, char>
        {
            { '(', ')' },
            { '{', '}' },
            { '[', ']' },
        };

        foreach (var ch in s)
            if (d.ContainsKey(ch))
                stack.Push(ch);
            else if (stack.Count == 0)
                return false;
            else if (d[stack.Pop()] != ch)
                return false;

        return stack.Count == 0;
    }
}