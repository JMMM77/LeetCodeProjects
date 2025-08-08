namespace LeetCodeSolutions._0._0._10;

/***
URL: https://leetcode.com/problems/remove-nth-node-from-end-of-list/description/
Number: 19
Difficulty: Medium
 */
public class RemoveNthNodeFromEndOfListProblem
{
    public int NthNumber = 0;
    public ListNode? RemoveNthFromEnd(ListNode head, int n)
    {
        if (head.next == null && n == 1)
        {
            return null;
        }
        else if (head.next == null)
        {
            return head;
        }

        NthNumber = n - 1;
        GetNodeToRemove(head, head.next);

        if (NthNumber == 0)
        {
            return head.next;
        }

        return head;
    }

    private void GetNodeToRemove(ListNode parentNode, ListNode currentNode)
    {
        // Get to the end of the list
        if (currentNode.next != null)
        {
            GetNodeToRemove(currentNode, currentNode.next);
        }

        // Start counting backwards
        if (NthNumber == 0)
        {
            parentNode.next = currentNode.next;
            NthNumber--;
        }
        else if (NthNumber < 0)
        {
            return;
        }

        NthNumber--;
    }

    public class ListNode
    {
        public int val;
        public ListNode? next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
}
