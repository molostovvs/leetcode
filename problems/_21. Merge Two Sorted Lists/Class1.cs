namespace _21._Merge_Two_Sorted_Lists;

public class Program
{
    static void Main(string[] args)
        => Solution.Test();
}

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

public static class OldSolution
{
    public static ListNode MergeTwoLists(ListNode list1, ListNode list2)
    {
        ListNode dummy = new ListNode();
        ListNode tail = dummy;

        while (list1 != null && list2 != null)
        {
            if (list1.val < list2.val)
            {
                tail.next = list1;
                list1 = list1.next;
            }
            else
            {
                tail.next = list2;
                list2 = list2.next;
            }

            tail = tail.next;
        }

        if (list1 is not null)
            tail.next = list1;
        if (list2 is not null)
            tail.next = list2;

        return dummy.next;
    }

    public static void Test()
    {
        var list1 = new ListNode(1, new ListNode(2, new ListNode(4)));
        var list2 = new ListNode(1, new ListNode(3, new ListNode(4)));

        var x = MergeTwoLists(list1, list2);
    }
}

//second attempt 8 min [O(n+m), O(1)]
public class Solution
{
    public ListNode MergeTwoLists(ListNode list1, ListNode list2)
    {
        var dummy = new ListNode();
        var tail = dummy;

        if (list1 is null && list2 is null)
            return null;

        while (list1 is not null || list2 is not null)
        {
            if (list1 is not null && list2 is not null)
            {
                if (list1.val <= list2.val)
                {
                    tail.next = list1;
                    tail = tail.next;
                    list1 = list1.next;
                }
                else
                {
                    tail.next = list2;
                    tail = tail.next;
                    list2 = list2.next;
                }
            }

            if (list1 is null)
            {
                tail.next = list2;
                break;
            }

            if (list2 is null)
            {
                tail.next = list1;
                break;
            }
        }

        return dummy.next;
    }
}