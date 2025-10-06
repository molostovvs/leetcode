public class Solution
{
    public int LastStoneWeight(int[] stones)
    {
        var q = new PriorityQueue<int, int>();
        foreach (var s in stones)
            q.Enqueue(s, -s); //(s, -s) for Max Heap, so biggest values at the top of queue

        while (q.Count > 1)
        {
            var s1 = q.Dequeue();
            var s2 = q.Dequeue();
            var res = s1 - s2;
            if (res != 0)
                q.Enqueue(res, -res);
        }

        return q.Count > 0 ? q.Dequeue() : 0;
    }
}