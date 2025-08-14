namespace LeetCodeSolutions._0._0._80;

/***
URL: https://leetcode.com/problems/remove-duplicates-from-sorted-list
Number: 83
Difficulty: Easy
 */
public class RemoveDuplicatesFromSortedList
{
    public ListNode DeleteDuplicates(ListNode head)
    {
        if (head == null || head.next == null)
        {
            return head;
        }

        head.next = GetNextDifferentNode(head, head.val)!;
        return head;
    }

    private ListNode? GetNextDifferentNode(ListNode? checkNode, int checkNum)
    {
        if (checkNode == null)
        {
            return null;
        }

        if (checkNode.next == null)
        {
            if (checkNode.val <= checkNum)
            {
                return null;
            }

            return checkNode;
        }

        if (checkNode.val <= checkNum)
        {
            return GetNextDifferentNode(checkNode.next, checkNum);
        }

        checkNode.next = GetNextDifferentNode(checkNode.next, checkNode.val)!;

        return checkNode;
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
}
