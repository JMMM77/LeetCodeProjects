namespace LeetCodeSolutions._0._0._20;
/***
URL: https://leetcode.com/problems/merge-k-sorted-lists/description/
Number: 23
Difficulty: Hard
 */
public class MergeKSortedListsProblem
{
    public ListNode MergeKLists(ListNode[] lists)
    {
        List<int> sortedLists = [];

        for (var i = 0; i < lists.Length; i++)
        {
            var listNode = lists[i];

            if (listNode == null)
            {
                continue;
            }

            while (listNode.next != null)
            {
                sortedLists.Add(listNode.val);
                listNode = listNode.next;
            }

            sortedLists.Add(listNode.val);
        }

        if (sortedLists.Count == 0)
        {
            return null;
        }

        sortedLists.Sort();
        sortedLists.Reverse();

        var returnListNode = new ListNode(sortedLists[0], null);

        for (var i = 1; i < sortedLists.Count; i++)
        {
            returnListNode = new ListNode(sortedLists[i], returnListNode);
        }

        return returnListNode;
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
