namespace _20._Valid_Parentheses;

public class FirstSolution
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

public class SecondSolution
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

//5 min [O(n), O(n)]
public class ThirdSolution
{
    public bool IsValid(string s)
    {
        var dict = new Dictionary<char, char>()
        {
            { '(', ')' },
            { '{', '}' },
            { '[', ']' }
        };

        var stack = new Stack<char>();

        for (var i = 0; i < s.Length; i++)
        {
            var curChar = s[i];

            if (dict.ContainsKey(curChar))
                stack.Push(curChar);
            else
            {
                var success = stack.TryPop(out var prevChar);

                if (!success || dict[prevChar] != curChar)
                    return false;
            }
        }

        return stack.Count == 0;
    }
}