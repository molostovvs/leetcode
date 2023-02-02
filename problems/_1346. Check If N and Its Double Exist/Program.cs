/*// naive [O(n^2), O(1)]
public class NaiveSolution
{
    public bool CheckIfExist(int[] arr)
    {
        for (var i = 0; i < arr.Length; i++)
            for (var j = i + 1; j < arr.Length; j++)
                if (arr[i] * 2 == arr[j] || arr[j] * 2 == arr[i])
                    return true;
        return false;
    }
}*/

public class Solution
{
    public bool CheckIfExist(int[] arr)
    {
        var d = new Dictionary<int, int>();

        for (var i = 0; i < arr.Length; i++)
            d[arr[i]] = i;

        for (var i = 0; i < arr.Length; i++)
            if (d.ContainsKey(arr[i] * 2) && d[arr[i] * 2] != i)
                return true;

        return false;
    }
}