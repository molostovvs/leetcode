public class Solution
{
    public IList<IList<int>> Permute(int[] nums)
    {
        var res = new List<IList<int>>();
        Helper(res, new List<int>(), nums);
        return res;
    }

    private void Helper(List<IList<int>> res, List<int> temp, int[] nums)
    {
        if (temp.Count == nums.Length)
            res.Add(new List<int>(temp));
        else
            foreach (var t in nums)
                if (!temp.Contains(t))
                {
                    temp.Add(t);
                    Helper(res, temp, nums);
                    temp.RemoveAt(temp.Count - 1);
                }
    }
}