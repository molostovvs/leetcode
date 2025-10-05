﻿public class Solution
{
    public int MinimumDeviation(int[] nums)
    {
        int minValue = int.MaxValue;
        int minDeviation = int.MaxValue;
        PriorityQueue<int, int> pq = new PriorityQueue<int, int>();

        for (int i = 0; i < nums.Length; i++)
        {
            if ((nums[i] & 1) != 0) 
                nums[i] = (nums[i] * 2);

            minValue = Math.Min(minValue, nums[i]);
            pq.Enqueue(nums[i], -nums[i]);
        }

        while ((pq.Peek() & 1) == 0)
        {
            int maxValue = pq.Dequeue();
            minDeviation = Math.Min(minDeviation, maxValue - minValue);

            if ((maxValue & 1) == 0)
            {
                int newValue = (maxValue >> 1);
                pq.Enqueue(newValue, -newValue);
                minValue = Math.Min(minValue, newValue);
            }
        }

        return Math.Min(minDeviation, pq.Peek() - minValue);
    }
}