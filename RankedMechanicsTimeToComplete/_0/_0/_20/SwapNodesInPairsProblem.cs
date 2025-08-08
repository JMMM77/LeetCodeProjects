namespace LeetCodeSolutions._0._0._20;

/***
URL: https://leetcode.com/problems/merge-two-sorted-lists/description/
Number: 21
Difficulty: easy
 */
public class SwapNodesInPairsProblem
{
    public ListNode SwapPairs(ListNode head)
    {
        if (head == null)
        {
            return null;
        }
        else if (head.next == null)
        {
            return head;
        }

        // Swap inital heads manually
        var newHead = head.next;
        head.next = newHead.next;
        newHead.next = head;

        // Use recursion to swap the rest
        SwapHead(head);

        return newHead;
    }

    private ListNode SwapHead(ListNode parentHead)
    {
        if (parentHead.next == null)
        {
            return parentHead;
        }

        var swapTargetLeft = parentHead.next; // P -> (L) -> R

        if (swapTargetLeft.next == null)
        {
            return parentHead;
        }

        var swapWithRight = swapTargetLeft.next; // P -> L -> (R) -> RNext
        swapTargetLeft.next = swapWithRight.next; // P -> L & R -> RNext
        swapWithRight.next = swapTargetLeft; // P & R -> L -> RNext
        parentHead.next = swapWithRight; // P -> R -> L -> RNext

        SwapHead(swapTargetLeft);

        return swapWithRight;
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
