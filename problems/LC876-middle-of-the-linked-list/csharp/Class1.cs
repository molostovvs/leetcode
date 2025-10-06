namespace _876._Middle_of_the_Linked_List;

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

public class Solution
{
    public ListNode MiddleNode(ListNode head)
    {
        if (head == null)
            return null;
        var arr = new List<ListNode>();

        while (head != null)
        {
            arr.Add(head);
            head = head.next;
        }

        return arr[arr.Count / 2];
    }
}