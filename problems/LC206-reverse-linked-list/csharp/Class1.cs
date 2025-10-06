using FluentAssertions;
using NUnit.Framework;

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

public class OldSolution
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

// 2nd attempt [O(n), O(1)]
public class SecondSolution
{
    public ListNode ReverseList(ListNode head)
    {
        var next = head?.next;
        ListNode prev = null;

        while (head != null)
        {
            head.next = prev;
            prev = head;
            head = next;
            next = head?.next;
        }

        return prev;
    }
}

//3rd attempt 5 min [O(n), O(1)]
public class Solution
{
    public ListNode ReverseList(ListNode head)
    {
        ListNode prev = null;
        var cur = head;

        while (cur != null)
        {
            var next = cur.next;
            cur.next = prev;
            prev = cur;
            cur = next;
        }

        return prev;
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