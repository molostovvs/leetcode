using FluentAssertions;
using NUnit.Framework;

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
    public ListNode DeleteDuplicates(ListNode head)
    {
        var dummy = new ListNode(-1, head);
        var slow = head?.next;

        while (head != null)
        {
            if (slow is null)
            {
                head.next = slow;
                break;
            }

            if (head.val != slow.val)
            {
                head.next = slow;
                head = slow;
                slow = slow.next;
            }
            else if (head.val == slow?.val)
            {
                slow = slow.next;
            }
        }

        return dummy.next;
    }
}

//next time solve this task recursively

[TestFixture]
public class Tests
{
    private static Solution s = new();

    [Test]
    public static void Example1_1()
    {
        var head = new ListNode(1, new ListNode(1));
        var result = s.DeleteDuplicates(head);
        var expected = new ListNode(1);
        result.Should().BeEquivalentTo(expected, opt => opt.WithStrictOrdering());
    }

    [Test]
    public static void Example1_1_2()
    {
        var head = new ListNode(1, new ListNode(1, new ListNode(2)));
        var result = s.DeleteDuplicates(head);
        var expected = new ListNode(1, new ListNode(2));
        result.Should().BeEquivalentTo(expected, opt => opt.WithStrictOrdering());
    }

    [Test]
    public static void Example1_1_1()
    {
        var head = new ListNode(1, new ListNode(1, new ListNode(1)));
        var result = s.DeleteDuplicates(head);
        var expected = new ListNode(1);
        result.Should().BeEquivalentTo(expected, opt => opt.WithStrictOrdering());
    }

    [Test]
    public static void Example1()
    {
        var head = new ListNode(1);
        var result = s.DeleteDuplicates(head);
        var expected = new ListNode(1);
        result.Should().BeEquivalentTo(expected, opt => opt.WithStrictOrdering());
    }

    [Test]
    public static void ExampleNull()
    {
        ListNode head = null;
        var result = s.DeleteDuplicates(head);
        ListNode expected = null;
        result.Should().BeEquivalentTo(expected, opt => opt.WithStrictOrdering());
    }
}