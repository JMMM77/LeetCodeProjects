namespace LeetCodeSolutions._0._100._40;

/***
URL: https://leetcode.com/problems/linked-list-cycle
Number: 141
Difficulty: Easy
*/
public class LinkedListCycle
{
    public bool HasCycle(ListNode head)
    {
        if (head is null || head.next is null || head.next.next is null)
        {
            return false;
        }

        var slowPointer = head.next;
        var fastPointer = head.next?.next;

        while (fastPointer != null && fastPointer.next != null)
        {
            if (slowPointer == fastPointer)
            {
                return true;
            }

            slowPointer = slowPointer!.next;
            fastPointer = fastPointer.next.next;
        }

        return false;
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
