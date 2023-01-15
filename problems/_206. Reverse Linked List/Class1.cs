using FluentAssertions;
using NUnit.Framework;

namespace _206._Reverse_Linked_List;

public class Program
{
    static void Main(string[] args) {}
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
    public ListNode ReverseList(ListNode head, ListNode reversed = null)
    {
        if (head == null)
            return null;
        if (head.next == null)
        {
            head.next = reversed;
            return head;
        }

        var newHead = head.next;
        head.next = reversed;

        return ReverseList(newHead, head);
    }
}

[TestFixture]
public class Tests
{
    [SetUp]
    public static void SetUp()
        => s = new Solution();

    public static Solution s;

    [Test]
    public static void ExampleThreeNodes()
    {
        var list = new ListNode(1, new ListNode(2, new ListNode(3)));
        var result = s.ReverseList(list);
        var expected = new ListNode(3, new ListNode(2, new ListNode(1)));
        result.Should().BeEquivalentTo(expected);
    }

    [Test]
    public static void ExampleTwoNodes()
    {
        var list = new ListNode(1, new ListNode(2));
        var result = s.ReverseList(list);
        var expected = new ListNode(2, new ListNode(1));
        result.Should().BeEquivalentTo(expected);
    }

    [Test]
    public static void ExampleEmpty()
    {
        ListNode list = null;
        var result = s.ReverseList(list);
        ListNode expected = null;
        result.Should().BeEquivalentTo(expected);
    }
}