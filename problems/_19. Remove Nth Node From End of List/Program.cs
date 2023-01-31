public class ListNode
{
    public int val;
    public ListNode next;

    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}

//Two pass 12 min [O(n), O(1)]
public class TwoPassSolution
{
    public ListNode RemoveNthFromEnd(ListNode head, int n)
    {
        var count = 0;
        var cur = head;

        while (cur is not null)
        {
            count++;
            cur = cur.next;
        }

        if (count == n)
            return head.next;

        var index = count - n;

        var curIndex = 0;
        cur = head;
        ListNode prev = null;

        while (curIndex <= index)
        {
            if (curIndex == index)
                prev.next = cur.next;

            curIndex++;
            prev = cur;
            cur = cur.next;
        }

        return head;
    }
}

//One pass 50 min [O(n), O(1)]
public class Solution
{
    public ListNode RemoveNthFromEnd(ListNode head, int n)
    {
        var slow = head;
        var fast = head;
        ListNode prev = null;
        var counter = 1;

        while (fast?.next is not null)
        {
            if (counter == n)
            {
                prev = slow;
                slow = slow.next;
                fast = fast.next;
            }
            else
            {
                fast = fast.next;
                counter++;
            }
        }

        if (slow == head)
            return slow.next;

        prev.next = slow.next;
        return head;
    }
}