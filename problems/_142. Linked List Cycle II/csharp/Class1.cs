using FluentAssertions;
using NUnit.Framework;

namespace _142._Linked_List_Cycle_II;

public class Program
{
    static void Main(string[] args) {}
}

public class ListNode
{
    public int val;
    public ListNode next;

    public ListNode(int x)
    {
        val = x;
        next = null;
    }
}

public class Solution
{
    public ListNode DetectCycle(ListNode head)
    {
        /*HashSet<ListNode> set = new HashSet<ListNode>(); // naive solution time O(n), space O(n)

        while (head != null)
        {
            if (set.Contains(head.next))
                return head.next;
            set.Add(head);
            head = head.next;
        }

        return null;*/

        var slowPointer = head; // best solution time O(n), space O(1)
        var fastPointer = head;

        while (fastPointer != null && fastPointer.next != null)
        {
            slowPointer = slowPointer.next;
            fastPointer = fastPointer.next?.next;

            if (fastPointer == slowPointer)
            {
                var start = head; //starting again to detect node where cycle begins
                while (start != slowPointer)
                {
                    start = start.next;
                    slowPointer = slowPointer.next;
                }

                return start;
            }
        }

        return null;
    }
}

[TestFixture]
public class Tests
{
    public static Solution s = new();

    [Test]
    public static void Example1()
    {
        var x = new ListNode(3);
        var y = new ListNode(2);
        var z = new ListNode(0);
        var i = new ListNode(-4);
        x.next = y;
        y.next = z;
        z.next = i;
        i.next = y;
        var result = s.DetectCycle(x);
        result.Should().Be(y);
    }

    [Test]
    public static void Example2()
    {
        var x = new ListNode(3);
        var y = new ListNode(2);
        x.next = y;
        y.next = x;
        var result = s.DetectCycle(x);
        result.Should().Be(x);
    }

    [Test]
    public static void Example3()
    {
        var x = new ListNode(3);
        var result = s.DetectCycle(x);
        result.Should().Be(null);
    }
}