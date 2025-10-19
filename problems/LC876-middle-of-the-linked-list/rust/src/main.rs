fn main() {
}

#[derive(PartialEq, Eq, Clone, Debug)]
pub struct ListNode {
    pub val: i32,
    pub next: Option<Box<ListNode>>,
}

struct Solution;

impl Solution {
    pub fn middle_node(head: Option<Box<ListNode>>) -> Option<Box<ListNode>> {
        let mut slow = head.as_ref();
        let mut fast = head.as_ref();

        while let Some(next_fast) = fast.and_then(|node| node.next.as_ref()) {
            fast = next_fast.next.as_ref();
            slow = slow.and_then(|node| node.next.as_ref());
        }

        return slow.cloned();
    }
}
