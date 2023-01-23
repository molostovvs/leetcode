namespace _1290._Convert_Binary_Number_in_a_Linked_List_to_Integer;

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

/*// naive implementation [O(n), O(n)]
public class Solution
{
    public int GetDecimalValue(ListNode head)
    {
        var list = new List<int>();

        while (head != null)
        {
            list.Add(head.val);
            head = head.next;
        }

        list.Reverse();

        var res = 0;
        for (var i = 0; i < list.Count; i++)
            if (list[i] > 0)
                res += (int)Math.Pow(2, i);

        return res;
    }
}*/

// [O(n), O(1)]
public class Solution
{
    public int GetDecimalValue(ListNode head)
    {
        var res = 0;

        while (head != null)
        {
            res = res * 2 + head.val;
            head = head.next;
        }

        return res;
    }
}