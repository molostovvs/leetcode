public class ListNode
{
    public int val;
    public ListNode? next;

    public ListNode(int x)
    {
        val = x;
        next = null;
    }
}

public class FirstSolution
{
    public bool HasCycle(ListNode head)
    {
        var slow = head;
        var fast = head;

        while (fast != null && fast.next != null)
        {
            slow = slow.next;
            fast = fast.next.next;

            if (slow == fast)
                return true;
        }

        return false;
    }
}

//4 min [O(n), O(1)]
public class Solution
{
    public bool HasCycle(ListNode? head)
    {
        if (head is null)
            return false;

        var slow = head;
        var fast = head.next?.next;

        while (slow != fast && fast != null)
        {
            slow = slow!.next;
            fast = fast.next?.next;
        }

        return fast == slow;
    }
}