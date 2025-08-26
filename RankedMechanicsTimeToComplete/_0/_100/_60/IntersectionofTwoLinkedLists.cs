namespace LeetCodeSolutions._0._100._60;

/***
URL: https://leetcode.com/problems/intersection-of-two-linked-lists
Number: 160
Difficulty: Easy
*/
public class IntersectionofTwoLinkedLists
{
    public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
    {
        if (headA is null || headB is null)
        {
            return null;
        }

        var pointerA = headA;
        var pointerB = headB;

        // Switching heads when reaching the end, eventually both will reach the end
        while (pointerA != pointerB)
        {
            pointerA = (pointerA == null) ? headB : pointerA.next;
            pointerB = (pointerB == null) ? headA : pointerB.next;
        }

        return pointerA;
    }

    public class ListNode
    {
        public int val;
        public ListNode? next;
        public ListNode(int val = 0, ListNode? next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
}
