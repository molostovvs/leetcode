//naive solution [o(n^2), O(1)]

public class Solution
{
    public int[] DailyTemperatures(int[] temps)
    {
        var ans = new int[temps.Length];

        for (var i = 0; i < ans.Length; i++)
        {
            for (var j = i + 1; j < ans.Length; j++)
                if (temps[j] > temps[i])
                {
                    ans[i] = j - i;
                    break;
                }
        }

        return ans;
    }
}

// spied solution [O(n), O(n)]
public class SolutionFast
{
    public int[] DailyTemperatures(int[] temps)
    {
        var ans = new int[temps.Length];
        var st = new Stack<int>();

        for (var i = ans.Length - 1; i >= 0; i--)
        {
            while (st.Count != 0 && temps[st.Peek()] <= temps[i])
                st.Pop();

            if (st.Count != 0)
                ans[i] = st.Peek() - i;
            st.Push(i);
        }

        return ans;
    }
}