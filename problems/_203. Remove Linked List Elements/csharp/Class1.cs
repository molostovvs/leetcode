using FluentAssertions;
using NUnit.Framework;

namespace _203._Remove_Linked_List_Elements;

public class Program
{
    public static void Main() {}
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

public class Solution
{
    public ListNode RemoveElements(ListNode head, int val)
    {
        var dummy = new ListNode(-100, head);
        var prev = dummy;

        while (head is not null)
        {
            if (head.val == val)
                prev.next = head.next;
            else
                prev = head;

            head = head.next;
        }

        return dummy.next;
    }
}

[TestFixture]
public class Tests
{
    private static Solution s = new();

    [Test]
    public static void Example()
    {
        var head = new ListNode(1, new ListNode(3, new ListNode(2)));
        var result = s.RemoveElements(head, 2);
        var expected = new ListNode(1, new ListNode(3));
        result.Should().BeEquivalentTo(expected);
    }
}