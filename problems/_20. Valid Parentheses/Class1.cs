namespace _20._Valid_Parentheses;

public class Solution
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
                    default:
                        return false;
                }
            }

        return s.Count == 0;
    }
}