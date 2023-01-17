namespace _1502._Can_Make_Arithmetic_Progression_From_Sequence;

public class Solution
{
    public bool CanMakeArithmeticProgression(int[] arr)
    {
        Array.Sort(arr);
        var diff = arr[1] - arr[0];
        for (var i = 2; i < arr.Length; i++)
            if (arr[i] - arr[i - 1] != diff)
                return false;

        return true;
    }
}